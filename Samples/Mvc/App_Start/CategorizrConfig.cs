using System.Web.WebPages;

namespace Mvc
{
    public class CategorizrConfig
    {
        public static void Register(DisplayModeProvider instance)
        {
            var categorizr = new Categorizr.Impl.Categorizr();

            instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
                {
                    ContextCondition = c => categorizr.Detect(c.GetOverriddenUserAgent()).IsMobile
                });

            instance.Modes.Insert(1, new DefaultDisplayMode("Tablet")
                {
                    ContextCondition = c => categorizr.Detect(c.GetOverriddenUserAgent()).IsTablet
                });
            
            instance.Modes.Insert(2, new DefaultDisplayMode("TV")
                {
                    ContextCondition = c => categorizr.Detect(c.GetOverriddenUserAgent()).IsTv
                });
        }
    }
}