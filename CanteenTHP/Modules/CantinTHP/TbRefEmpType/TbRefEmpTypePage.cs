
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefEmpType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefEmpTypeRow))]
    public class TbRefEmpTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefEmpType/TbRefEmpTypeIndex.cshtml");
        }
    }
}