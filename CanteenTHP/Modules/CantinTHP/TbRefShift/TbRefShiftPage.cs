
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefShift"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefShiftRow))]
    public class TbRefShiftController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefShift/TbRefShiftIndex.cshtml");
        }
    }
}