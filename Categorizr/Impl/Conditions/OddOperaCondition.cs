using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
    /// </summary>
    public class OddOperaCondition : MobileConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return (Regex.IsMatch(useragent, "Opera", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "Windows.NT.5", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "HTC|Xda|Mini|Vario|SAMSUNG\\-GT\\-i8000|SAMSUNG\\-SGH\\-i9", RegexOptions.IgnoreCase));
        }
    }
}