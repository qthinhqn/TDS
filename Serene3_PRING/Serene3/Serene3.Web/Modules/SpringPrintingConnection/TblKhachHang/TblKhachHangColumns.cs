
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblKhachHang")]
    [BasedOnRow(typeof(Entities.TblKhachHangRow), CheckNames = true)]
    public class TblKhachHangColumns
    {
        [EditLink,  AlignCenter]
        public Int32 KeyId { get; set; }
        [EditLink, Width(90)]
        public String MaKh { get; set; }
        [EditLink, Width(250)]
        public String TenKh { get; set; }
        [Width(250)]
        public String DiaChi { get; set; }

        [LookupEditor(typeof(Entities.TblRefNguoiDaiDienRow)), QuickFilter, Width(150)]
        public String NguoiDaiDienHoTen { get; set; }
        [Width(100)]
        public String Phone { get; set; }
        [Width(100)]
        public String Mst { get; set; }
    }
}