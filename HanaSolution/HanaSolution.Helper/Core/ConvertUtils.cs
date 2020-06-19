using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Helper.Core
{
   public static class ConvertUtils
    {
        #region ToStringSafe
        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <param name="isTrim">
        /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
        /// True: có cắt khoảng trắng ở 2 đầu;
        /// False: không cắt khoảng trắng ở 2 đầu
        /// </param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static string ToStringSafe(this object value, string defaultValue, bool isTrim)
        {
            //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
            if (value == null)
                return defaultValue;

            //Chuyển sang kiểu chuổi
            string convertedValue = value.ToString();

            //Cắt khoảng trắng nếu có thiết lập isTrim
            if (isTrim)
                convertedValue = convertedValue.Trim();

            //Trả về giá trị đã được chuyển đổi kiểu
            return convertedValue;
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
        /// </returns>
        public static string ToStringSafe(this object value, string defaultValue)
        {
            return ToStringSafe(value, defaultValue, false);
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <param name="isTrim">
        /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
        /// True: có cắt khoảng trắng ở 2 đầu;
        /// False: không cắt khoảng trắng ở 2 đầu
        /// </param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi, có tùy chọn cắt khoảng trắng ở 2 đầu
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </returns>
        public static string ToStringSafe(this object value, bool isTrim)
        {
            return ToStringSafe(value, string.Empty, isTrim);
        }

        /// <summary>
        /// Chuyển đổi sang kiểu chuỗi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </summary>
        /// <param name="value">Dữ liệu cần chuyển đổi</param>
        /// <returns>
        /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
        /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
        /// </returns>
        public static string ToStringSafe(this object value)
        {
            return ToStringSafe(value, string.Empty, false);
        }
        #endregion
    }
}
