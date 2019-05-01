
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/VEmployeeInfoCurrent"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VEmployeeInfoCurrentRow))]
    public class VEmployeeInfoCurrentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/VEmployeeInfoCurrent/VEmployeeInfoCurrentIndex.cshtml");
        }
    }
}