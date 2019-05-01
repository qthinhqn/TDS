
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbPrintTicket"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbPrintTicketRow))]
    public class TbPrintTicketController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbPrintTicket/TbPrintTicketIndex.cshtml");
        }
    }
}