
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpDepartment")]
    [BasedOnRow(typeof(Entities.TbEmpDepartmentRow), CheckNames = true)]
    public class TbEmpDepartmentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Guid KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String DepKeyDepName { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}