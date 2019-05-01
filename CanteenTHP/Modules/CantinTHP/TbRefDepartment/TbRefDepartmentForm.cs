
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbRefDepartment")]
    [BasedOnRow(typeof(Entities.TbRefDepartmentRow), CheckNames = true)]
    public class TbRefDepartmentForm
    {
        public String DepKey { get; set; }
        public String DepName { get; set; }
        [LookupEditor(typeof(Entities.TbRefDepartmentRow))]
        public String DepParent { get; set; }
        public String CostCenter { get; set; }
        [LookupEditor(typeof(Entities.TbRefCompanyRow))]
        public String CompanyKey { get; set; }
        public Int32 iLevel { get; set; }
        public Boolean Active { get; set; }
    }
}