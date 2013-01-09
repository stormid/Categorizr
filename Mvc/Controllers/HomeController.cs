using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
         public ViewResult Index()
         {
             return View();
         }
    }
}