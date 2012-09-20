using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a Kindle or Kindle Fire
    /// </summary>
    public class KindleCondition : TabletConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "Kindle", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "Mac.OS", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "Silk", RegexOptions.IgnoreCase);
        }
    }
}