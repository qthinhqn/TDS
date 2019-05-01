
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpShift")]
    [BasedOnRow(typeof(Entities.TbEmpShiftRow), CheckNames = true)]
    public class TbEmpShiftColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Guid KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String ShiftShiftName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public String Remarks { get; set; }
    }
}