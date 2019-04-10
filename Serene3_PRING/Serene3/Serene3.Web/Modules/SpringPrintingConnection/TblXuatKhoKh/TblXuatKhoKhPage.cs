
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuatKhoKh"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuatKhoKhRow))]
    public class TblXuatKhoKhController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuatKhoKh/TblXuatKhoKhIndex.cshtml");
        }
    }
}