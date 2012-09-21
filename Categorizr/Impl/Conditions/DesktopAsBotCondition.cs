using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a Desktop BOT/Crawler/Spider
    /// </summary>
    public class DesktopAsBotCondition : DesktopConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return
                (Regex.IsMatch(useragent,
                               "Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye",
                               RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Mobile", RegexOptions.IgnoreCase));
        }
    }
}