using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a Linux Desktop
    /// </summary>
    public class LinuxDesktopCondition : DesktopConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return (Regex.IsMatch(useragent, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "X11", RegexOptions.IgnoreCase));
        }
    }
}