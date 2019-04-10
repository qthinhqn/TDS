
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblHopDong]")]
    [DisplayName("Tbl Hop Dong"), InstanceName("Tbl Hop Dong")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.TblHopDong.View)]
    [ModifyPermission(PermissionKeys.TblHopDong.Modify)]
    [DeletePermission(PermissionKeys.TblHopDong.Delete)]
    [LookupScript]
    public sealed class TblHopDongRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH"), ForeignKey("[dbo].[tblKhachHang]", "KeyID"), LeftJoin("jMaKh"), TextualField("MaKh1")]
        public Int32? MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Ngay Hd"), Column("NgayHD")]
        public DateTime? NgayHd
        {
            get { return Fields.NgayHd[this]; }
            set { Fields.NgayHd[this] = value; }
        }

        [DisplayName("Noi Dung"), QuickSearch(SearchType.Contains)]
        public String NoiDung
        {
            get { return Fields.NoiDung[this]; }
            set { Fields.NoiDung[this] = value; }
        }

        [DisplayName("Gia Tri")]
        public Double? GiaTri
        {
            get { return Fields.GiaTri[this]; }
            set { Fields.GiaTri[this] = value; }
        }

        [DisplayName("So Hd"), Column("SoHD"), Size(50), Unique, QuickSearch(SearchType.Contains)]
        public String SoHd
        {
            get { return Fields.SoHd[this]; }
            set { Fields.SoHd[this] = value; }
        }

        [DisplayName("Nv Tao"), Column("NV_Tao"), ForeignKey("[dbo].[tblNguoiDung]", "KeyID"), LeftJoin("jNvTao"), TextualField("NvTaoHoTen")]
        public Int32? NvTao
        {
            get { return Fields.NvTao[this]; }
            set { Fields.NvTao[this] = value; }
        }

        [DisplayName("Ngay")]
        public DateTime? Ngay
        {
            get { return Fields.Ngay[this]; }
            set { Fields.Ngay[this] = value; }
        }

        [DisplayName("Ma Kh"), Expression("jMaKh.[MaKH]")]
        public String MaKh1
        {
            get { return Fields.MaKh1[this]; }
            set { Fields.MaKh1[this] = value; }
        }

        [DisplayName("Ma Kh Ten Kh"), Expression("jMaKh.[TenKH]")]
        public String MaKhTenKh
        {
            get { return Fields.MaKhTenKh[this]; }
            set { Fields.MaKhTenKh[this] = value; }
        }

        [DisplayName("Ma Kh Dia Chi"), Expression("jMaKh.[DiaChi]")]
        public String MaKhDiaChi
        {
            get { return Fields.MaKhDiaChi[this]; }
            set { Fields.MaKhDiaChi[this] = value; }
        }

        [DisplayName("Ma Kh Nguoi Dai Dien"), Expression("jMaKh.[NguoiDaiDien]")]
        public Int32? MaKhNguoiDaiDien
        {
            get { return Fields.MaKhNguoiDaiDien[this]; }
            set { Fields.MaKhNguoiDaiDien[this] = value; }
        }

        [DisplayName("Ma Kh Phone"), Expression("jMaKh.[Phone]")]
        public String MaKhPhone
        {
            get { return Fields.MaKhPhone[this]; }
            set { Fields.MaKhPhone[this] = value; }
        }

        [DisplayName("Ma Kh Mst"), Expression("jMaKh.[MST]")]
        public String MaKhMst
        {
            get { return Fields.MaKhMst[this]; }
            set { Fields.MaKhMst[this] = value; }
        }

        [DisplayName("Nv Tao Ho Ten"), Expression("jNvTao.[HoTen]")]
        public String NvTaoHoTen
        {
            get { return Fields.NvTaoHoTen[this]; }
            set { Fields.NvTaoHoTen[this] = value; }
        }

        [DisplayName("Nv Tao Gioi Tinh"), Expression("jNvTao.[GioiTinh]")]
        public String NvTaoGioiTinh
        {
            get { return Fields.NvTaoGioiTinh[this]; }
            set { Fields.NvTaoGioiTinh[this] = value; }
        }

        [DisplayName("Nv Tao Phone"), Expression("jNvTao.[Phone]")]
        public String NvTaoPhone
        {
            get { return Fields.NvTaoPhone[this]; }
            set { Fields.NvTaoPhone[this] = value; }
        }

        [DisplayName("Nv Tao Mobile"), Expression("jNvTao.[Mobile]")]
        public String NvTaoMobile
        {
            get { return Fields.NvTaoMobile[this]; }
            set { Fields.NvTaoMobile[this] = value; }
        }

        [DisplayName("Nv Tao Email"), Expression("jNvTao.[Email]")]
        public String NvTaoEmail
        {
            get { return Fields.NvTaoEmail[this]; }
            set { Fields.NvTaoEmail[this] = value; }
        }

        [DisplayName("Nv Tao Chuc Vu"), Expression("jNvTao.[ChucVu]")]
        public String NvTaoChucVu
        {
            get { return Fields.NvTaoChucVu[this]; }
            set { Fields.NvTaoChucVu[this] = value; }
        }

        [DisplayName("Nv Tao Status"), Expression("jNvTao.[Status]")]
        public Boolean? NvTaoStatus
        {
            get { return Fields.NvTaoStatus[this]; }
            set { Fields.NvTaoStatus[this] = value; }
        }

        [DisplayName("Details"), MasterDetailRelation(foreignKey: "MaHD", IncludeColumns = "MaHdNoiDung,MaBtp,MaMauTenMau,MaSizeTenSize,MaStyleTenStyle,MaBtpMotaBtp"), NotMapped]
        public List<TblHopDong_ChiTietRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.SoHd; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblHopDongRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaKh;
            public DateTimeField NgayHd;
            public StringField NoiDung;
            public DoubleField GiaTri;
            public StringField SoHd;
            public Int32Field NvTao;
            public DateTimeField Ngay;

            public StringField MaKh1;
            public StringField MaKhTenKh;
            public StringField MaKhDiaChi;
            public Int32Field MaKhNguoiDaiDien;
            public StringField MaKhPhone;
            public StringField MaKhMst;

            public StringField NvTaoHoTen;
            public StringField NvTaoGioiTinh;
            public StringField NvTaoPhone;
            public StringField NvTaoMobile;
            public StringField NvTaoEmail;
            public StringField NvTaoChucVu;
            public BooleanField NvTaoStatus;

            public RowListField<TblHopDong_ChiTietRow> DetailList;
        }
    }
}
