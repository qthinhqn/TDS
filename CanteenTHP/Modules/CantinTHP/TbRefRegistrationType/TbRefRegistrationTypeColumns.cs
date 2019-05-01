
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefRegistrationType")]
    [BasedOnRow(typeof(Entities.TbRefRegistrationTypeRow), CheckNames = true)]
    public class TbRefRegistrationTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String RegId { get; set; }
        public String RegName { get; set; }
    }
}