using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Helper.Core
{
   public static class RandomUtils
    {
        #region Int
        /// <summary>
        /// Trả về một số nguyên ngẫu nhiên không âm.
        /// </summary>
        /// <returns>Trả về một số nguyên ngẫu nhiên không âm.</returns>
        public static int RandomInt()
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            int result = random.Next();
            return result;
        }

        /// <summary>
        /// Trả về một số nguyên ngẫu nhiên không âm.
        /// Giá trị nằm trong khoảng từ 0 - maxValue.
        /// </summary>
        /// <param name="maxValue">
        /// Giá trị ngẫu nhiên lớn nhất. Giá trị này cần >= 0
        /// </param>
        /// <returns>Trả về một số nguyên ngẫu nhiên không âm.</returns>
        public static int RandomInt(int maxValue)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            int result = random.Next(maxValue);
            return result;
        }

        /// <summary>
        /// Trả về một số nguyên ngẫu nhiên không âm.
        /// Giá trị nằm trong khoảng từ minValue - maxValue
        /// </summary>
        /// <param name="minValue">
        /// Giá trị ngẫu nhiên nhỏ nhất. Giá trị này cần >= 0
        /// </param>
        /// <param name="maxValue">
        /// Giá trị ngẫu nhiên lớn nhất. Giá trị này cần >= minValue
        /// </param>
        /// <returns>Trả về một số nguyên ngẫu nhiên không âm.</returns>
        public static int RandomInt(int minValue, int maxValue)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            int result = random.Next(minValue, maxValue);
            return result;
        }
        #endregion

        #region Double
        /// <summary>
        /// Trả về một số thập phân ngẫu nhiên không âm.
        /// </summary>
        /// <returns>Trả về một số thập phân ngẫu nhiên không âm.</returns>
        public static double RandomDouble()
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            double result = random.NextDouble();
            return result;
        }

        /// <summary>
        /// Trả về một số thập phân ngẫu nhiên không âm.
        /// Giá trị nằm trong khoảng từ minValue - maxValue.
        /// </summary>
        /// <param name="minValue">
        /// Giá trị ngẫu nhiên nhỏ nhất. Giá trị này cần >= 0.
        /// </param>
        /// <param name="maxValue">
        /// Giá trị ngẫu nhiên lớn nhất. Giá trị này cần >= minValue.
        /// </param>
        /// <returns>Trả về một số thập phân ngẫu nhiên không âm.</returns>
        public static double RandomDouble(double minValue, double maxValue)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            double result = (maxValue - minValue) * random.NextDouble() + minValue;
            return result;
        }

        /// <summary>
        /// Trả về một số thập phân ngẫu nhiên không âm.
        /// Giá trị nằm trong khoảng từ 0 - maxValue.
        /// </summary>
        /// <param name="maxValue">
        /// Giá trị ngẫu nhiên lớn nhất. Giá trị này cần >= 0
        /// </param>
        /// <returns>Trả về một số thập phân ngẫu nhiên không âm.</returns>
        public static double RandomDouble(double maxValue)
        {
            return RandomDouble(0, maxValue);
        }
        #endregion

        #region String
        /// <summary>
        /// Trả về một chuỗi ngẫu nhiên có chiều dài nằm trong khoảng minLength - maxLength
        /// Chuỗi có thể chứa các loại ký tự gồm: chữ cái [a-z], số [0-9] và ký tự đặc biệt [!@#$&].
        /// </summary>
        /// <param name="minLength">
        /// Chiều dài tối thiểu của chuỗi. Giá trị này cần >= 0
        /// </param>
        /// <param name="maxLength">
        /// Chiều dài tối đa của chuỗi. Giá trị này cần >= minLength.
        /// </param>
        /// <param name="hasLetters">
        /// True: có chứa chữ cái; False: không chứa chữ cái.
        /// </param>
        /// <param name="hasNumbers">
        /// True: có chứa số; False: không chứa số.
        /// </param>
        /// <param name="hasSymbols">
        /// True: có chứa ký tự đặc biệt; False: không chứa ký tự đặc biệt.
        /// </param>
        /// <returns>Trả về một chuỗi ngẫu nhiên.</returns>
        public static string RandomString(int minLength, int maxLength, bool hasLetters, bool hasNumbers, bool hasSymbols)
        {
            //Kiểm tra tính hợp lệ của chiều dài chuỗi cần sinh ra
            if (maxLength < minLength)
                return string.Empty;

            string letters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "!@#$&";
            string fullChars = string.Empty;

            if (hasLetters)
                fullChars += letters;

            if (hasNumbers)
                fullChars += numbers;

            if (hasSymbols)
                fullChars += symbols;

            //Kiểm tra tính hợp lệ
            if (fullChars == string.Empty)
                return string.Empty;

            //Khởi tạo chiều dài của chuỗi có số lượng ký tự là ngẫu nhiên nằm trong khoảng minLength và maxLength
            int length = RandomInt(minLength, maxLength);
            if (maxLength == minLength)
                length = maxLength;

            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int minIndex = 0;
                int maxIndex = fullChars.Length - 1;
                int index = RandomInt(minIndex, maxIndex);

                result += fullChars[index];
            }

            return result;
        }

        /// <summary>
        /// Trả về một chuỗi ngẫu nhiên có chiều dài nằm trong khoảng minLength - maxLength
        /// Chuỗi có thể chứa các loại ký tự gồm: chữ cái [a-z], số [0-9] và ký tự đặc biệt [!@#$&].
        /// </summary>
        /// <param name="minLength">
        /// Chiều dài tối thiểu của chuỗi. Giá trị này cần >= 0
        /// </param>
        /// <param name="maxLength">
        /// Chiều dài tối đa của chuỗi. Giá trị này cần >= minLength.
        /// </param>
        /// <returns>Trả về một chuỗi ngẫu nhiên.</returns>
        public static string RandomString(int minLength, int maxLength)
        {
            return RandomString(minLength, maxLength, true, true, true);
        }

        /// <summary>
        /// Trả về một chuỗi ngẫu nhiên có chiều dài nằm trong khoảng 1 - maxLength
        /// Chuỗi có thể chứa các loại ký tự gồm: chữ cái [a-z], số [0-9] và ký tự đặc biệt [!@#$&].
        /// </summary>
        /// <param name="maxLength">
        /// Chiều dài tối đa của chuỗi. Giá trị này cần >= minLength.
        /// </param>
        /// <returns>Trả về một chuỗi ngẫu nhiên.</returns>
        public static string RandomString(int maxLength)
        {
            return RandomString(1, maxLength, true, true, true);
        }
        #endregion

        #region Password
        /// <summary>
        /// Trả về một chuỗi mật mã ngẫu nhiên có chiều dài nằm trong khoảng minLength - maxLength.
        /// </summary>
        /// <param name="minLength">
        /// Chiều dài tối thiểu của chuỗi. Giá trị này cần >= 0
        /// </param>
        /// <param name="maxLength">
        /// Chiều dài tối đa của chuỗi. Giá trị này cần >= minLength.
        /// </param>
        /// <returns>Trả về một chuỗi mật mã ngẫu nhiên.</returns>
        public static string RandomPassword(int minLength, int maxLength)
        {
            //1. Khai báo đối tượng hỗ trợ tạo giá trị mật mã
            RNGCryptoServiceProvider password = new RNGCryptoServiceProvider();
            //2. Khai báo chiều dài của mật mã (ngẫu nhiên trong khoảng minLength-maxLength)
            int length = RandomInt(minLength, maxLength);
            //3. Tạo một mảng byte dùng để chứa mật mã
            byte[] byteArray = new byte[length];
            //4. Tạo một mật mã ngẫu nhiên - nhưng không cho phép chứa giá trị Zero
            password.GetNonZeroBytes(byteArray);
            //5. Chuyển mật mã đã tạo về dạng chuỗi
            string result = BitConverter.ToString(byteArray);
            //6. Gỡ bỏ dấu - có trong mật mã
            result = result.Replace("-", string.Empty);
            //7. Trả về kết quả
            return result;
        }

        /// <summary>
        /// Trả về một chuỗi mật mã ngẫu nhiên có chiều dài nằm trong khoảng 1 - maxLength.
        /// </summary>
        /// <param name="maxLength">
        /// Chiều dài tối đa của chuỗi. Giá trị này cần >= minLength.
        /// </param>
        /// <returns>Trả về một chuỗi mật mã ngẫu nhiên.</returns>
        public static string RandomPassword(int maxLength)
        {
            return RandomPassword(1, maxLength);
        }
        #endregion

        #region ID
        /// <summary>
        /// Phát sinh một ID ngẫu nhiên không trùng lắp. ID có dạng [605ed2f95327417987f1c6551096cf2e] với 32 ký tự.
        /// </summary>
        /// <returns>Phát sinh một ID ngẫu nhiên không trùng lắp.</returns>
        public static string RandomID()
        {
            //1. Tạo một ID ngẫu nhiên không trùng lắp
            string ID = Guid.NewGuid().ToString();
            //2. Gỡ bỏ các dấu - có trong ID
            ID = ID.Replace("-", string.Empty);
            //3. Trả về kết quả
            return ID;
        }
        #endregion
    }
}
