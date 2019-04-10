using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene3.SpringPrintingConnection.TblXuatKhoChiTiet
{
    public class TblXuatKhoChiTietListRequest : ListRequest
    {

        public String Note { get; set; }
        public String MaBo { get; set; }
    }
    public class TblXuatKhoChiTietListResponse : ListResponse<TblXuatKhoChiTietListResponse>
    {
        public String KeyID { get; set; }
        public String ErrorCode { get; set; }
    }
}