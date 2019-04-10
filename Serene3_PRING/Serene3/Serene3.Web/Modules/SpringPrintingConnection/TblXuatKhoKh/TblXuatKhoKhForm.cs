
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblXuatKhoKh")]
    [BasedOnRow(typeof(Entities.TblXuatKhoKhRow), CheckNames = true)]
    public class TblXuatKhoKhForm
    {
        [Tab("Xuat kho")]
        [LookupEditor(typeof(Entities.TblKhachHangRow))]
        public Int32 MaKh { get; set; }
        public DateTime NgayXuat { get; set; }
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public Int32 MaNvXuat { get; set; }
        public String SoPhieu { get; set; }
        public String Ghichu { get; set; }

        [Tab("Detail")]
        [TblXuatKho_ChiTietEditor]
        public List<Entities.TblXuatKho_ChiTietRow> DetailList { get; set; }
    }
}