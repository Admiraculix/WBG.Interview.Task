using System.Text.RegularExpressions;

namespace WBG.BiscuitMachine.ConsoleSimulator.Extensions;
public static class StringExtensions
{
    public static string ReplaceEmojisWithFallback(this string input, float versionThreshold)
    {
        // Check if the provided version is equal to or greater than the threshold
        if (versionThreshold > 10)
        {
            // If the version is equal to or greater than the threshold, do not replace emojis
            return input;
        }

        // Define a regular expression pattern to match emojis
        string emojiPattern = @"[\uD800-\uDFFF]|[\u2000-\u3300]|\uD83C[\uDF00-\uDFFF]|\uD83D[\uDC00-\uDDFF]";

        // Replace emojis with fallback text
        string fallbackText = "*";
        string result = Regex.Replace(input, emojiPattern, fallbackText);

        return result;
    }
}
