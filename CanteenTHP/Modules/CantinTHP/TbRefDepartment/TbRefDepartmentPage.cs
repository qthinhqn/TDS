
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefDepartment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefDepartmentRow))]
    public class TbRefDepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefDepartment/TbRefDepartmentIndex.cshtml");
        }
    }
}