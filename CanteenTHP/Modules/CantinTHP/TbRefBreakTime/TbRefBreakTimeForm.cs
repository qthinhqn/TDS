
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefBreakTime")]
    [BasedOnRow(typeof(Entities.TbRefBreakTimeRow), CheckNames = true)]
    public class TbRefBreakTimeForm
    {
        public String ShiftId { get; set; }
        public String ShiftName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean Active { get; set; }
    }
}