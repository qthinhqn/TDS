
namespace Canteen.Administration.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Administration.RoleCostCenter")]
    [BasedOnRow(typeof(Entities.RoleCostCenterRow), CheckNames = true)]
    public class RoleCostCenterColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int64 RoleCostCenterId { get; set; }
        //public String RoleRoleName { get; set; }
        [EditLink]
        public String CostCenter { get; set; }
        public Boolean CostCenterIsTemp { get; set; }
        public String CostCenterRemarks { get; set; }
    }
}