
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblLenChuyenInChiTiet")]
    [BasedOnRow(typeof(Entities.TblLenChuyenInChiTietRow), CheckNames = true)]
    public class TblLenChuyenInChiTietForm
    {
        public Int32 MaBo { get; set; }
        public DateTime Ngay { get; set; }
        //public Boolean Status { get; set; }
        public Int32 MaLenChuyen { get; set; }
        [ReadOnly(true)]
        public Int32 CT_SL_Thuc { get; set; }
        [ReadOnly(true)]
        public Int32 CT_SL_Loi_KH { get; set; }
        //public Int32 CT_SL_Loi_In { get; set; }

    }
}