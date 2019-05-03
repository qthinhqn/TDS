
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbMealCost")]
    [BasedOnRow(typeof(Entities.TbMealCostRow), CheckNames = true)]
    public class TbMealCostForm
    {
        [DefaultValue("now")]
        public DateTime DateChange { get; set; }
        public Double EmployeeCost { get; set; }
        public Double ManagerCost { get; set; }
        public String Remarks { get; set; }
    }
}