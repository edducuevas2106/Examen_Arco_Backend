using System.IO;
using System.Text.RegularExpressions;

namespace Logs.Extensions
{
    public static class StringExtensions
    {
        public static string InferSource(this string target)
        {
            return Path.GetFileNameWithoutExtension(target);
        }

        public static string ReviewLengthLog(this string target)
        {
            const short maxLogLength = 31839;
            return target.Length >= maxLogLength
                ? $"This log exceed the limit ({maxLogLength}) of the Event Log."
                : target;
        }

        public static bool OnlyHexInString(this string text)
        {
            return Regex.IsMatch(text, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}