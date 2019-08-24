using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Common
{
    public class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">待检查的字符串</param>
        /// <param name="regex">对应的正则表达式</param>
        /// <returns></returns>
        static bool CheckBase(string str, string regex)
        {
            bool check = true;
            if (str != "")
            {
                if (!Regex.IsMatch(str, regex))
                    check = false;
            }

            return check;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">待检查的字符串</param>
        /// <param name="regex">对应的正则表达式</param>
        /// <param name="str_length">字符串的限定长度</param>
        /// <returns></returns>
        static bool CheckBase(string str, string regex, int str_length)
        {
            if (str.Length == str_length && CheckBase(str, regex))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查手机号是否符合规范
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CheckMobilePhone(string phone)
        {
            return CheckBase(phone, @"13[0123456789]\d{8}|15[0123456789]\d{8}|18[0123456789]\d{8}/", 11);
        }

        /// <summary>
        /// 检查 E-mail 格式是否符合规范
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            return CheckBase(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 检查 QQ 号码是否符合规范
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool CheckQQ(string QQ)
        {
            return CheckBase(QQ, @"^[1-9]*[1-9][0-9]*$");
        }

        /// <summary>
        /// 检查固定电话是否符合规范
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool CheckPhone(string phone)
        {
            return CheckBase(phone, @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
        }
    }
}
