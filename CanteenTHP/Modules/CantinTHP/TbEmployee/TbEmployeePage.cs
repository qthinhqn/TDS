
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmployee"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmployeeRow))]
    public class TbEmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmployee/TbEmployeeIndex.cshtml");
        }
    }
}