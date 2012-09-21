using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is Windows Desktop
    /// </summary>
    public class WindowsDesktopCondition : DesktopConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return (Regex.IsMatch(useragent, "Windows.(NT|XP|ME|9)", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Phone", RegexOptions.IgnoreCase)) || (Regex.IsMatch(useragent, "Win(9|.9|NT)", RegexOptions.IgnoreCase));
        }
    }
}