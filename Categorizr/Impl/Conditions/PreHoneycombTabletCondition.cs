using System.Text.RegularExpressions;

namespace Categorizr.Impl.Conditions
{
    /// <summary>
    /// Check if user agent is a pre Android 3.0 Tablet
    /// TODO this doesn't make sense, either of the first two AND the last, or the first one OR both of the last two?
    /// </summary>
    public class PreHoneycombTabletCondition : TabletConditionBase
    {
        protected override bool MatchCore(string useragent)
        {
            return Regex.IsMatch(useragent, "GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "MB511", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "RUTEM", RegexOptions.IgnoreCase);
        }
    }
}