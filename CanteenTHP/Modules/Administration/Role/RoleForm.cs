
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
        [RoleEditor]
        [DisplayName(" "), LabelWidth(0)]
        public List<RoleSelectionRow> DetailList { get; set; }
    }
}