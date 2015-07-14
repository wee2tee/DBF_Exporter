using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBF_Exporter.MiscClass
{
    public static class Clean
    {
        public static string cleanString(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '!' && c <= '~') || (c >= 'ก' && c <= '๙') || (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || char.IsWhiteSpace(c) || c == ' ' || c == '\\' || c == '\"' || c == '\'')
                {
                    sb.Append(c);
                }
            }
            
            string s0 = sb.ToString();

            string s1 = s0.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace(" ", " ");

            return s1;
        }
            
    }
}
