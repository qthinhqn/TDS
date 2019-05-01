
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefMenu")]
    [BasedOnRow(typeof(Entities.TbRefMenuRow), CheckNames = true)]
    public class TbRefMenuForm
    {
        public String MenuId { get; set; }
        public String MenuName { get; set; }
        public String MImage { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}