
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbPrintTicket")]
    [BasedOnRow(typeof(Entities.TbPrintTicketRow), CheckNames = true)]
    public class TbPrintTicketForm
    {
        public Int32 RegId { get; set; }
        public DateTime DDay { get; set; }
        public String UserName { get; set; }
        public Int32 PNum { get; set; }
    }
}