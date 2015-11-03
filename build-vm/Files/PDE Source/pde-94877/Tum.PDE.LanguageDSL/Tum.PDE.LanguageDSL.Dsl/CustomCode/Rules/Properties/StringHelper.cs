using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public class StringHelper
    {
        /// <summary>
        /// Inserts whitespaces between words that start with a big letter in a given text. Multiple big letters after one another
        /// are treated as one in the insert process.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string BreakUpper(string text)
        {
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(text, @"(\P{Lu}+)|(\p{Lu}+\P{Lu}*)");
            string ret = "";
            for (int i = 0; i < mc.Count; i++)
            {
                ret += " " + mc[i].ToString();
            }
            return ret.Trim();
        }
    }
}
