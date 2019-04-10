
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblFeStockOutInfo"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblFeStockOutInfoRow))]
    public class TblFeStockOutInfoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblFeStockOutInfo/TblFeStockOutInfoIndex.cshtml");
        }
    }
}