
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefRegistrationType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefRegistrationTypeRow))]
    public class TbRefRegistrationTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefRegistrationType/TbRefRegistrationTypeIndex.cshtml");
        }
    }
}