
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

    [FormScript("CantinTHP.TbPrePartnerMeal")]
    [BasedOnRow(typeof(Entities.TbPrePartnerMealRow), CheckNames = true)]
    public class TbPrePartnerMealForm
    {
        public String PartnerName { get; set; }
        public String ContactName { get; set; }
        public DateTime DDate { get; set; }
        public String Phone { get; set; }
        public String Remarks { get; set; }
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
    }
}