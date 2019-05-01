
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefLeaveType")]
    [BasedOnRow(typeof(Entities.TbRefLeaveTypeRow), CheckNames = true)]
    public class TbRefLeaveTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String LeaveId { get; set; }
        public String LeaveType { get; set; }
        public Boolean IsLongTerm { get; set; }
        public Boolean Active { get; set; }
    }
}