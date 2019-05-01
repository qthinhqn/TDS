
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefEmpType")]
    [BasedOnRow(typeof(Entities.TbRefEmpTypeRow), CheckNames = true)]
    public class TbRefEmpTypeForm
    {
        public String TypeId { get; set; }
        public String TypeName { get; set; }
    }
}