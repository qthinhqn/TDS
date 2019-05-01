
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefCompany")]
    [BasedOnRow(typeof(Entities.TbRefCompanyRow), CheckNames = true)]
    public class TbRefCompanyForm
    {
        public String CompanyKey { get; set; }
        public String CompanyName { get; set; }
        public String CompanyNameEng { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}