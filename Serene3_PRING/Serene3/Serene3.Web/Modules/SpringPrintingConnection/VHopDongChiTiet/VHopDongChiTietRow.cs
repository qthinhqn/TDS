
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vHopDong_ChiTiet]")]
    [DisplayName("V Hop Dong Chi Tiet"), InstanceName("V Hop Dong Chi Tiet")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VHopDongChiTietRow : Row, IIdRow, INameRow
    {
        [DisplayName("Ma Hd"), Column("MaHD"), NotNull]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
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

        [DisplayName("So Hd"), Column("SoHD"), Size(50)]
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

        [DisplayName("Ma Btp"), Column("MaBTP")]
        public Int32? MaBtp
        {
            get { return Fields.MaBtp[this]; }
            set { Fields.MaBtp[this] = value; }
        }

        [DisplayName("Mota Btp"), Column("MotaBTP"), Size(50)]
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
        public String MaMau
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
        public String MaSize
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
        public String MaStyle
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

        IIdField IIdRow.IdField
        {
            get { return Fields.MaHd; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.NoiDung; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VHopDongChiTietRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field MaHd;
            public DateTimeField NgayHd;
            public StringField NoiDung;
            public DoubleField GiaTri;
            public StringField SoHd;
            public StringField TenKh;
            public StringField MaKh;
            public Int32Field MaBtp;
            public StringField MotaBtp;
            public StringField DonViTinh;
            public StringField MaMau;
            public StringField TenMau;
            public StringField MaSize;
            public StringField TenSize;
            public StringField MaStyle;
            public StringField TenStyle;
            public Int32Field SoLuong;
            public DoubleField DonGia;
            public DoubleField ThanhTien;
		}
    }
}
