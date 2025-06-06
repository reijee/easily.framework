﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.tools.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Left([NotNull] this string str, int len)
        {
            if (str.Length < len) return str;

            return str.Substring(0, len);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Right([NotNull] this string str, int len)
        {
            if (str.Length < len) if (str.Length < len) return str;

            return str.Substring(str.Length - len, len);
        }
    }
}
