
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblXuatKhoKh")]
    [BasedOnRow(typeof(Entities.TblXuatKhoKhRow), CheckNames = true)]
    public class TblXuatKhoKhColumns
    {
        [EditLink, AlignCenter]
        public Int32 KeyId { get; set; }
        [EditLink, Width(200)]
        public String MaKh1 { get; set; }
        [Width(100),QuickFilter]
        public DateTime NgayXuat { get; set; }
        [EditLink, Width(150), LookupEditor(typeof(Entities.TblNguoiDungRow)),QuickFilter]
        public String MaNvXuatHoTen { get; set; }
        [EditLink]
        [Width(120)]
        public String SoPhieu { get; set; }
        [Width(200)]
        public String Ghichu { get; set; }
    }
}