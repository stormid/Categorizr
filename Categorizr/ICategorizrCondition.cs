namespace Categorizr
{
    public interface ICategorizrCondition
    {
        DeviceCategory Category { get; }
        bool Match(string useragent);
    }
}