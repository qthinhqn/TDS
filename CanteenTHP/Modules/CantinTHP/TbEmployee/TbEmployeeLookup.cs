
namespace Canteen.CantinTHP.Scripts
{
    using Entities;
    //using global::Canteen.Utilities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Web;
    using System;
    using System.Web;

    [LookupScript("CantinTHP.TbEmployee", Permission = "*")]
    public class TbEmployeeLookup : RowLookupScript<TbEmployeeRow>
    {
        public TbEmployeeLookup()
        {
            IdField = TbEmployeeRow.Fields.EmployeeId.PropertyName;
            TextField = TbEmployeeRow.Fields.StringName.PropertyName;
            Expiration = TimeSpan.FromDays(-1);
        }
        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = Entities.TbEmployeeRow.Fields;
            //if (Declare.isEmp(HttpContext.Current.User.Identity.Name) == true)
            //{

            //    query.Distinct(true)
            //    .Select(fld.EmployeeId, fld.EmployeeName)
            //    .Where(new Criteria(fld.EmployeeId) == HttpContext.Current.User.Identity.Name);
            //}
            //else
            {
                query.Distinct(true)
                    .Select(fld.EmployeeId, fld.EmployeeName, fld.StringName)
                    .Where(
                        new Criteria(fld.EmployeeId) != "" &
                        new Criteria(fld.EmployeeId).IsNotNull());
            }

        }
        protected override void ApplyOrder(SqlQuery query) { }
    }
}
