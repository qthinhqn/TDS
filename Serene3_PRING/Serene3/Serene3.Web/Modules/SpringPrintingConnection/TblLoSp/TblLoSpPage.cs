
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblLoSp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblLoSpRow))]
    public class TblLoSpController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblLoSp/TblLoSpIndex.cshtml");
        }
    }
}