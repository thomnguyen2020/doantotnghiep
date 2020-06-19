using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Helper.Core
{
    public class VPCRequest_Global
    {
        Uri _address;
        SortedList<String, String> _requestFields = new SortedList<String, String>(new VPCStringComparer());
        String _rawResponse;
        SortedList<String, String> _responseFields = new SortedList<String, String>(new VPCStringComparer());
        String _secureSecret;


        public VPCRequest_Global(String URL)
        {
            _address = new Uri(URL);
        }

        public void SetSecureSecret(String secret)
        {
            _secureSecret = secret;
        }

        public void AddDigitalOrderField(String key, String value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _requestFields.Add(key, value);
            }
        }

        public String GetResultField(String key, String defValue)
        {
            String value;
            if (_responseFields.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                return defValue;
            }
        }

        public String GetResultField(String key)
        {
            return GetResultField(key, "");
        }

        private String GetRequestRaw()
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in _requestFields)
            {
                if (!String.IsNullOrEmpty(kvp.Value))
                {
                    data.Append(kvp.Key + "=" + Utils.UrlEncode(kvp.Value) + "&");
                }
            }
            //remove trailing & from string
            if (data.Length > 0)
                data.Remove(data.Length - 1, 1);
            return data.ToString();
        }

        public string GetTxnResponseCode()
        {
            return GetResultField("vpc_TxnResponseCode");
        }

        //_____________________________________________________________________________________________________
        // Three-Party order transaction processing

        public String Create3PartyQueryString()
        {
            StringBuilder url = new StringBuilder();
            //Payment Server URL
            url.Append(_address);
            url.Append("?");
            //Create URL Encoded request string from request fields 
            url.Append(GetRequestRaw());
            //Hash the request fields
            url.Append("&vpc_SecureHash=");
            url.Append(CreateSHA256Signature(true));
            return url.ToString();
        }

        public string Process3PartyResponse(System.Collections.Specialized.NameValueCollection nameValueCollection)
        {
            foreach (string item in nameValueCollection)
            {
                if (!item.Equals("vpc_SecureHash") && !item.Equals("vpc_SecureHashType"))
                {
                    _responseFields.Add(item, nameValueCollection[item]);
                }

            }

            if (!nameValueCollection["vpc_TxnResponseCode"].Equals("0") && !String.IsNullOrEmpty(nameValueCollection["vpc_Message"]))
            {
                if (!String.IsNullOrEmpty(nameValueCollection["vpc_SecureHash"]))
                {
                    if (!CreateSHA256Signature(false).Equals(nameValueCollection["vpc_SecureHash"]))
                    {
                        return "INVALIDATED";
                    }
                    return "CORRECTED";
                }
                return "CORRECTED";
            }

            if (String.IsNullOrEmpty(nameValueCollection["vpc_SecureHash"]))
            {
                return "INVALIDATED";//no sercurehash response
            }
            if (!CreateSHA256Signature(false).Equals(nameValueCollection["vpc_SecureHash"]))
            {
                return "INVALIDATED";
            }
            return "CORRECTED";
        }

        //_____________________________________________________________________________________________________

        private class VPCStringComparer : IComparer<String>
        {
            /*
             <summary>Customised Compare Class</summary>
             <remarks>
             <para>
             The Virtual Payment Client need to use an Ordinal comparison to Sort on 
             the field names to create the SHA256 Signature for validation of the message. 
             This class provides a Compare method that is used to allow the sorted list 
             to be ordered using an Ordinal comparison.
             </para>
             </remarks>
             */

            public int Compare(String a, String b)
            {
                /*
                 <summary>Compare method using Ordinal comparison</summary>
                 <param name="a">The first string in the comparison.</param>
                 <param name="b">The second string in the comparison.</param>
                 <returns>An int containing the result of the comparison.</returns>
                 */

                // Return if we are comparing the same object or one of the 
                // objects is null, since we don't need to go any further.
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;

                // Ensure we have string to compare
                string sa = a as string;
                string sb = b as string;

                // Get the CompareInfo object to use for comparing
                System.Globalization.CompareInfo myComparer = System.Globalization.CompareInfo.GetCompareInfo("en-US");
                if (sa != null && sb != null)
                {
                    // Compare using an Ordinal Comparison.
                    return myComparer.Compare(sa, sb, System.Globalization.CompareOptions.Ordinal);
                }
                throw new ArgumentException("a and b should be strings.");
            }
        }

        //______________________________________________________________________________
        // SHA256 Hash Code

        public string CreateSHA256Signature(bool useRequest)
        {
            // Hex Decode the Secure Secret for use in using the HMACSHA256 hasher
            // hex decoding eliminates this source of error as it is independent of the character encoding
            // hex decoding is precise in converting to a byte array and is the preferred form for representing binary values as hex strings. 
            byte[] convertedHash = new byte[_secureSecret.Length / 2];
            for (int i = 0; i < _secureSecret.Length / 2; i++)
            {
                convertedHash[i] = (byte)Int32.Parse(_secureSecret.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }

            // Build string from collection in preperation to be hashed
            StringBuilder sb = new StringBuilder();
            SortedList<String, String> list = (useRequest ? _requestFields : _responseFields);
            foreach (KeyValuePair<string, string> kvp in list)
            {
                if (kvp.Key.StartsWith("vpc_") || kvp.Key.StartsWith("user_"))
                    sb.Append(kvp.Key + "=" + kvp.Value + "&");
            }
            // remove trailing & from string
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            // Create secureHash on string
            string hexHash = "";
            using (HMACSHA256 hasher = new HMACSHA256(convertedHash))
            {
                byte[] hashValue = hasher.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                foreach (byte b in hashValue)
                {
                    hexHash += b.ToString("X2");
                }
            }
            return hexHash;
        }
    }
    public class ErrorGlobalPayment
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class CreateErrorGlobal
    {
        public List<ErrorGlobalPayment> errorGlobals()
        {
            List<ErrorGlobalPayment> errorGlobalPayments = new List<ErrorGlobalPayment>();
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "0", Message = "Giao dịch thành công." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "1", Message = "Giao dịch không thành công ,Ngân hàng phát hành thẻ không cấp phép.Vui lòng liên hệ ngân hàng" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "2", Message = "Giao dịch không thành công. Ngân hàng phát hành từ chối cấp phép, do 1 trong những nguyên nhân sau: Số dư không đủ thanh toán Chưa đăng ký dịch vụ thanh toán trực tuyến Ngày hết hạn" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "3", Message = "Giao dịch không thành công , Cổng thanh toán không nhận được kết quả trả về từ ngân hàng phát hành thẻ." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "4", Message = "Giao dịch không thành công. Thẻ hết hạn sử dụng" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "5", Message = "Giao dịch không thành công , Thẻ không đủ hạn mức hoặc tài khoản không đủ số dư thanh toán." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "6", Message = "Giao dịch không thành công, lỗi từ ngân hàng phát hành thẻ." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "7", Message = "Giao dịch không thành công, lỗi phát sinh trong quá trình xử lý giao dịch" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "8", Message = "Giao dịch không thành công, Ngân hàng phát hành thẻ không hỗ trợ giao dịch Internet" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "9", Message = "Giao dịch không thành công , Ngân hàng phát hành thẻ từ chối giao dịch." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "B", Message = "Giao dịch không thành công , không xác thực được 3DSecure. Liên hệ ngân hàng phát hành để được hỗ trợ." });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "E", Message = "Giao dịch không thành công. Bạn nhập sai CSC hoặc thẻ vượt quá hạn mức lần thanh toán" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "F", Message = "Giao dịch thất bại. Không xác thực được 3D" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "Z", Message = "Giao dịch không thành công, bị chặn bởi hệ thống ODF" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "Othercode", Message = "Giao dịch không thành công" });
            errorGlobalPayments.Add(new ErrorGlobalPayment { Code = "99", Message = "Giao dịch thất bại. Người dùng hủy giao dịch" });
            return errorGlobalPayments;
        }
    }
}
