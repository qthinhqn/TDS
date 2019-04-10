
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblNguoiDung")]
    [BasedOnRow(typeof(Entities.TblNguoiDungRow), CheckNames = true)]
    public class TblNguoiDungForm
    {
        public String HoTen { get; set; }
        [EditLink(ItemType = "SpringPrintingConnection.TblRefSex", IdField = "SexID"), Width(150)]
        [LookupEditor(typeof(Entities.TblRefSexRow)), QuickFilter]
        public String GioiTinh { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        [EmailEditor()]
        public String Email { get; set; }
        public String ChucVu { get; set; }
        public Boolean Status { get; set; }
    }
}