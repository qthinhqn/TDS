
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefRegistrationType")]
    [BasedOnRow(typeof(Entities.TbRefRegistrationTypeRow), CheckNames = true)]
    public class TbRefRegistrationTypeForm
    {
        public String RegId { get; set; }
        public String RegName { get; set; }
    }
}