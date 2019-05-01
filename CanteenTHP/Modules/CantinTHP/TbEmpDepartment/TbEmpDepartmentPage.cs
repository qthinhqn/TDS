
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpDepartment"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpDepartmentRow))]
    public class TbEmpDepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpDepartment/TbEmpDepartmentIndex.cshtml");
        }
    }
}