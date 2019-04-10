
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefStyle"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefStyleRow))]
    public class TblRefStyleController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefStyle/TblRefStyleIndex.cshtml");
        }
    }
}