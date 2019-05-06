
namespace Canteen.Administration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Administration.RoleSelection")]
    [BasedOnRow(typeof(Entities.RoleSelectionRow), CheckNames = true)]
    public class RoleSelectionForm
    {
        public Int32 RoleId { get; set; }
        public String EmpId { get; set; }
    }
}