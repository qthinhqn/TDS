
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefNguoiDaiDien")]
    [BasedOnRow(typeof(Entities.TblRefNguoiDaiDienRow), CheckNames = true)]
    public class TblRefNguoiDaiDienForm
    {
        public String HoTen { get; set; }
        [LookupEditor(typeof(Entities.TblRefSexRow))]
        public String GioiTinh { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        [EmailEditor()]
        public String Email { get; set; }
        public String ChucVu { get; set; }
        [LookupEditor(typeof(Entities.TblKhachHangRow))]
        public Int32 MaKh { get; set; }
        public Boolean Status { get; set; }
    }
}