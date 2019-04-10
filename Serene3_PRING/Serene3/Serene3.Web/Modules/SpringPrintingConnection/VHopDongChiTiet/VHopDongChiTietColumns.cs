
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.VHopDongChiTiet")]
    [BasedOnRow(typeof(Entities.VHopDongChiTietRow), CheckNames = true)]
    public class VHopDongChiTietColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 MaHd { get; set; }
        public DateTime NgayHd { get; set; }
        [EditLink]
        public String NoiDung { get; set; }
        public Double GiaTri { get; set; }
        public String SoHd { get; set; }
        public String TenKh { get; set; }
        public String MaKh { get; set; }
        public Int32 MaBtp { get; set; }
        public String MotaBtp { get; set; }
        public String DonViTinh { get; set; }
        public String MaMau { get; set; }
        public String TenMau { get; set; }
        public String MaSize { get; set; }
        public String TenSize { get; set; }
        public String MaStyle { get; set; }
        public String TenStyle { get; set; }
        [AlignRight]
        public Int32 SoLuong { get; set; }
        [AlignRight]
        public Double DonGia { get; set; }
        [AlignRight]
        public Double ThanhTien { get; set; }
    }
}