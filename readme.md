# A Modern Device Detection Script

This is a .NET port of Categorizr, for background information see [http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/](http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/)

## Intallation

(eventually)

<pre>
PM> Install-Package Categorizr
</pre>

## Usage

<pre>
var categorizr = new Categorizr(HttpContext.Current.Request.UserAgent);
categorizr.Detect();
var deviceCategory = categorizr.DeviceCategory;

if (categorizr.IsMobile())
{
    // Do mobile stuff
}