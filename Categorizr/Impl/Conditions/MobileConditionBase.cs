namespace Categorizr.Impl.Conditions
{
    public abstract class MobileConditionBase : ConditionBaseBase
    {
        public override DeviceCategory Category
        {
            get { return DeviceCategory.Mobile; }
        }
    }
}