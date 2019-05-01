
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefLeaveType")]
    [BasedOnRow(typeof(Entities.TbRefLeaveTypeRow), CheckNames = true)]
    public class TbRefLeaveTypeForm
    {
        public String LeaveId { get; set; }
        public String LeaveType { get; set; }
        public Boolean IsLongTerm { get; set; }
        public Boolean Active { get; set; }
    }
}