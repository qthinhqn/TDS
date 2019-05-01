
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpCostTemp")]
    [BasedOnRow(typeof(Entities.TbEmpCostTempRow), CheckNames = true)]
    public class TbEmpCostTempColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String CostId { get; set; }
        public DateTime DDay { get; set; }
        public String ShiftShiftName { get; set; }
    }
}