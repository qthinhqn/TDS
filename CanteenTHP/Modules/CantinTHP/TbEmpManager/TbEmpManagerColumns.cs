﻿
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpManager")]
    [BasedOnRow(typeof(Entities.TbEmpManagerRow), CheckNames = true)]
    public class TbEmpManagerColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Guid KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public Boolean IsManager { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}