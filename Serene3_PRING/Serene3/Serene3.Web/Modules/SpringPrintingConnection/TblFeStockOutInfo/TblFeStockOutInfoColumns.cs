
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("SpringPrintingConnection.TblFeStockOutInfo")]
    [BasedOnRow(typeof(Entities.TblFeStockOutInfoRow), CheckNames = true)]
    public class TblFeStockOutInfoColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //[Width(150)]
        //public Guid RecId { get; set; }
        [EditLink, Width(120)]
        public Int32 RfidOutputId { get; set; }
        [EditLink, Width(120)]
        public DateTime DDate { get; set; }
        [EditLink,Width(100)]
        public String Fty { get; set; }
        [Width(100)]
        public String Po { get; set; }
        [Width(100)]
        public String Fepo { get; set; }
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public Int32 BulNo { get; set; }
        public String TableNum { get; set; }
        public String Buy { get; set; }
        public String Style04 { get; set; }
        public String Col { get; set; }
        public String Size { get; set; }
        public String Part { get; set; }
        public String OpNo { get; set; }
        public String OpName { get; set; }
        public Int32 Quantity { get; set; }
        public DateTime ImportTime { get; set; }
    }
}