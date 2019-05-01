
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpShift"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpShiftRow))]
    public class TbEmpShiftController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpShift/TbEmpShiftIndex.cshtml");
        }
    }
}