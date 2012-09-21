namespace Categorizr.Impl
{
    public class Categorizr : ICategorizr
    {
        private readonly CategorizrOptions options;

        public Categorizr() : this(CategorizrOptions.Default)
        {
        }

        public Categorizr(CategorizrOptions options)
        {
            this.options = options;
        }

        public DeviceInformation Detect(string useragent)
        {
            var category = DeviceCategory.Mobile;

            foreach (var condition in options.Conditions)
            {
                if (!condition.Match(useragent)) continue;

                category = condition.Category;
                break;
            }

            // If we categorize tablets or Tvs as desktops
            if (TabletAsDesktop(category) || TvsAsDesktop(category))
            {
                category = DeviceCategory.Desktop;
            }

            return new DeviceInformation(category);
        }

        private bool TvsAsDesktop(DeviceCategory category)
        {
            return options.CategorizeTvsAsDesktops && category == DeviceCategory.Tv;
        }

        private bool TabletAsDesktop(DeviceCategory category)
        {
            return options.CategorizeTabletsAsDesktops && category == DeviceCategory.Tablet;
        }
    }
}