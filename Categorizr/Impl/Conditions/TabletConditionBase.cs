namespace Categorizr.Impl.Conditions
{
    public abstract class TabletConditionBase : ConditionBaseBase
    {
        public override DeviceCategory Category
        {
            get { return DeviceCategory.Tablet; }
        }
    }
}