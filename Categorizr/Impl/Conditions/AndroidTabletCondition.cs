using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is an Android Tablet
    /// </summary>
    public class AndroidTabletCondition : TabletConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "Linux", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "Android", RegexOptions.IgnoreCase) && !Regex.IsMatch(useragent, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase);
        }
    }
}