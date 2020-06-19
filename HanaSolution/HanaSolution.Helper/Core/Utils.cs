using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace HanaSolution.Helper.Core
{
    public static class Utils
    {
        private static string pathFile = HttpContext.Current.Server.MapPath("/Logs/log.txt");
        public static void WriteLogToFile(string content)
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    using (StreamWriter sw = File.AppendText(pathFile))
                    {
                        sw.WriteLine(content);
                    }
                }
            }
            catch (Exception)
            {
                if (!File.Exists(pathFile))
                {
                    using (StreamWriter sw = File.CreateText(pathFile))
                    {
                        sw.WriteLine(content);
                    }
                }
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine(content);
                }
            }
        }

        public static string UrlDecode(this string value)
        {
            return WebUtility.UrlDecode(value);
        }
        public static string UrlEncode(this string value)
        {
            return WebUtility.UrlEncode(value);
        }
        public static string ToNoSings(this string value, bool removeDoubleSpace = true)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            value = value.ToStringSafe();
            value = value.Normalize(NormalizationForm.FormD);
            value = regex.Replace(value, String.Empty);
            value = value.Replace('\u0111', 'd').Replace('\u0110', 'D');
            if (removeDoubleSpace)
                value = value.RemoveDoubleSpace();
            return value;
        }
        public static string ToUrlFormat(this string value, bool removeSign = true, bool lowerCase = true)
        {
            //1. Chuyển chuỗi về dạng chuỗi không Null
            value = value.ToStringSafe();
            //2. Gỡ toàn bộ dấu nếu cần
            if (removeSign)
                value = value.ToNoSings(true);
            //3. Định nghĩa một danh sách các ký tự đặc biệt
            string specialChar = "@#$%^&()+-*/\\={}[]|:;'\"`“”<>.,?!_~";
            //4. Loại bỏ các ký tự đặc biệt
            foreach (char item in specialChar.ToCharArray())
            {
                value = value.Replace(item, ' ');
            }
            //5. Loại bỏ khoảng trắng kép
            value = value.RemoveDoubleSpace();
            //6. Chuyển đổi kiểu chữ hoa - thường
            if (lowerCase)
                value = value.ToLowerCase(true);
            else
                value = value.ToUpperCase(true);
            //7. Thay khoảng trắng bằng dấu gạch ngang (-)
            value = value.Replace(' ', '-');
            //8. Loại bỏ dấu gạch ngang ở 2 đầu văn bản
            value = value.Trim('-');
            //9. Trả về kết quả
            return value;
        }
        public static string ToUpperCase(this string value, bool removeDoubleSpace = true)
        {
            value = value.ToStringSafe();
            value = value.ToUpper();

            if (removeDoubleSpace)
                value = value.RemoveDoubleSpace();
            return value;
        }
        public static string ToLowerCase(this string value, bool removeDoubleSpace = true)
        {
            value = value.ToStringSafe();
            value = value.ToLower();

            if (removeDoubleSpace)
                value = value.RemoveDoubleSpace();
            return value;
        }
        public static string RemoveDoubleSpace(this string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}
