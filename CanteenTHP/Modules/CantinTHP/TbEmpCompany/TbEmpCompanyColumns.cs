
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpCompany")]
    [BasedOnRow(typeof(Entities.TbEmpCompanyRow), CheckNames = true)]
    public class TbEmpCompanyColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Guid KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String CompanyKeyCompanyName { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}