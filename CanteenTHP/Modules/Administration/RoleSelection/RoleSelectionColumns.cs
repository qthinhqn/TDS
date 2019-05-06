
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
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        [Hidden]
        public Int64 RoleSelectionId { get; set; }
        [Hidden]
        public String RoleRoleName { get; set; }
        public String EmpId { get; set; }
        public Int32 EmpKeyId { get; set; }
        public String EmpFirstName { get; set; }
        public String EmpLastName { get; set; }
        //public String EmpEmployeeName { get; set; }
        public String EmpSexId { get; set; }
        public DateTime EmpLeftDate { get; set; }
        public DateTime EmpStartDate { get; set; }
    }
}