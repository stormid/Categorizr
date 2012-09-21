using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is unique Mobile User Agent
    /// </summary>
    public class UniqueMobileUserAgentCondition : MobileConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder", RegexOptions.IgnoreCase);
        }
    }
}