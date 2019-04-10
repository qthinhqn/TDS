
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VLoSpKh"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VLoSpKhRow))]
    public class VLoSpKhController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VLoSpKh/VLoSpKhIndex.cshtml");
        }
    }
}