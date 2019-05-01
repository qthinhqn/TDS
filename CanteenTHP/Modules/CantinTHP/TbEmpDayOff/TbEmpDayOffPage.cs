
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpDayOff"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpDayOffRow))]
    public class TbEmpDayOffController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpDayOff/TbEmpDayOffIndex.cshtml");
        }
    }
}