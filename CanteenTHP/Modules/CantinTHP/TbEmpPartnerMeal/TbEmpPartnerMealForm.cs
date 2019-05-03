
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using Scripts;

    [FormScript("CantinTHP.TbEmpPartnerMeal")]
    [BasedOnRow(typeof(Entities.TbEmpPartnerMealRow), CheckNames = true)]
    public class TbEmpPartnerMealForm
    {
        public String PartnerName { get; set; }
        public String ContactName { get; set; }
        [DefaultValue("now")]
        public DateTime DDate { get; set; }
        public String Phone { get; set; }
        public String Remarks { get; set; }
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
        public Int32 ReasonId { get; set; }
        public String Notes { get; set; }
    }
}