using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a Solaris, SunOS, BSD Desktop
    /// </summary>
    public class SolarisDesktopCondition : DesktopConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return (Regex.IsMatch(useragent, "Solaris|SunOS|BSD", RegexOptions.IgnoreCase));
        }
    }
}