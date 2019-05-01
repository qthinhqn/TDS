
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefCompany")]
    [BasedOnRow(typeof(Entities.TbRefCompanyRow), CheckNames = true)]
    public class TbRefCompanyColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String CompanyKey { get; set; }
        public String CompanyName { get; set; }
        public String CompanyNameEng { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}