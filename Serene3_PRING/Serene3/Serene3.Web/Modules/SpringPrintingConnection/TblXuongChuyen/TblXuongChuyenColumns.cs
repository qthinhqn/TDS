
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblXuongChuyen")]
    [BasedOnRow(typeof(Entities.TblXuongChuyenRow), CheckNames = true)]
    public class TblXuongChuyenColumns
    {
        [EditLink, AlignCenter, Width(100)]
        public Int32 KeyId { get; set; }
        [EditLink, Width(250)]
        [LookupEditor(typeof(Entities.TblNguoiDungRow)), QuickFilter]
        public String MaNvQuetHoTen { get; set; }
        [EditLink, Width(150), QuickFilter]
        public DateTime Ngay { get; set; }
    }
}