
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblKhachHang")]
    [BasedOnRow(typeof(Entities.TblKhachHangRow), CheckNames = true)]
    public class TblKhachHangForm
    {
        public String MaKh { get; set; }
        public String TenKh { get; set; }
        public String DiaChi { get; set; }
        public Int32 NguoiDaiDien { get; set; }
        public String Phone { get; set; }
        public String Mst { get; set; }
    }
}