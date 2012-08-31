namespace Categorizr
{
    public interface ICategorizr
    {
        DeviceInformation Detect(string useragent);
    }
}