
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblBo_BTP]")]
    [DisplayName("Tbl Bo Btp"), InstanceName("Tbl Bo Btp")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblBo_BTPRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Lo"), ForeignKey("[dbo].[tblLo_SP]", "KeyID"), LeftJoin("jMaLo"), TextualField("MaLoGhiChu")]
        public Int32? MaLo
        {
            get { return Fields.MaLo[this]; }
            set { Fields.MaLo[this] = value; }
        }

        [DisplayName("Ma Btp"), Column("MaBTP"), ForeignKey("[dbo].[tblBanThanhPham]", "KeyID"), LeftJoin("jMaBtp"), TextualField("MaBtpMotaBtp")]
        public Int32? MaBtp
        {
            get { return Fields.MaBtp[this]; }
            set { Fields.MaBtp[this] = value; }
        }

        [DisplayName("Sl Thuc"), Column("SL_Thuc")]
        public Int32? SlThuc
        {
            get { return Fields.SlThuc[this]; }
            set { Fields.SlThuc[this] = value; }
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

        [DisplayName("Ma In"), Column("MaIN")]
        public Int32? MaIn
        {
            get { return Fields.MaIn[this]; }
            set { Fields.MaIn[this] = value; }
        }

        [DisplayName("Ma Out"), Column("MaOUT")]
        public Int32? MaOut
        {
            get { return Fields.MaOut[this]; }
            set { Fields.MaOut[this] = value; }
        }

        [DisplayName("Ma Len Chuyen")]
        public Int32? MaLenChuyen
        {
            get { return Fields.MaLenChuyen[this]; }
            set { Fields.MaLenChuyen[this] = value; }
        }

        [DisplayName("Ma Xuong Chuyen")]
        public Int32? MaXuongChuyen
        {
            get { return Fields.MaXuongChuyen[this]; }
            set { Fields.MaXuongChuyen[this] = value; }
        }

        [DisplayName("Ma Mau"), ForeignKey("[dbo].[tblRef_Mau]", "KeyID"), LeftJoin("jMaMau"), TextualField("MaMau1")]
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

        [DisplayName("Hang Mau")]
        public Boolean? HangMau
        {
            get { return Fields.HangMau[this]; }
            set { Fields.HangMau[this] = value; }
        }

        [DisplayName("Hang Bu")]
        public Boolean? HangBu
        {
            get { return Fields.HangBu[this]; }
            set { Fields.HangBu[this] = value; }
        }

        [DisplayName("Ma Hd"), Column("MaHD"), ForeignKey("[dbo].[tblHopDong]", "KeyID"), LeftJoin("jMaHd"), TextualField("MaHdNoiDung")]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
        }

        [DisplayName("Card Id"), Column("CardID")]
        public Int64? CardId
        {
            get { return Fields.CardId[this]; }
            set { Fields.CardId[this] = value; }
        }

        [DisplayName("Code"), Size(25), QuickSearch]
        public String Code
        {
            get { return Fields.Code[this]; }
            set { Fields.Code[this] = value; }
        }

        [DisplayName("Ma Fe Stock Out"), Column("MaFE_StockOut")]
        public Guid? MaFeStockOut
        {
            get { return Fields.MaFeStockOut[this]; }
            set { Fields.MaFeStockOut[this] = value; }
        }


        [DisplayName("Ma Lo Ma Kh"), Expression("jMaLo.[MaKH]")]
        public Int32? MaLoMaKh
        {
            get { return Fields.MaLoMaKh[this]; }
            set { Fields.MaLoMaKh[this] = value; }
        }

        [DisplayName("Ma Lo Ngay Nhap"), Expression("jMaLo.[NgayNhap]")]
        public DateTime? MaLoNgayNhap
        {
            get { return Fields.MaLoNgayNhap[this]; }
            set { Fields.MaLoNgayNhap[this] = value; }
        }

        [DisplayName("Ma Lo Nguoi Nhap"), Expression("jMaLo.[NguoiNhap]")]
        public Int32? MaLoNguoiNhap
        {
            get { return Fields.MaLoNguoiNhap[this]; }
            set { Fields.MaLoNguoiNhap[this] = value; }
        }

        [DisplayName("Ma Lo So Luong"), Expression("jMaLo.[SoLuong]")]
        public Int32? MaLoSoLuong
        {
            get { return Fields.MaLoSoLuong[this]; }
            set { Fields.MaLoSoLuong[this] = value; }
        }

        [DisplayName("Ma Lo Ghi Chu"), Expression("jMaLo.[GhiChu]")]
        public String MaLoGhiChu
        {
            get { return Fields.MaLoGhiChu[this]; }
            set { Fields.MaLoGhiChu[this] = value; }
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

        [DisplayName("Ma Style 1"), Expression("jMaStyle.[MaStyle]")]
        public String MaStyle1
        {
            get { return Fields.MaStyle1[this]; }
            set { Fields.MaStyle1[this] = value; }
        }

        [DisplayName("Ma Style Ten Style"), Expression("jMaStyle.[TenStyle]")]
        public String MaStyleTenStyle
        {
            get { return Fields.MaStyleTenStyle[this]; }
            set { Fields.MaStyleTenStyle[this] = value; }
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
        
        [DisplayName("Ma Type"), ForeignKey("[dbo].[tblRef_Type]", "TypeID"), LeftJoin("jMaType"), TextualField("TypeID1")]
        public String TypeID
        {
            get { return Fields.TypeID[this]; }
            set { Fields.TypeID[this] = value; }
        }

        [DisplayName("Ma Type 1"), Expression("jMaType.[TypeID]")]
        public String TypeID1
        {
            get { return Fields.TypeID1[this]; }
            set { Fields.TypeID1[this] = value; }
        }

        [DisplayName("Ma Type Ten Type"), Expression("jMaType.[TypeName]")]
        public String MaTypeTenType
        {
            get { return Fields.MaTypeTenType[this]; }
            set { Fields.MaTypeTenType[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MaBtpMotaBtp; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblBo_BTPRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaLo;
            public Int32Field MaBtp;
            public Int32Field SlThuc;
            public Int32Field SlLoiKh;
            public Int32Field SlLoiIn;
            public Int32Field MaIn;
            public Int32Field MaOut;
            public Int32Field MaLenChuyen;
            public Int32Field MaXuongChuyen;
            public Int32Field MaMau;
            public Int32Field MaSize;
            public BooleanField HangMau;
            public BooleanField HangBu;
            public Int32Field MaHd;
            public Int64Field CardId;
            public StringField Code;
            public GuidField MaFeStockOut;
            public Int32Field MaStyle;
            public StringField TypeID;

            public Int32Field MaLoMaKh;
            public DateTimeField MaLoNgayNhap;
            public Int32Field MaLoNguoiNhap;
            public Int32Field MaLoSoLuong;
            public StringField MaLoGhiChu;

            public StringField MaBtpMotaBtp;
            public StringField MaBtpDonViTinh;
            public DateTimeField MaBtpNgayTao;
            public BooleanField MaBtpStatus;

            public StringField MaMau1;
            public StringField MaMauTenMau;

            public StringField MaSize1;
            public StringField MaSizeTenSize;

            public StringField MaStyle1;
            public StringField MaStyleTenStyle;

            public Int32Field MaHdMaKh;
            public DateTimeField MaHdNgayHd;
            public StringField MaHdNoiDung;
            public DoubleField MaHdGiaTri;
            public StringField MaHdSoHd;
            public Int32Field MaHdNvTao;
            public DateTimeField MaHdNgay;

            public StringField TypeID1;
            public StringField MaTypeTenType;
		}
    }
}
