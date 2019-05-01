
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefLeaveType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefLeaveTypeRow))]
    public class TbRefLeaveTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefLeaveType/TbRefLeaveTypeIndex.cshtml");
        }
    }
}