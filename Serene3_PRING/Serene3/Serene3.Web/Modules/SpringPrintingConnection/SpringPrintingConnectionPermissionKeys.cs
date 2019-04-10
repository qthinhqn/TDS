
using Serenity.Extensibility;
using System.ComponentModel;

namespace Serene3.SpringPrintingConnection
{
    [NestedPermissionKeys]
    [DisplayName("SpringPrintingConnection")]
    public class PermissionKeys
    {
        [Description("[General]")]
        public const string General = "Administration:General";
        [DisplayName("TblHopDongRow")]
        public class TblHopDong
        {
            public const string Delete = "Serene3:TblHopDong:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblHopDong:Modify";
            public const string View = "Serene3:TblHopDong:View";
        }
        [DisplayName("VHopDongTrangThai")]
        public class VHopDongTrangThai
        {
            //public const string Delete = "Serene3:VHopDongTrangThai:Delete";
            //[Description("Create/Update")]
            //public const string Modify = "Serene3:VHopDongTrangThai:Modify";
            public const string View = "Serene3:VHopDongTrangThai:View";
        }
        [DisplayName("TblBoBtp")]
        public class TblBoBtp
        {
            public const string Delete = "Serene3:TblBoBtp:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblBoBtp:Modify";
            public const string View = "Serene3:TblBoBtp:View";
        }
        [DisplayName("TblLoSp")]
        public class TblLoSp
        {
            public const string Delete = "Serene3:TblLoSp:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblLoSp:Modify";
            public const string View = "Serene3:TblLoSp:View";
        }
        [DisplayName("TblLenChuyen")]
        public class TblLenChuyen
        {
            public const string Delete = "Serene3:TblLenChuyen:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblLenChuyen:Modify";
            public const string View = "Serene3:TblLenChuyen:View";
        }
        [DisplayName("TblLenChuyenInChiTiet")]
        public class TblLenChuyenInChiTiet
        {
            public const string Delete = "Serene3:TblLenChuyenInChiTiet:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblLenChuyenInChiTiet:Modify";
            public const string View = "Serene3:TblLenChuyenInChiTiet:View";
        }
        [DisplayName("TblXuongChuyen")]
        public class TblXuongChuyen
        {
            public const string Delete = "Serene3:TblXuongChuyen:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblXuongChuyen:Modify";
            public const string View = "Serene3:TblXuongChuyen:View";
        }
        [DisplayName("TblXuongChuyenInChiTiet")]
        public class TblXuongChuyenInChiTiet
        {
            public const string Delete = "Serene3:TblXuongChuyenInChiTiet:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblXuongChuyenInChiTiet:Modify";
            public const string View = "Serene3:TblXuongChuyenInChiTiet:View";
        }
        [DisplayName("TblXuatKhoKh")]
        public class TblXuatKhoKh
        {
            public const string Delete = "Serene3:TblXuatKhoKh:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblXuatKhoKh:Modify";
            public const string View = "Serene3:TblXuatKhoKh:View";
        }
        [DisplayName("TblXuatKhoChiTiet")]
        public class TblXuatKhoChiTiet
        {
            public const string Delete = "Serene3:TblXuatKhoChiTiet:Delete";
            [Description("Create/Update")]
            public const string Modify = "Serene3:TblXuatKhoChiTiet:Modify";
            public const string View = "Serene3:TblXuatKhoChiTiet:View";
        }
        [DisplayName("RptNhapFE_3Controller")]
        public class RptNhapFE_3Controller
        {
            public const string View = "Serene3:RptNhapFE_3Controller:View";
        }
        [DisplayName("RptXuatFEController")]
        public class RptXuatFEController
        {
            public const string View = "Serene3:RptXuatFEController:View";
        }
        [DisplayName("TKeNXTController")]
        public class TKeNXTController
        {
            public const string View = "Serene3:TKeNXTController:View";
        }
    }
}
