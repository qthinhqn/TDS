
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("SpringPrintingConnection.TblLenChuyenInChiTiet")]
    [BasedOnRow(typeof(Entities.TblLenChuyenInChiTietRow), CheckNames = true)]
    public class TblLenChuyenInChiTietColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
       // public Int32 KeyId { get; set; }
        //[Width(120)]
        //public Int32 MaBo { get; set; }
        [EditLink, Width(100), QuickFilter]
        public DateTime Ngay { get; set; }
        //[Width(80)]
        //public Boolean Status { get; set; }
        [Width(120),QuickFilter]
        public Int32 MaLenChuyen { get; set; }
        //[Width(200), LookupEditor(typeof(Entities.TblBo_BTPRow)), QuickFilter, Hidden]
        //public String MaBo { get; set; }

        [Width(200)]//, LookupEditor(typeof(Entities.TblBo_BTPRow)), QuickFilter]
        public String CT_MaBTP { get; set; }
        [Width(120)]
        public String CT_MaMau { get; set; }
        [Width(120)]
        public String CT_MaSize { get; set; }
        [Width(120)]
        public String CT_MaStyle { get; set; }
        [Width(100)]
        public Int32 CT_SL_Thuc { get; set; }
        [Width(100)]
        public Int32 CT_SL_Loi_KH { get; set; }
        [Width(100)]
        public Int32 CT_SL_Loi_In { get; set; }

        [Width(120)]
        public Int32 BulNo { get; set; }
        [Width(150)]
        public String TableNum { get; set; }
        [Width(150)]
        public String Fepo { get; set; }
    }
}