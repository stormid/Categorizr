using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a Tablet
    /// </summary>
    public class TabletCondition : TabletConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "iP(a|ro)d", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "tablet", RegexOptions.IgnoreCase) && !Regex.IsMatch(useragent, "RX-34", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "FOLIO", RegexOptions.IgnoreCase);
        }
    }
}