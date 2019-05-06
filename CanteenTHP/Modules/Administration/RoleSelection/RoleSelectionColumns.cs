
namespace Canteen.Administration.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Administration.RoleSelection")]
    [BasedOnRow(typeof(Entities.RoleSelectionRow), CheckNames = true)]
    public class RoleSelectionColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //[Hidden]
        //public Int64 RoleSelectionId { get; set; }
        //[Hidden]
        //public String RoleRoleName { get; set; }
        public String EmpId { get; set; }
        //public String FirstName { get; set; }
        //public String LastName { get; set; }
        public String EmployeeName { get; set; }
        public String SexId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LeftDate { get; set; }
        public String CompanyKey { get; set; }
        public String DepKey { get; set; }
        public Boolean IsManager { get; set; }
        [Hidden]
        public String CanteenId { get; set; }
        [Hidden]
        public String CostCenter { get; set; }
    }
}