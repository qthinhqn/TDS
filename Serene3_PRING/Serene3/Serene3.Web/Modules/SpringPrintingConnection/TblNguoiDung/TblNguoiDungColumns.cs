
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblNguoiDung")]
    [BasedOnRow(typeof(Entities.TblNguoiDungRow), CheckNames = true)]
    public class TblNguoiDungColumns
    {
        [EditLink, AlignCenter]
        public Int32 KeyId { get; set; }
        [EditLink, Width(200)]
        public String HoTen { get; set; }
        //[EditLink(ItemType = "SpringPrintingConnection.TblRefSex", IdField = "SexName"), Width(150)]
        // [LookupEditor(typeof(Entities.TblRefSexRow)), QuickFilter]
        //public String GioiTinh { get; set; }
        [Width(80)]
        public String SexName { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Email { get; set; }
        [Width(200)]
        public String ChucVu { get; set; }
        [Width(80)]
        public Boolean Status { get; set; }
    }
}