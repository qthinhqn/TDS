
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefReason4Adjust")]
    [BasedOnRow(typeof(Entities.TbRefReason4AdjustRow), CheckNames = true)]
    public class TbRefReason4AdjustForm
    {
        public String Reason { get; set; }
        public Boolean Active { get; set; }
    }
}