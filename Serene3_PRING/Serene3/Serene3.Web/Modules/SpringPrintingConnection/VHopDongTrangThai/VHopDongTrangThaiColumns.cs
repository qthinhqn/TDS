
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.VHopDongTrangThai")]
    [BasedOnRow(typeof(Entities.VHopDongTrangThaiRow), CheckNames = true)]
    public class VHopDongTrangThaiColumns
    {
        [EditLink,  AlignCenter]
        //public Int32 MaHd { get; set; }
        public DateTime NgayHd { get; set; }
        [EditLink]
        public String SoHd { get; set; }
        public String NoiDung { get; set; }
        public Double GiaTri { get; set; }
        public String TenKh { get; set; }
        //public String MaKh { get; set; }
        public String MotaBtp { get; set; }
        public String DonViTinh { get; set; }
        //[Width(200), LookupEditor(typeof(Entities.TblRefMauRow)), QuickFilter, Hidden]
        //public String MaMau { get; set; }
        public String TenMau { get; set; }
        //[Width(200), LookupEditor(typeof(Entities.TblRefSizeRow)), QuickFilter, Hidden]
        //public String MaSize { get; set; }
        public String TenSize { get; set; }
        //[Width(200), LookupEditor(typeof(Entities.TblRefStyleRow)), QuickFilter, Hidden]
        //public String MaStyle { get; set; }
        public String TenStyle { get; set; }
        [AlignRight]
        public Int32 SoLuong { get; set; }
        [AlignRight]
        public Double DonGia { get; set; }
        [AlignRight]
        public Double ThanhTien { get; set; }

        [Width(120), AlignRight]
        public Int32 SlNhap { get; set; }

        [Width(120), AlignRight]
        public Int32 SlLoiKh { get; set; }

        [Width(120), AlignRight]
        public Int32 SlLoiIn { get; set; }

        [Width(120), AlignRight]
        public Int32 SlThucXuat { get; set; }

        [Width(120), AlignRight]
        public Int32 SlThieu { get; set; }
    }
}