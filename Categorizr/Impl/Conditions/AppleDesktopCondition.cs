using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if agent is Mac Desktop
    /// </summary>
    public class AppleDesktopCondition : DesktopConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return (Regex.IsMatch(useragent, "Macintosh|PowerPC", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Silk", RegexOptions.IgnoreCase));
        }
    }
}