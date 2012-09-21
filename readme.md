# A Modern Device Detection Script

This is a .NET port of Categorizr, for background information see [http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/](http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/)

## Intallation

Install Categorizr using [NuGet](https://nuget.org/packages/Categorizr):
<pre>
PM> Install-Package Categorizr
</pre>

## Usage

<pre>
var categorizr = new Categorizr(CategorizrOptions.Default);

var deviceInfo = categorizr.Detect(HttpContext.Current.Request.UserAgent);
if (deviceInfo.IsMobile)
{
    // Do mobile stuff
}
</pre>

## Framework Support

The published NuGet package targets .NET Framework 2.0, so you can use this safely on older ASP.NET projects to redirect to your new MVC mobile site while you're busy making it responsive :o)

## Device Detection Bad!

I hear ya, but have a read of the article above. The approach Categorizr takes is to assume all devices are mobile unless the user agent suggests otherwise, which fits nicely with a mobile-first strategy. This works well because desktop user agents have been stable for some time and tablets are (generally) easy to identify. Any new unidentified devices will automatically end up in the mobile category without any updates.

## Device Categories

Categorizr splits devices into 4 categories:

* Desktop
* Tablet
* TV
* Mobile

You can optionally instruct it to treat Tablet and/or TV devices as desktop.