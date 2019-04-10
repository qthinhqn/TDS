using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serene3.SpringPrintingConnection.TTblBoBtpRow
{
    public class TblBoBtpRowListRequest : ListRequest
    {

        public String Note { get; set; }
        public String MaLo { get; set; }
    }
}