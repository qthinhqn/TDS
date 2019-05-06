
namespace Canteen.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Administration/RoleSelection"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.RoleSelectionRow))]
    public class RoleSelectionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Administration/RoleSelection/RoleSelectionIndex.cshtml");
        }
    }
}