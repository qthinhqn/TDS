
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefSex")]
    [BasedOnRow(typeof(Entities.TblRefSexRow), CheckNames = true)]
    public class TblRefSexColumns
    {
        [EditLink, AlignCenter]
        public String SexId { get; set; }
        [AlignRight]
        public String SexName { get; set; }
    }
}