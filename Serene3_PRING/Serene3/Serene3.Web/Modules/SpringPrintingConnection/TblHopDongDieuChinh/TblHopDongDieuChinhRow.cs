
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblHopDong_DieuChinh]")]
    [DisplayName("Tbl Hop Dong Dieu Chinh"), InstanceName("Tbl Hop Dong Dieu Chinh")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TblHopDongDieuChinhRow : Row, IIdRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Hd"), Column("Ma_HD"), ForeignKey("[dbo].[tblHopDong_ChiTiet]", "KeyID"), LeftJoin("jMaHd")]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
        }

        [DisplayName("Sl Nhan"), Column("SL_Nhan")]
        public Int32? SlNhan
        {
            get { return Fields.SlNhan[this]; }
            set { Fields.SlNhan[this] = value; }
        }

        [DisplayName("Sl Nhan Hu"), Column("SL_NhanHu")]
        public Int32? SlNhanHu
        {
            get { return Fields.SlNhanHu[this]; }
            set { Fields.SlNhanHu[this] = value; }
        }

        [DisplayName("Sl In Hu"), Column("SL_InHu")]
        public Int32? SlInHu
        {
            get { return Fields.SlInHu[this]; }
            set { Fields.SlInHu[this] = value; }
        }

        [DisplayName("Sl Xuat"), Column("SL_Xuat")]
        public Int32? SlXuat
        {
            get { return Fields.SlXuat[this]; }
            set { Fields.SlXuat[this] = value; }
        }

        [DisplayName("Ma Nv"), Column("MaNV"), ForeignKey("[dbo].[tblNguoiDung]", "KeyID"), LeftJoin("jMaNv"), TextualField("MaNvHoTen")]
        public Int32? MaNv
        {
            get { return Fields.MaNv[this]; }
            set { Fields.MaNv[this] = value; }
        }

        [DisplayName("Ngay Dc"), Column("NgayDC")]
        public DateTime? NgayDc
        {
            get { return Fields.NgayDc[this]; }
            set { Fields.NgayDc[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd"), Column("MaChiTiet_HD"), ForeignKey("[dbo].[tblHopDong_ChiTiet]", "KeyID"), LeftJoin("jMaChiTietHd")]
        public Int32? MaChiTietHd
        {
            get { return Fields.MaChiTietHd[this]; }
            set { Fields.MaChiTietHd[this] = value; }
        }

        [DisplayName("Ma Hd"), Expression("jMaHd.[MaHD]")]
        public Int32? MaHd1
        {
            get { return Fields.MaHd1[this]; }
            set { Fields.MaHd1[this] = value; }
        }

        [DisplayName("Ma Hd Ma Btp"), Expression("jMaHd.[MaBTP]")]
        public Int32? MaHdMaBtp
        {
            get { return Fields.MaHdMaBtp[this]; }
            set { Fields.MaHdMaBtp[this] = value; }
        }

        [DisplayName("Ma Hd Ma Mau"), Expression("jMaHd.[MaMau]")]
        public Int32? MaHdMaMau
        {
            get { return Fields.MaHdMaMau[this]; }
            set { Fields.MaHdMaMau[this] = value; }
        }

        [DisplayName("Ma Hd Ma Size"), Expression("jMaHd.[MaSize]")]
        public Int32? MaHdMaSize
        {
            get { return Fields.MaHdMaSize[this]; }
            set { Fields.MaHdMaSize[this] = value; }
        }

        [DisplayName("Ma Hd So Luong"), Expression("jMaHd.[SoLuong]")]
        public Int32? MaHdSoLuong
        {
            get { return Fields.MaHdSoLuong[this]; }
            set { Fields.MaHdSoLuong[this] = value; }
        }

        [DisplayName("Ma Hd Don Gia"), Expression("jMaHd.[DonGia]")]
        public Double? MaHdDonGia
        {
            get { return Fields.MaHdDonGia[this]; }
            set { Fields.MaHdDonGia[this] = value; }
        }

        [DisplayName("Ma Hd Thanh Tien"), Expression("jMaHd.[ThanhTien]")]
        public Double? MaHdThanhTien
        {
            get { return Fields.MaHdThanhTien[this]; }
            set { Fields.MaHdThanhTien[this] = value; }
        }

        [DisplayName("Ma Hd Ma Style"), Expression("jMaHd.[MaStyle]")]
        public Int32? MaHdMaStyle
        {
            get { return Fields.MaHdMaStyle[this]; }
            set { Fields.MaHdMaStyle[this] = value; }
        }

        [DisplayName("Ma Nv Ho Ten"), Expression("jMaNv.[HoTen]")]
        public String MaNvHoTen
        {
            get { return Fields.MaNvHoTen[this]; }
            set { Fields.MaNvHoTen[this] = value; }
        }

        [DisplayName("Ma Nv Gioi Tinh"), Expression("jMaNv.[GioiTinh]")]
        public String MaNvGioiTinh
        {
            get { return Fields.MaNvGioiTinh[this]; }
            set { Fields.MaNvGioiTinh[this] = value; }
        }

        [DisplayName("Ma Nv Phone"), Expression("jMaNv.[Phone]")]
        public String MaNvPhone
        {
            get { return Fields.MaNvPhone[this]; }
            set { Fields.MaNvPhone[this] = value; }
        }

        [DisplayName("Ma Nv Mobile"), Expression("jMaNv.[Mobile]")]
        public String MaNvMobile
        {
            get { return Fields.MaNvMobile[this]; }
            set { Fields.MaNvMobile[this] = value; }
        }

        [DisplayName("Ma Nv Email"), Expression("jMaNv.[Email]")]
        public String MaNvEmail
        {
            get { return Fields.MaNvEmail[this]; }
            set { Fields.MaNvEmail[this] = value; }
        }

        [DisplayName("Ma Nv Chuc Vu"), Expression("jMaNv.[ChucVu]")]
        public String MaNvChucVu
        {
            get { return Fields.MaNvChucVu[this]; }
            set { Fields.MaNvChucVu[this] = value; }
        }

        [DisplayName("Ma Nv Status"), Expression("jMaNv.[Status]")]
        public Boolean? MaNvStatus
        {
            get { return Fields.MaNvStatus[this]; }
            set { Fields.MaNvStatus[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Ma Hd"), Expression("jMaChiTietHd.[MaHD]")]
        public Int32? MaChiTietHdMaHd
        {
            get { return Fields.MaChiTietHdMaHd[this]; }
            set { Fields.MaChiTietHdMaHd[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Ma Btp"), Expression("jMaChiTietHd.[MaBTP]")]
        public Int32? MaChiTietHdMaBtp
        {
            get { return Fields.MaChiTietHdMaBtp[this]; }
            set { Fields.MaChiTietHdMaBtp[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Ma Mau"), Expression("jMaChiTietHd.[MaMau]")]
        public Int32? MaChiTietHdMaMau
        {
            get { return Fields.MaChiTietHdMaMau[this]; }
            set { Fields.MaChiTietHdMaMau[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Ma Size"), Expression("jMaChiTietHd.[MaSize]")]
        public Int32? MaChiTietHdMaSize
        {
            get { return Fields.MaChiTietHdMaSize[this]; }
            set { Fields.MaChiTietHdMaSize[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd So Luong"), Expression("jMaChiTietHd.[SoLuong]")]
        public Int32? MaChiTietHdSoLuong
        {
            get { return Fields.MaChiTietHdSoLuong[this]; }
            set { Fields.MaChiTietHdSoLuong[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Don Gia"), Expression("jMaChiTietHd.[DonGia]")]
        public Double? MaChiTietHdDonGia
        {
            get { return Fields.MaChiTietHdDonGia[this]; }
            set { Fields.MaChiTietHdDonGia[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Thanh Tien"), Expression("jMaChiTietHd.[ThanhTien]")]
        public Double? MaChiTietHdThanhTien
        {
            get { return Fields.MaChiTietHdThanhTien[this]; }
            set { Fields.MaChiTietHdThanhTien[this] = value; }
        }

        [DisplayName("Ma Chi Tiet Hd Ma Style"), Expression("jMaChiTietHd.[MaStyle]")]
        public Int32? MaChiTietHdMaStyle
        {
            get { return Fields.MaChiTietHdMaStyle[this]; }
            set { Fields.MaChiTietHdMaStyle[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblHopDongDieuChinhRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaHd;
            public Int32Field SlNhan;
            public Int32Field SlNhanHu;
            public Int32Field SlInHu;
            public Int32Field SlXuat;
            public Int32Field MaNv;
            public DateTimeField NgayDc;
            public Int32Field MaChiTietHd;

            public Int32Field MaHd1;
            public Int32Field MaHdMaBtp;
            public Int32Field MaHdMaMau;
            public Int32Field MaHdMaSize;
            public Int32Field MaHdSoLuong;
            public DoubleField MaHdDonGia;
            public DoubleField MaHdThanhTien;
            public Int32Field MaHdMaStyle;

            public StringField MaNvHoTen;
            public StringField MaNvGioiTinh;
            public StringField MaNvPhone;
            public StringField MaNvMobile;
            public StringField MaNvEmail;
            public StringField MaNvChucVu;
            public BooleanField MaNvStatus;

            public Int32Field MaChiTietHdMaHd;
            public Int32Field MaChiTietHdMaBtp;
            public Int32Field MaChiTietHdMaMau;
            public Int32Field MaChiTietHdMaSize;
            public Int32Field MaChiTietHdSoLuong;
            public DoubleField MaChiTietHdDonGia;
            public DoubleField MaChiTietHdThanhTien;
            public Int32Field MaChiTietHdMaStyle;
		}
    }
}
