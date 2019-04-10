
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

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblHopDong_ChiTiet]")]
    [DisplayName("Tbl Hop Dong Chi Tiet"), InstanceName("Tbl Hop Dong Chi Tiet")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TblHopDong_ChiTietRow : Row, IIdRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Hd"), Column("MaHD"), ForeignKey("[dbo].[tblHopDong]", "KeyID"), LeftJoin("jMaHd"), TextualField("MaHdNoiDung")]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
        }

        [PrimaryKey, DisplayName("Ma Btp"), Column("MaBTP"), ForeignKey("[dbo].[tblBanThanhPham]", "KeyID"), LeftJoin("jMaBtp"), TextualField("MaBtpMotaBtp")]
        public Int32? MaBtp
        {
            get { return Fields.MaBtp[this]; }
            set { Fields.MaBtp[this] = value; }
        }

        [PrimaryKey,DisplayName("Ma Mau"), ForeignKey("[dbo].[tblRef_Mau]", "KeyID"), LeftJoin("jMaMau"), TextualField("MaMau1")]
        public Int32? MaMau
        {
            get { return Fields.MaMau[this]; }
            set { Fields.MaMau[this] = value; }
        }

        [DisplayName("Ma Size"), ForeignKey("[dbo].[tblRef_Size]", "KeyID"), LeftJoin("jMaSize"), TextualField("MaSize1")]
        public Int32? MaSize
        {
            get { return Fields.MaSize[this]; }
            set { Fields.MaSize[this] = value; }
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

        [DisplayName("Ma Hd Ma Kh"), Expression("jMaHd.[MaKH]")]
        public Int32? MaHdMaKh
        {
            get { return Fields.MaHdMaKh[this]; }
            set { Fields.MaHdMaKh[this] = value; }
        }

        [DisplayName("Ma Hd Ngay Hd"), Expression("jMaHd.[NgayHD]")]
        public DateTime? MaHdNgayHd
        {
            get { return Fields.MaHdNgayHd[this]; }
            set { Fields.MaHdNgayHd[this] = value; }
        }

        [DisplayName("Ma Hd Noi Dung"), Expression("jMaHd.[NoiDung]")]
        public String MaHdNoiDung
        {
            get { return Fields.MaHdNoiDung[this]; }
            set { Fields.MaHdNoiDung[this] = value; }
        }

        [DisplayName("Ma Hd Gia Tri"), Expression("jMaHd.[GiaTri]")]
        public Double? MaHdGiaTri
        {
            get { return Fields.MaHdGiaTri[this]; }
            set { Fields.MaHdGiaTri[this] = value; }
        }

        [DisplayName("Ma Hd So Hd"), Expression("jMaHd.[SoHD]")]
        public String MaHdSoHd
        {
            get { return Fields.MaHdSoHd[this]; }
            set { Fields.MaHdSoHd[this] = value; }
        }

        [DisplayName("Ma Hd Nv Tao"), Expression("jMaHd.[NV_Tao]")]
        public Int32? MaHdNvTao
        {
            get { return Fields.MaHdNvTao[this]; }
            set { Fields.MaHdNvTao[this] = value; }
        }

        [DisplayName("Ma Hd Ngay"), Expression("jMaHd.[Ngay]")]
        public DateTime? MaHdNgay
        {
            get { return Fields.MaHdNgay[this]; }
            set { Fields.MaHdNgay[this] = value; }
        }

        [DisplayName("Ma Btp Mota Btp"), Expression("jMaBtp.[MotaBTP]")]
        public String MaBtpMotaBtp
        {
            get { return Fields.MaBtpMotaBtp[this]; }
            set { Fields.MaBtpMotaBtp[this] = value; }
        }

        [DisplayName("Ma Btp Don Vi Tinh"), Expression("jMaBtp.[DonViTinh]")]
        public String MaBtpDonViTinh
        {
            get { return Fields.MaBtpDonViTinh[this]; }
            set { Fields.MaBtpDonViTinh[this] = value; }
        }

        [DisplayName("Ma Btp Ngay Tao"), Expression("jMaBtp.[NgayTao]")]
        public DateTime? MaBtpNgayTao
        {
            get { return Fields.MaBtpNgayTao[this]; }
            set { Fields.MaBtpNgayTao[this] = value; }
        }

        [DisplayName("Ma Btp Status"), Expression("jMaBtp.[Status]")]
        public Boolean? MaBtpStatus
        {
            get { return Fields.MaBtpStatus[this]; }
            set { Fields.MaBtpStatus[this] = value; }
        }

        [DisplayName("Ma Mau"), Expression("jMaMau.[MaMau]")]
        public String MaMau1
        {
            get { return Fields.MaMau1[this]; }
            set { Fields.MaMau1[this] = value; }
        }

        [DisplayName("Ma Mau Ten Mau"), Expression("jMaMau.[TenMau]")]
        public String MaMauTenMau
        {
            get { return Fields.MaMauTenMau[this]; }
            set { Fields.MaMauTenMau[this] = value; }
        }

        [DisplayName("Ma Size"), Expression("jMaSize.[MaSize]")]
        public String MaSize1
        {
            get { return Fields.MaSize1[this]; }
            set { Fields.MaSize1[this] = value; }
        }

        [DisplayName("Ma Size Ten Size"), Expression("jMaSize.[TenSize]")]
        public String MaSizeTenSize
        {
            get { return Fields.MaSizeTenSize[this]; }
            set { Fields.MaSizeTenSize[this] = value; }
        }
        // Ma Style
        [DisplayName("Ma Style"), ForeignKey("[dbo].[tblRef_Style]", "KeyID"), LeftJoin("jMaStyle"), TextualField("MaStyle1")]
        public Int32? MaStyle
        {
            get { return Fields.MaStyle[this]; }
            set { Fields.MaStyle[this] = value; }
        }

        [DisplayName("Ma Style Ten Style"), Expression("jMaStyle.[TenStyle]")]
        public String MaStyleTenStyle
        {
            get { return Fields.MaStyleTenStyle[this]; }
            set { Fields.MaStyleTenStyle[this] = value; }
        }
        [DisplayName("Adjust Detail"), MasterDetailRelation(foreignKey: "MaChiTiet_HD", IncludeColumns = "MaNvHoTen"), NotMapped]
        public List<TblHopDong_DieuChinhRow> AdjDetailList
        {
            get { return Fields.AdjDetailList[this]; }
            set { Fields.AdjDetailList[this] = value; }
        }
        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblHopDong_ChiTietRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaHd;
            public Int32Field MaBtp;
            public Int32Field MaMau;
            public Int32Field MaSize;
            public Int32Field SoLuong;
            public DoubleField DonGia;
            public DoubleField ThanhTien;
            public Int32Field MaStyle;
            public StringField MaStyleTenStyle;

            public Int32Field MaHdMaKh;
            public DateTimeField MaHdNgayHd;
            public StringField MaHdNoiDung;
            public DoubleField MaHdGiaTri;
            public StringField MaHdSoHd;
            public Int32Field MaHdNvTao;
            public DateTimeField MaHdNgay;

            public StringField MaBtpMotaBtp;
            public StringField MaBtpDonViTinh;
            public DateTimeField MaBtpNgayTao;
            public BooleanField MaBtpStatus;

            public StringField MaMau1;
            public StringField MaMauTenMau;

            public StringField MaSize1;
            public StringField MaSizeTenSize;
            public RowListField<TblHopDong_DieuChinhRow> AdjDetailList;
        }
    }
}
