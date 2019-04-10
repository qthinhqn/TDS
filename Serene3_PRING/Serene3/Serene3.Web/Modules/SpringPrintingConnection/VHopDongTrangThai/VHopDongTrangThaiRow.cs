
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vHopDong_TrangThai]")]
    [DisplayName("V Hop Dong Trang Thai"), InstanceName("V Hop Dong Trang Thai")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.VHopDongTrangThai.View)]
    public sealed class VHopDongTrangThaiRow : Row, IIdRow, INameRow
    {
        [DisplayName("Ma Hd"), Column("MaHD"), NotNull]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
        }
        [DisplayName("Ma CT"), Column("MaCT"), NotNull]
        public Int32? MaCT
        {
            get { return Fields.MaCT[this]; }
            set { Fields.MaCT[this] = value; }
        }

        [DisplayName("Ngay Hd"), Column("NgayHD")]
        public DateTime? NgayHd
        {
            get { return Fields.NgayHd[this]; }
            set { Fields.NgayHd[this] = value; }
        }

        [DisplayName("Noi Dung"), QuickSearch]
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

        [DisplayName("So Hd"), Column("SoHD"), Size(50), QuickSearch]
        public String SoHd
        {
            get { return Fields.SoHd[this]; }
            set { Fields.SoHd[this] = value; }
        }

        [DisplayName("Ten Kh"), Column("TenKH"), Size(50)]
        public String TenKh
        {
            get { return Fields.TenKh[this]; }
            set { Fields.TenKh[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH"), Size(50)]
        public String MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Mota Btp"), Column("MotaBTP"), Size(50), QuickSearch]
        public String MotaBtp
        {
            get { return Fields.MotaBtp[this]; }
            set { Fields.MotaBtp[this] = value; }
        }

        [DisplayName("Don Vi Tinh"), Size(50)]
        public String DonViTinh
        {
            get { return Fields.DonViTinh[this]; }
            set { Fields.DonViTinh[this] = value; }
        }

        [DisplayName("Ma Mau"), Size(50)]
        public Int32? MaMau
        {
            get { return Fields.MaMau[this]; }
            set { Fields.MaMau[this] = value; }
        }

        [DisplayName("Ten Mau"), Size(50)]
        public String TenMau
        {
            get { return Fields.TenMau[this]; }
            set { Fields.TenMau[this] = value; }
        }

        [DisplayName("Ma Size"), Size(50)]
        public Int32? MaSize
        {
            get { return Fields.MaSize[this]; }
            set { Fields.MaSize[this] = value; }
        }

        [DisplayName("Ten Size"), Size(50)]
        public String TenSize
        {
            get { return Fields.TenSize[this]; }
            set { Fields.TenSize[this] = value; }
        }

        [DisplayName("Ma Style"), Size(50)]
        public Int32? MaStyle
        {
            get { return Fields.MaStyle[this]; }
            set { Fields.MaStyle[this] = value; }
        }

        [DisplayName("Ten Style"), Size(50)]
        public String TenStyle
        {
            get { return Fields.TenStyle[this]; }
            set { Fields.TenStyle[this] = value; }
        }

        [DisplayName("So Luong")]
        public Int32? SoLuong
        {
            get { return Fields.SoLuong[this]; }
            set { Fields.SoLuong[this] = value; }
        }

        [DisplayName("Don Gia")]
        public Double? DonGia
        {
            get { return Fields.DonGia[this]; }
            set { Fields.DonGia[this] = value; }
        }

        [DisplayName("Thanh Tien")]
        public Double? ThanhTien
        {
            get { return Fields.ThanhTien[this]; }
            set { Fields.ThanhTien[this] = value; }
        }

        [DisplayName("Sl Nhap"), Column("SL_Nhap")]
        public Int32? SlNhap
        {
            get { return Fields.SlNhap[this]; }
            set { Fields.SlNhap[this] = value; }
        }

        [DisplayName("Sl Loi Kh"), Column("SL_Loi_KH")]
        public Int32? SlLoiKh
        {
            get { return Fields.SlLoiKh[this]; }
            set { Fields.SlLoiKh[this] = value; }
        }

        [DisplayName("Sl Loi In"), Column("SL_Loi_In")]
        public Int32? SlLoiIn
        {
            get { return Fields.SlLoiIn[this]; }
            set { Fields.SlLoiIn[this] = value; }
        }

        [DisplayName("Sl Thuc Xuat"), Column("SL_Thuc_Xuat")]
        public Int32? SlThucXuat
        {
            get { return Fields.SlThucXuat[this]; }
            set { Fields.SlThucXuat[this] = value; }
        }

        [DisplayName("Sl Thieu"), Column("SL_Thieu")]
        public Int32? SlThieu
        {
            get { return Fields.SlThieu[this]; }
            set { Fields.SlThieu[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MaCT; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NoiDung; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VHopDongTrangThaiRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field MaHd;
            public Int32Field MaCT;
            public DateTimeField NgayHd;
            public StringField NoiDung;
            public DoubleField GiaTri;
            public StringField SoHd;
            public StringField TenKh;
            public StringField MaKh;
            public StringField MotaBtp;
            public StringField DonViTinh;
            public Int32Field MaMau;
            public StringField TenMau;
            public Int32Field MaSize;
            public StringField TenSize;
            public Int32Field MaStyle;
            public StringField TenStyle;
            public Int32Field SoLuong;
            public DoubleField DonGia;
            public DoubleField ThanhTien;
            public Int32Field SlNhap;
            public Int32Field SlLoiKh;
            public Int32Field SlLoiIn;
            public Int32Field SlThucXuat;
            public Int32Field SlThieu;
        }
    }
}
