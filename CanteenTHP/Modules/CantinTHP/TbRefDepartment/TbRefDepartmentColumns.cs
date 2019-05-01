
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefDepartment")]
    [BasedOnRow(typeof(Entities.TbRefDepartmentRow), CheckNames = true)]
    public class TbRefDepartmentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String DepKey { get; set; }
        public String DepName { get; set; }
        public String DepParentDepName { get; set; }
        public String CostCenter { get; set; }
        public String CompanyKey { get; set; }
        public Int32 iLevel { get; set; }
        public Boolean Active { get; set; }
    }
}