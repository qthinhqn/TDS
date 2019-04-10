
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblHopDong")]
    [BasedOnRow(typeof(Entities.TblHopDongRow), CheckNames = true)]
    public class TblHopDongColumns
    {
        [EditLink, Width(70), AlignCenter]
        public Int32 KeyId { get; set; }
        [EditLink,Width(200), LookupEditor(typeof(Entities.TblKhachHangRow)), QuickFilter,Hidden]
        public String MaKh { get; set; }

        [EditLink, Width(200)]
        public String MaKhTenKh { get; set; }
        [EditLink, Width(120),QuickFilter]
        public DateTime NgayHd { get; set; }
        [Width(300)]
        public String NoiDung { get; set; }

        [EditLink, Width(150)]
        public String SoHd { get; set; }
        [Width(120), AlignRight]
        public Double GiaTri { get; set; }
        [EditLink, Width(150), LookupEditor(typeof(Entities.TblNguoiDungRow)), QuickFilter]
        public String NvTaoHoTen { get; set; }
        //[Width(120)]
        //public DateTime Ngay { get; set; }
    }
}