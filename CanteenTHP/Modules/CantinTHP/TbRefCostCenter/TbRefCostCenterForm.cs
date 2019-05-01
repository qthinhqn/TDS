
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefCostCenter")]
    [BasedOnRow(typeof(Entities.TbRefCostCenterRow), CheckNames = true)]
    public class TbRefCostCenterForm
    {
        public String CostCenter { get; set; }
        public String Remarks { get; set; }
        public Boolean IsTemp { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
        public Boolean Active { get; set; }
    }
}