using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene3.SpringPrintingConnection.TblXuongChuyenInChiTiet
{
    public class TblXuongChuyenInChiTietListRequest : ListRequest
    {

        public String Note { get; set; }
        public String MaXuongChuyen { get; set; }
    }
    public class TblXuongChuyenInChiTietListResponse : ListResponse<TblXuongChuyenInChiTietListResponse>
    {
        public String KeyID { get; set; }
        public String ErrorCode { get; set; }
    }
}