
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefCanteen")]
    [BasedOnRow(typeof(Entities.TbRefCanteenRow), CheckNames = true)]
    public class TbRefCanteenForm
    {
        public String CanteenId { get; set; }
        public String CanteenName { get; set; }
        public String ContactPerson { get; set; }
        public String PhoneNum { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}