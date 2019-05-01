
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefCanteen")]
    [BasedOnRow(typeof(Entities.TbRefCanteenRow), CheckNames = true)]
    public class TbRefCanteenColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String CanteenId { get; set; }
        public String CanteenName { get; set; }
        public String ContactPerson { get; set; }
        public String PhoneNum { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}