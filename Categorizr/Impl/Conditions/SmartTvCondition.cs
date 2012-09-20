using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a smart TV - http://goo.gl/FocDk
    /// </summary>
    public class SmartTvCondition : SmartTvConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\\-HTML", RegexOptions.IgnoreCase);
        }
    }
}