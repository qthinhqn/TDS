
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbPrintTicket")]
    [BasedOnRow(typeof(Entities.TbPrintTicketRow), CheckNames = true)]
    public class TbPrintTicketColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        public Int32 RegId { get; set; }
        public DateTime DDay { get; set; }
        [EditLink]
        public String UserName { get; set; }
        public Int32 PNum { get; set; }
    }
}