
namespace Canteen.CantinTHP.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using System;
    using System.Web;

    [LookupScript("CantinTHP.TbRefCanteenLookup", Permission = "*")]
    public class TbRefCanteenLookup : RowLookupScript<TbRefCanteenRow>
    {
        public TbRefCanteenLookup()
        {
            IdField = TbRefCanteenRow.Fields.CanteenId.PropertyName;
            TextField = TbRefCanteenRow.Fields.StringName.PropertyName;
            Expiration = TimeSpan.FromDays(-1);
        }
        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = Entities.TbRefCanteenRow.Fields;
            //if (Declare.isEmp(HttpContext.Current.User.Identity.Name) == true)
            //{

            //    query.Distinct(true)
            //    .Select(fld.EmployeeId, fld.EmployeeName)
            //    .Where(new Criteria(fld.EmployeeId) == HttpContext.Current.User.Identity.Name);
            //}
            //else
            {
                query.Distinct(true)
                    .Select(fld.CanteenId, fld.CanteenName, fld.StringName)
                    .Where(
                        new Criteria(fld.CanteenId) != "" &
                        new Criteria(fld.CanteenId).IsNotNull());
            }

        }
        protected override void ApplyOrder(SqlQuery query) { }
    }
}
