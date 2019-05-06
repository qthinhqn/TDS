
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/VEmployeeSelection"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VEmployeeSelectionRow))]
    public class VEmployeeSelectionController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/VEmployeeSelection/VEmployeeSelectionIndex.cshtml");
        }
    }
}