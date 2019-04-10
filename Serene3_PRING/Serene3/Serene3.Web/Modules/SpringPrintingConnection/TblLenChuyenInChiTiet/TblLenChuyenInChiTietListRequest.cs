using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene3.SpringPrintingConnection.TblLenChuyenInChiTiet
{
    public class TblLenChuyenInChiTietListRequest : ListRequest
    {

        public String Note { get; set; }
        public String MaLenChuyen { get; set; }
    }

    public class TblLenChuyenInChiTietListResponse : ListResponse<TblLenChuyenInChiTietListResponse>
    {
        public String KeyID { get; set; }
        public String ErrorCode { get; set; }
    }
}