
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefTypeRow))]
    public class TblRefTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefType/TblRefTypeIndex.cshtml");
        }
    }
}