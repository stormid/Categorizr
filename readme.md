# A Modern Device Detection Script

This is a .NET port of Categorizr, for background information see [http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/](http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/)

## Intallation

(eventually)

<pre>
PM> Install-Package Categorizr
</pre>

## Usage

<pre>
var categorizr = new Categorizr(CategorizrOptions.Default);

var deviceInfo = categorizr.Detect(HttpContext.Current.Request.UserAgent);
if (deviceInfo.IsMobile())
{
    // Do mobile stuff
}