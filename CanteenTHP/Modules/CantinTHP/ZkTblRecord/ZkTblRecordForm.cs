
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.ZkTblRecord")]
    [BasedOnRow(typeof(Entities.ZkTblRecordRow), CheckNames = true)]
    public class ZkTblRecordForm
    {
        public String UserId { get; set; }
        public String Ip { get; set; }
        public String NgayCc { get; set; }
        public String IYearId { get; set; }
        public String IMonthId { get; set; }
        public String IDay { get; set; }
        public String IHour { get; set; }
        public String IMinute { get; set; }
        public String ISecond { get; set; }
    }
}