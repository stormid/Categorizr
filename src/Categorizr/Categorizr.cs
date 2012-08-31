using System.Text.RegularExpressions;

namespace Categorizr
{
    public class Categorizr
    {
        private string useragent;
        private bool hasDetected;
        private DeviceCategory detected;

        public static bool CategorizeTabletsAsDesktops { get; set; }
        public static bool CategorizeTvsAsDesktops { get; set; }

        static Categorizr()
        {
            CategorizeTabletsAsDesktops = false;
            CategorizeTvsAsDesktops = false;
        }

        public Categorizr() { }

        public Categorizr(string useragent)
        {
            UserAgent = useragent;
        }

        public string UserAgent
        {
            get { return useragent; }
            set
            {
                useragent = value;
                hasDetected = false;
            }
        }

        public DeviceCategory DetectedCategory 
        {
            get
            {
                if (!hasDetected)
                {
                    Detect();
                }
                return detected; 
            }
            private set { detected = value; }
        }

        public bool IsMobile { get { return DetectedCategory == DeviceCategory.Mobile; } }

        public bool IsTablet { get { return DetectedCategory == DeviceCategory.Tablet; } }

        public bool IsDesktop { get { return DetectedCategory == DeviceCategory.Desktop; } }

        public bool IsTv { get { return DetectedCategory == DeviceCategory.Tv; } }

        public void Detect()
        {
            if (hasDetected)
            {
                return;
            }

            // Check if user agent is a smart TV - http://goo.gl/FocDk
            if (Regex.IsMatch(useragent, "GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\\-HTML", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tv;
            }

            // Check if user agent is a TV Based Gaming Console
            else if (Regex.IsMatch(useragent, "Xbox|PLAYSTATION.3|Wii", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tv;
            }

            // Check if user agent is a Tablet
            else if (Regex.IsMatch(useragent, "iP(a|ro)d", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "tablet", RegexOptions.IgnoreCase) && !Regex.IsMatch(useragent, "RX-34", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "FOLIO", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tablet;
            }

            // Check if user agent is an Android Tablet
            else if (Regex.IsMatch(useragent, "Linux", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "Android", RegexOptions.IgnoreCase) && !Regex.IsMatch(useragent, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tablet;
            }
    
            // Check if user agent is a Kindle or Kindle Fire
            else if (Regex.IsMatch(useragent, "Kindle", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "Mac.OS", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "Silk", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tablet;
            }
    
            // Check if user agent is a pre Android 3.0 Tablet
            // TODO this doesn't make sense, either of the first two AND the last, or the first one OR both of the last two?
            else if (Regex.IsMatch(useragent, "GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase) || Regex.IsMatch(useragent, "MB511", RegexOptions.IgnoreCase) && Regex.IsMatch(useragent, "RUTEM", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Tablet;
            }
    
            // Check if user agent is unique Mobile User Agent
            else if (Regex.IsMatch(useragent, "BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder", RegexOptions.IgnoreCase))
            {
                DetectedCategory = DeviceCategory.Mobile;
            }
    
            // Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
            else if ((Regex.IsMatch(useragent, "Opera", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "Windows.NT.5", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "HTC|Xda|Mini|Vario|SAMSUNG\\-GT\\-i8000|SAMSUNG\\-SGH\\-i9", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Mobile;
            }
    
            // Check if user agent is Windows Desktop
            else if ((Regex.IsMatch(useragent, "Windows.(NT|XP|ME|9)", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Phone", RegexOptions.IgnoreCase)) || (Regex.IsMatch(useragent, "Win(9|.9|NT)", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // Check if agent is Mac Desktop
            else if ((Regex.IsMatch(useragent, "Macintosh|PowerPC", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Silk", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // Check if user agent is a Linux Desktop
            else if ((Regex.IsMatch(useragent, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(useragent, "X11", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // Check if user agent is a Solaris, SunOS, BSD Desktop
            else if ((Regex.IsMatch(useragent, "Solaris|SunOS|BSD", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // Check if user agent is a Desktop BOT/Crawler/Spider
            else if ((Regex.IsMatch(useragent, "Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(useragent, "Mobile", RegexOptions.IgnoreCase)))
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // Otherwise assume it is a Mobile Device
            else
            
            {
                DetectedCategory = DeviceCategory.Mobile;
            }

            hasDetected = true;

            // If we categorize tablets as desktops
            if (CategorizeTabletsAsDesktops && DetectedCategory == DeviceCategory.Tablet)
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
    
            // If we categorize tvs as desktops
            if (CategorizeTvsAsDesktops && DetectedCategory == DeviceCategory.Tv)
            {
                DetectedCategory = DeviceCategory.Desktop;
            }
        }
    }

    public enum DeviceCategory
    {
        Desktop,
        Tablet,
        Mobile,
        Tv
    }
}