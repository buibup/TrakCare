using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrakCare.Web.Models;

namespace TrakCare.Web.Common
{
    public class Helper
    {
        const int constant = 37;
        public static bool CheckPassword(User user, string password)
        {
            var flag = user.SSUSR_Password == TrakCareEnCryptPass(password) ? true : false;

            return flag;
        }

        private static string TrakCareEnCryptPass(string pass)
        {
            int piece = 0;
            string result = string.Empty;

            foreach (char c in pass)
            {
                result += EnCryptAscii(c, piece);

                piece++;
            }

            var len = result.Length;
            for (piece = len + 1; piece <= 12; piece++)
            {
                result += EnCryptToResult(result.Substring(piece - 1 - len, 1));
            }

            return result;
        }
        private static string EnCryptAscii(char c, int piece)
        {
            decimal num;
            string result = c.ToString();

            switch (c)
            {
                case 'D':
                    result = ((char)2).ToString();
                    break;
                case 'P':
                    result = ((char)3).ToString();
                    break;
                case 'd':
                    result = ((char)4).ToString();
                    break;
                case 't':
                    result = ((char)5).ToString();
                    break;
                default:
                    break;
            }

            num = Encoding.ASCII.GetBytes(result)[0];
            num = (num - (piece + 1) + constant) % 255;

            result = EnCryptChar(num);

            return result;
        }
        private static string EnCryptChar(decimal num)
        {
            string result = string.Empty;

            if (num > 127)
                num = (num + 128) % 255;
            if (num < 32)
                num = (num + 40) % 255;
            if ((char)(num) == '^')
                num = num + 1;

            result = ((char)(num % 255)).ToString();

            return result;
        }
        private static string EnCryptToResult(string s)
        {
            decimal num;
            string result = string.Empty;

            num = Encoding.ASCII.GetBytes(s)[0];
            num = (decimal)((double)num * 2.345 * constant * (constant - 7)) % 255;
            num = Math.Truncate(num);

            result = EnCryptChar(num);

            return result;
        }
    }
}
