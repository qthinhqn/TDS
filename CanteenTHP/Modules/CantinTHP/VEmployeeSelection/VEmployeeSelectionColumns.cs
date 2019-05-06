
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.VEmployeeSelection")]
    [BasedOnRow(typeof(Entities.VEmployeeSelectionRow), CheckNames = true)]
    public class VEmployeeSelectionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        [Hidden]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String EmployeeId { get; set; }
        //public String FirstName { get; set; }
        //public String LastName { get; set; }
        public String EmployeeName { get; set; }
        public String SexId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LeftDate { get; set; }
        //public Boolean Active { get; set; }
        //public String CompanyKey { get; set; }
        public String CompanyName { get; set; }
        //public String DepKey { get; set; }
        public String DepName { get; set; }
        public Boolean IsManager { get; set; }
        //public String CanteenId { get; set; }
        [Hidden]
        public String CanteenName { get; set; }
        [Hidden]
        public String CostCenter { get; set; }
    }
}