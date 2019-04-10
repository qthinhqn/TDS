
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblHopDong_ChiTiet")]
    [BasedOnRow(typeof(Entities.TblHopDong_ChiTietRow), CheckNames = true)]
    public class TblHopDong_ChiTietForm
    {
        //[Category("PO Detail")]
        [Tab("PO Detail")]
        public Int32 KeyId { get; set; }
        //[LookupEditor(typeof(Entities.TblHopDongRow)), QuickFilter]
        //public Int32 MaHd { get; set; }
        [LookupEditor(typeof(Entities.TblBanThanhPhamRow)), QuickFilter]
        public Int32 MaBtp { get; set; }
        [LookupEditor(typeof(Entities.TblRefMauRow)), QuickFilter]
        public Int32 MaMau { get; set; }
        [LookupEditor(typeof(Entities.TblRefSizeRow)), QuickFilter]
        public Int32 MaSize { get; set; }
       [LookupEditor(typeof(Entities.TblRefStyleRow)), QuickFilter]
        public Int32 MaStyle { get; set; }
        public Int32 SoLuong { get; set; }
        public Double DonGia { get; set; }
        public Double ThanhTien { get; set; }
        //public Int32 KeyId { get; set; }
        //public Int32 MaHd { get; set; }
        //public Int32 MaBtp { get; set; }
        //public Int32 MaMau { get; set; }
        //public Int32 MaSize { get; set; }
        //public Int32 SoLuong { get; set; }
        //public Double DonGia { get; set; }
        //public Double ThanhTien { get; set; }
        //public Int32 MaStyle { get; set; }
        [Tab("Adjust Detail")]
        [TblHopDong_DieuChinhEditor]
        public List<Entities.TblHopDongDieuChinhRow> AdjDetailList { get; set; }
    }
}