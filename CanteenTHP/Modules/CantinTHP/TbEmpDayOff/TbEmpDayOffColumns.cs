
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpDayOff")]
    [BasedOnRow(typeof(Entities.TbEmpDayOffRow), CheckNames = true)]
    public class TbEmpDayOffColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String LeaveLeaveType { get; set; }
        public DateTime DateChange { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public String Remarks { get; set; }
    }
}