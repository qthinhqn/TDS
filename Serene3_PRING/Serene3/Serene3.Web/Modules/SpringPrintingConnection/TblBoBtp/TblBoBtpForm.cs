
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblBoBtp")]
    [BasedOnRow(typeof(Entities.TblBoBtpRow), CheckNames = true)]
    public class TblBoBtpForm
    {
        //[LookupEditor(typeof(Entities.TblLoSpRow))]
        public Int32 MaLo { get; set; }
        [LookupEditor(typeof(Entities.TblBanThanhPhamRow))]
        public Int32 MaBtp { get; set; }
        public Int32 SlThuc { get; set; }
        public Int32 SlLoiKh { get; set; }
        public Int32 SlLoiIn { get; set; }
        //public Int32 MaIn { get; set; }
        //public Int32 MaOut { get; set; }
        //public Int32 MaLenChuyen { get; set; }
        //public Int32 MaXuongChuyen { get; set; }
        [LookupEditor(typeof(Entities.TblRefMauRow))]
        public Int32 MaMau { get; set; }
        [LookupEditor(typeof(Entities.TblRefSizeRow))]
        public Int32 MaSize { get; set; }
        //public Boolean HangMau { get; set; }
        //public Boolean HangBu { get; set; }
        [LookupEditor(typeof(Entities.TblHopDongRow))]
        public Int32 MaHd { get; set; }
        [LookupEditor(typeof(Entities.TblRefTypeRow))]
        public String TypeID { get; set; }
    }
}