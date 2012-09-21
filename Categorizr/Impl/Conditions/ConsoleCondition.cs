using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a TV Based Gaming Console
    /// </summary>
    public class ConsoleCondition : SmartTvConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "Xbox|PLAYSTATION.3|Wii", RegexOptions.IgnoreCase);
        }
    }
}