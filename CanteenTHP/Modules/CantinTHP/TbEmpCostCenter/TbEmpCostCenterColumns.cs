
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpCostCenter")]
    [BasedOnRow(typeof(Entities.TbEmpCostCenterRow), CheckNames = true)]
    public class TbEmpCostCenterColumns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        public Guid KeyId { get; set; }
        public String StringName { get; set; }
        public String CostCenterRemarks { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}