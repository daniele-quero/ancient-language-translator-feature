using System.Text.RegularExpressions;

namespace AncientLanguageUtils
{
    public class CoverText
    {
        public static string CoverTextWith(string text, string x)
        {
            return Regex.Replace(text, "([A-Za-z0-9])", x);
        }
    }
}