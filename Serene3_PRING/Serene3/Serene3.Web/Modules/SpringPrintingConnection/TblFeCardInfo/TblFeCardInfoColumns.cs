
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblFeCardInfo")]
    [BasedOnRow(typeof(Entities.TblFeCardInfoRow), CheckNames = true)]
    public class TblFeCardInfoColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //[Width(150)]
        //public Guid RecId { get; set; }
        [EditLink,Width(150)]
        public Int64 CardId { get; set; }
        [EditLink]
        public String RefBarCode { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ImportTime { get; set; }
    }
}