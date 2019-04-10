
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblHopDongChiTiet")]
    [BasedOnRow(typeof(Entities.TblHopDongChiTietRow), CheckNames = true)]
    public class TblHopDongChiTietColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        //  [EditLink, Width(80)]
        // public Int32 MaHd { get; set; }
        //[EditLink, Width(150)]
        //public String MaHdNoiDung { get; set; }
        [EditLink, Width(150)]
        public String MaBtpMotaBtp { get; set; }
        [Width(100)]
        public String MaMauTenMau { get; set; }
        [Width(100)]
        public String MaSizeTenSize { get; set; }
        [Width(100)]
        public String MaStyleTenStyle { get; set; }
        [Width(120), AlignRight]
        public Int32 SoLuong { get; set; }
        [Width(100), AlignRight]
        public Double DonGia { get; set; }
        [Width(100), AlignRight]
        public Double ThanhTien { get; set; }
    }
}