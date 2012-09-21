namespace Categorizr.Impl.Conditions
{
    public abstract class DesktopConditionBase : ConditionBaseBase
    {
        public override DeviceCategory Category
        {
            get { return DeviceCategory.Desktop; }
        }
    }
}