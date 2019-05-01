
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpType"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpTypeRow))]
    public class TbEmpTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpType/TbEmpTypeIndex.cshtml");
        }
    }
}