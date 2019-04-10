
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

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblLo_SP]")]
    [DisplayName("Tbl Lo Sp"), InstanceName("Tbl Lo Sp")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.TblLoSp.View)]
    [ModifyPermission(PermissionKeys.TblLoSp.Modify)]
    [DeletePermission(PermissionKeys.TblLoSp.Delete)]
    [LookupScript]
    public sealed class TblLoSpRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH"), NotNull, ForeignKey(typeof(TblKhachHangRow)), LookupInclude, LeftJoin("jKhachHang")]
        public Int32? MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [Origin("jKhachHang"), DisplayName("TenKH"), QuickSearch, LookupInclude]
        public String TenKH
        {
            get { return Fields.TenKH[this]; }
            set { Fields.TenKH[this] = value; }
        }

        [DisplayName("Ngay Nhap")]
        public DateTime? NgayNhap
        {
            get { return Fields.NgayNhap[this]; }
            set { Fields.NgayNhap[this] = value; }
        }

        [DisplayName("Nguoi Nhap"), ForeignKey("[dbo].[tblNguoiDung]", "KeyID"), LeftJoin("jNguoiNhap"), TextualField("NguoiNhapHoTen")]
        public Int32? NguoiNhap
        {
            get { return Fields.NguoiNhap[this]; }
            set { Fields.NguoiNhap[this] = value; }
        }

        [DisplayName("So Luong")]
        public Int32? SoLuong
        {
            get { return Fields.SoLuong[this]; }
            set { Fields.SoLuong[this] = value; }
        }

        [DisplayName("Ghi Chu"), Size(50), QuickSearch]
        public String GhiChu
        {
            get { return Fields.GhiChu[this]; }
            set { Fields.GhiChu[this] = value; }
        }

        [DisplayName("Nguoi Nhap Ho Ten"), Expression("jNguoiNhap.[HoTen]")]
        public String NguoiNhapHoTen
        {
            get { return Fields.NguoiNhapHoTen[this]; }
            set { Fields.NguoiNhapHoTen[this] = value; }
        }

        [DisplayName("Nguoi Nhap Gioi Tinh"), Expression("jNguoiNhap.[GioiTinh]")]
        public String NguoiNhapGioiTinh
        {
            get { return Fields.NguoiNhapGioiTinh[this]; }
            set { Fields.NguoiNhapGioiTinh[this] = value; }
        }

        [DisplayName("Nguoi Nhap Phone"), Expression("jNguoiNhap.[Phone]")]
        public String NguoiNhapPhone
        {
            get { return Fields.NguoiNhapPhone[this]; }
            set { Fields.NguoiNhapPhone[this] = value; }
        }

        [DisplayName("Nguoi Nhap Mobile"), Expression("jNguoiNhap.[Mobile]")]
        public String NguoiNhapMobile
        {
            get { return Fields.NguoiNhapMobile[this]; }
            set { Fields.NguoiNhapMobile[this] = value; }
        }

        [DisplayName("Nguoi Nhap Email"), Expression("jNguoiNhap.[Email]")]
        public String NguoiNhapEmail
        {
            get { return Fields.NguoiNhapEmail[this]; }
            set { Fields.NguoiNhapEmail[this] = value; }
        }

        [DisplayName("Nguoi Nhap Chuc Vu"), Expression("jNguoiNhap.[ChucVu]")]
        public String NguoiNhapChucVu
        {
            get { return Fields.NguoiNhapChucVu[this]; }
            set { Fields.NguoiNhapChucVu[this] = value; }
        }

        [DisplayName("Nguoi Nhap Status"), Expression("jNguoiNhap.[Status]")]
        public Boolean? NguoiNhapStatus
        {
            get { return Fields.NguoiNhapStatus[this]; }
            set { Fields.NguoiNhapStatus[this] = value; }
        }

        [DisplayName("Ma the quet"), NotMapped]
        public String Note
        {
            get { return Fields.Note[this]; }
            set { Fields.Note[this] = value; }
        }
  
        [DisplayName("Details"), MasterDetailRelation(foreignKey: "MaLo", IncludeColumns = "MaBtpMotaBtp,MaMauTenMau,MaSizeTenSize,MaStyleTenStyle"), NotMapped]
        public List<TblBo_BTPRow> DetailList
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
            get { return Fields.TenKH; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblLoSpRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaKh;
            public DateTimeField NgayNhap;
            public Int32Field NguoiNhap;
            public Int32Field SoLuong;
            public StringField GhiChu;
            public StringField TenKH;

            public StringField NguoiNhapHoTen;
            public StringField NguoiNhapGioiTinh;
            public StringField NguoiNhapPhone;
            public StringField NguoiNhapMobile;
            public StringField NguoiNhapEmail;
            public StringField NguoiNhapChucVu;
            public BooleanField NguoiNhapStatus;

            public StringField Note;
            public RowListField<TblBo_BTPRow> DetailList;

        }
    }
}
