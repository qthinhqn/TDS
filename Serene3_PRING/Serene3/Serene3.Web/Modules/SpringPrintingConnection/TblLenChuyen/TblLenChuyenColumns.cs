
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblLenChuyen")]
    [BasedOnRow(typeof(Entities.TblLenChuyenRow), CheckNames = true)]
    public class TblLenChuyenColumns
    {
        [EditLink,  AlignCenter, Width(100)]
        public Int32 KeyId { get; set; }
        [EditLink, Width(250)]
        [LookupEditor(typeof(Entities.TblNguoiDungRow)), QuickFilter]
        public String MaNvQuetHoTen { get; set; }
        [EditLink, Width(150), QuickFilter]
        public DateTime Ngay { get; set; }
    }
}