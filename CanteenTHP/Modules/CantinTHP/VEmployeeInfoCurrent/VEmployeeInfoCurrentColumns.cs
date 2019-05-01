
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.VEmployeeInfoCurrent")]
    [BasedOnRow(typeof(Entities.VEmployeeInfoCurrentRow), CheckNames = true)]
    public class VEmployeeInfoCurrentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmployeeName { get; set; }
        public String SexId { get; set; }
        public DateTime LeftDate { get; set; }
        public Boolean Active { get; set; }
        public DateTime StartDate { get; set; }
        public String CompanyKey { get; set; }
        public String DepKey { get; set; }
        public Boolean IsManager { get; set; }
        public String CanteenId { get; set; }
        public String CostCenter { get; set; }
    }
}