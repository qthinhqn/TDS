
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefNguoiDaiDien")]
    [BasedOnRow(typeof(Entities.TblRefNguoiDaiDienRow), CheckNames = true)]
    public class TblRefNguoiDaiDienColumns
    {
        [EditLink,  AlignCenter]
        public Int32 KeyId { get; set; }
        [EditLink, Width(200)]
        public String HoTen { get; set; }
        // public Boolean GioiTinh { get; set; }
        [Width(80)]
        public String SexName { get; set; }
        [Width(80)]
        public String Phone { get; set; }
        [Width(80)]
        public String Mobile { get; set; }
        [Width(150)]
        public String Email { get; set; }
        [Width(200)]
        public String ChucVu { get; set; }
        [Width(200)]//, LookupEditor(typeof(Entities.TblKhachHangRow)),QuickFilter]
        public String MaKhTenKh { get; set; }
        [Width(80)]
        public Boolean Status { get; set; }
    }
}