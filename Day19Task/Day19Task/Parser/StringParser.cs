using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19Task
{
    class StringParser : IParser
    {
        /// <summary>
        /// Get host from url
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public string GetHost(string str)
        {
            Check(str);
            str = str.Replace("https://", "");

            return str.Split('/').First();
        }

        /// <summary>
        /// Get parameters from url
        /// </summary>
        /// <param name="str"></param>
        /// <returns>array of strings</returns>
        public string[] GetParameters(string str)
        {
            Check(str);
            if (!str.Contains('?'))
            {
                return new string[0];
            }
            string parameters = str.Split('?').Last();

            return parameters.Split('&');
        }

        /// <summary>
        /// Get segments from url
        /// </summary>
        /// <param name="str"></param>
        /// <returns>array of strings</returns>
        public string[] GetSegments(string str)
        {
            Check(str);
            str = str.Replace("https://", "");
            str = str.Replace(str.Split('/').First(), "");

            if (str.Contains('?'))
            {
                str = str.Remove(str.IndexOf('?'));
            }

            return str.Split('/');
        }

        private void Check(string str)
        {
            if (!Regex.IsMatch(str.TrimStart(), @"^(http[s]{0,1}://|[\\]{2})(?:[\w][\w.-]?)+"))
            {
                throw new FormatException("Format of url is incorrect");
            }
        }
    }
}
