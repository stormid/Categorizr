using System.Collections.Generic;
using Categorizr.Impl;
using Categorizr.Impl.Conditions;

namespace Categorizr
{
    public class CategorizrOptions
    {
        public bool CategorizeTabletsAsDesktops { get; set; }
        public bool CategorizeTvsAsDesktops { get; set; }

        public List<ICategorizrCondition> Conditions { get; set; }

        public static List<ICategorizrCondition> DefaultConditions = new List<ICategorizrCondition>
                                                                         {
                                                                             new SmartTvCondition(),
                                                                             new ConsoleCondition(),
                                                                             new TabletCondition(),
                                                                             new AndroidTabletCondition(),
                                                                             new KindleCondition(),
                                                                             new PreHoneycombTabletCondition(),
                                                                             new UniqueMobileUserAgentCondition(),
                                                                             new OddOperaCondition(),
                                                                             new WindowsDesktopCondition(),
                                                                             new AppleDesktopCondition(),
                                                                             new LinuxDesktopCondition(),
                                                                             new SolarisDesktopCondition(),
                                                                             new DesktopAsBotCondition()
                                                                         };

        public CategorizrOptions()
        {
            Conditions = DefaultConditions;
        }

        public static CategorizrOptions Default
        {
            get
            {
                return new CategorizrOptions
                {
                    CategorizeTabletsAsDesktops = false,
                    CategorizeTvsAsDesktops = false,
                };
            }
        }
    }
}