
namespace Canteen.Administration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Administration.RoleCostCenter")]
    [BasedOnRow(typeof(Entities.RoleCostCenterRow), CheckNames = true)]
    public class RoleCostCenterForm
    {
        [LookupEditor(typeof(Entities.RoleRow))]
        public Int32 RoleId { get; set; }
        [LookupEditor(typeof(Canteen.CantinTHP.Entities.TbRefCostCenterRow))]
        public String CostCenter { get; set; }
    }
}