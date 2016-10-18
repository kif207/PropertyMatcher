using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DomainPropertyMatcher.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string RemovePunctuations(this string s)
        {
            return Regex.Replace(s, @"[\W_]", string.Empty);
        }

        public static string Reverse(this string s)
        {
            return string.Join(" ", s.Split(' ').Reverse());            
        }
    }
}
