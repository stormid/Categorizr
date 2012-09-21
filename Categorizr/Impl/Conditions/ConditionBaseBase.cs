namespace Categorizr.Impl.Conditions
{
    public abstract class ConditionBaseBase : ICategorizrCondition
    {
        public abstract DeviceCategory Category { get; }

        public bool Match(string useragent)
        {
            return MatchCore(useragent);
        }

        protected abstract bool MatchCore(string useragent);
    }
}