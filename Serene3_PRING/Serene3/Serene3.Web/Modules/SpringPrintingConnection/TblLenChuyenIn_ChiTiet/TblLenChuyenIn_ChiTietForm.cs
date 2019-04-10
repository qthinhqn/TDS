
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblLenChuyenIn_ChiTiet")]
    [BasedOnRow(typeof(Entities.TblLenChuyenIn_ChiTietRow), CheckNames = true)]
    public class TblLenChuyenIn_ChiTietForm
    {
        [LookupEditor(typeof(Entities.TblBo_BTPRow))]
        public Int32 MaBo { get; set; }
        public DateTime Ngay { get; set; }
        public Boolean Status { get; set; }
        public Int32 MaLenChuyen { get; set; }
    }
}