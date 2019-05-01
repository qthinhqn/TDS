
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpManager"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpManagerRow))]
    public class TbEmpManagerController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpManager/TbEmpManagerIndex.cshtml");
        }
    }
}