using System;
using System.Configuration;
using System.Web;
using Categorizr;

namespace HttpRedirect
{
    public class RedirectModule : IHttpModule
    {
        private const string OverrideCookieName = "_mo";
        private readonly ICategorizr categorizr = new Categorizr.Impl.Categorizr();

        public void Init(HttpApplication context)
        {
            var mobileDomain = ConfigurationManager.AppSettings.Get("MobileSiteDomain");

            context.BeginRequest += (sender, args) =>
            {
                if (RequestHasOverrideCookie(context.Request))
                {
                    return;
                }

                var url = context.Request.Url;

                if (UrlHasOverride(url))
                {
                    SetResponseOverrideCookie(context.Response);
                    return;
                }

                if (IsMobile(context.Request))
                {
                    context.Response.Redirect(string.Format("{0}://{1}/{2}", url.Scheme, mobileDomain, url.PathAndQuery.TrimStart('/')), true);
                }
            };
        }

        private bool IsMobile(HttpRequest request)
        {
            return categorizr.Detect(request.UserAgent).IsMobile;
        }

        private static void SetResponseOverrideCookie(HttpResponse response)
        {
            var cookie = new HttpCookie(OverrideCookieName, "y");
            // TODO decide what to do here, session only? requires another override?
            cookie.Expires = DateTime.Today.AddDays(1);
            response.Cookies.Add(cookie);
        }

        private static bool UrlHasOverride(Uri url)
        {
            return url.Query.IndexOf("overrideMobile") > -1;
        }

        private static bool RequestHasOverrideCookie(HttpRequest request)
        {
            return request.Cookies[OverrideCookieName] != null;
        }

        public void Dispose()
        {
        }
    }
}