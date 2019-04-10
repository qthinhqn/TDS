
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("SpringPrintingConnection.TblBoBtp")]
    [BasedOnRow(typeof(Entities.TblBoBtpRow), CheckNames = true)]
    public class TblBoBtpColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(100)]
        [QuickFilter]
        public String MaLo { get; set; }
        //[EditLink, Width(250)]
        //public String TenKH { get; set; }
        [EditLink, Width(100)]
        public String CardId { get; set; }
        [EditLink, Width(150)]
        [LookupEditor(typeof(Entities.TblBanThanhPhamRow)), QuickFilter]
        public String MaBtpMotaBtp { get; set; }
        [Width(100)]
        public Int32 SlThuc { get; set; }
        [Width(100)]
        public Int32 SlLoiKh { get; set; }
        //[Width(100)]
        //public Int32 SlLoiIn { get; set; }
        //[Width(100)]
        //public Int32 MaIn { get; set; }
        //[Width(100)]
        //public Int32 MaOut { get; set; }
        //[Width(100)]
        //public Int32 MaLenChuyen { get; set; }
        //[Width(100)]
        //public Int32 MaXuongChuyen { get; set; }
        [LookupEditor(typeof(Entities.TblRefMauRow)), QuickFilter, Hidden]
        public Int32 MaMau { get; set; }
        [Width(100)]
        public String MaMauTenMau { get; set; }
        [LookupEditor(typeof(Entities.TblRefSizeRow)), QuickFilter, Hidden]
        public Int32 MaSize { get; set; }
        [Width(100)]
        public String MaSizeTenSize { get; set; }
        [LookupEditor(typeof(Entities.TblRefStyleRow)), QuickFilter, Hidden]
        public Int32 MaStyle { get; set; }
        [Width(100)]
        public String MaStyleTenStyle { get; set; }
        //[Width(80)]
        //public Boolean HangMau { get; set; }
        //[Width(80)]
        //public Boolean HangBu { get; set; }
        [Width(100)]
        [LookupEditor(typeof(Entities.TblRefTypeRow)), QuickFilter ,Hidden]
        public String TypeID { get; set; }
        [Width(120)]
        public String MaTypeTenType { get; set; }
        //[Width(150)]
        //public String MaHdNoiDung { get; set; }
        [Width(120)]
        public Int32 BulNo { get; set; }
        [Width(150)]
        public String TableNum { get; set; }
        [Width(150)]
        public String Fepo { get; set; }
    }
}