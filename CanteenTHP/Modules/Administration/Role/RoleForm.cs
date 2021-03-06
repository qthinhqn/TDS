﻿
namespace Canteen.Administration.Forms
{
    using Entities;
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Administration.Role")]
    [BasedOnRow(typeof(Entities.RoleRow), CheckNames = true)]
    public class RoleForm
    {
        public String RoleName { get; set; }

        [Category("Employee Selection")]
        [RoleSelectionEditor]
        [DisplayName(" "), LabelWidth(0)]
        public List<RoleSelectionRow> DetailList { get; set; }

        [Category("CostCenter Selection")]
        [RoleCostCenterEditor]
        [DisplayName(" "), LabelWidth(0)]
        public List<RoleCostCenterRow> CostCenterList { get; set; }
    }
}