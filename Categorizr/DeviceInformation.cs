namespace Categorizr
{
    public class DeviceInformation
    {
        public DeviceInformation(DeviceCategory category)
        {
            Category = category;
        }

        public DeviceCategory Category { get; private set; }

        public bool IsMobile { get { return Category == DeviceCategory.Mobile; } }

        public bool IsTablet { get { return Category == DeviceCategory.Tablet; } }

        public bool IsDesktop { get { return Category == DeviceCategory.Desktop; } }

        public bool IsTv { get { return Category == DeviceCategory.Tv; } }
    }
}