
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblBo_BTP"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblBo_BTPRow))]
    public class TblBo_BTPController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblBo_BTP/TblBo_BTPIndex.cshtml");
        }
    }
}