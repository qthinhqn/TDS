
namespace Serene3.Administration
{
    using Serenity.Services;

    public class UserRoleListRequest : ServiceRequest
    {
        public int? UserID { get; set; }
    }
}