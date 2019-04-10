
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblLenChuyen"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblLenChuyenRow))]
    public class TblLenChuyenController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblLenChuyen/TblLenChuyenIndex.cshtml");
        }
    }
}