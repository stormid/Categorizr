namespace Categorizr.Impl.Conditions
{
    public abstract class SmartTvConditionBase : ConditionBaseBase
    {
        public override DeviceCategory Category
        {
            get { return DeviceCategory.Tv; }
        }
    }
}