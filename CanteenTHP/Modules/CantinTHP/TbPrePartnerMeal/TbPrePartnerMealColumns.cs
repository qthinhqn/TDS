
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbPrePartnerMeal")]
    [BasedOnRow(typeof(Entities.TbPrePartnerMealRow), CheckNames = true)]
    public class TbPrePartnerMealColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String PartnerName { get; set; }
        public String ContactName { get; set; }
        public DateTime DDate { get; set; }
        public String Phone { get; set; }
        public String Remarks { get; set; }
        public String EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
    }
}