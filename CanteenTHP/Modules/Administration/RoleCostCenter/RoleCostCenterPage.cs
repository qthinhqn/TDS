
namespace Canteen.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Administration/RoleCostCenter"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.RoleCostCenterRow))]
    public class RoleCostCenterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Administration/RoleCostCenter/RoleCostCenterIndex.cshtml");
        }
    }
}