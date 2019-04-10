
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vTrangThai_BoBTP]")]
    [DisplayName("V Trang Thai Bo Btp"), InstanceName("V Trang Thai Bo Btp")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VTrangThaiBoBtpRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id 1"), Column("KeyID_1"), NotNull]
        public Int32? KeyId1
        {
            get { return Fields.KeyId1[this]; }
            set { Fields.KeyId1[this] = value; }
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

        [DisplayName("Ma Btp"), Column("MaBTP")]
        public Int32? MaBtp
        {
            get { return Fields.MaBtp[this]; }
            set { Fields.MaBtp[this] = value; }
        }

        [DisplayName("Ten Btp"), Column("TenBTP"), Size(50)]
        public String TenBtp
        {
            get { return Fields.TenBtp[this]; }
            set { Fields.TenBtp[this] = value; }
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

        [DisplayName("Ma Mau"), Size(50)]
        public String MaMau
        {
            get { return Fields.MaMau[this]; }
            set { Fields.MaMau[this] = value; }
        }

        [DisplayName("Ma Size"), Size(50)]
        public String MaSize
        {
            get { return Fields.MaSize[this]; }
            set { Fields.MaSize[this] = value; }
        }

        [DisplayName("Ma Style"), Size(50)]
        public String MaStyle
        {
            get { return Fields.MaStyle[this]; }
            set { Fields.MaStyle[this] = value; }
        }

        [DisplayName("Ngay1")]
        public DateTime? Ngay1
        {
            get { return Fields.Ngay1[this]; }
            set { Fields.Ngay1[this] = value; }
        }

        [DisplayName("Nhan Vien1")]
        public Int32? NhanVien1
        {
            get { return Fields.NhanVien1[this]; }
            set { Fields.NhanVien1[this] = value; }
        }

        [DisplayName("Ngay2")]
        public DateTime? Ngay2
        {
            get { return Fields.Ngay2[this]; }
            set { Fields.Ngay2[this] = value; }
        }

        [DisplayName("Nhan Vien2")]
        public Int32? NhanVien2
        {
            get { return Fields.NhanVien2[this]; }
            set { Fields.NhanVien2[this] = value; }
        }

        [DisplayName("Ngay3")]
        public DateTime? Ngay3
        {
            get { return Fields.Ngay3[this]; }
            set { Fields.Ngay3[this] = value; }
        }

        [DisplayName("Nhan Vien3")]
        public Int32? NhanVien3
        {
            get { return Fields.NhanVien3[this]; }
            set { Fields.NhanVien3[this] = value; }
        }

        [DisplayName("Ngay4")]
        public DateTime? Ngay4
        {
            get { return Fields.Ngay4[this]; }
            set { Fields.Ngay4[this] = value; }
        }

        [DisplayName("Nhan Vien4")]
        public Int32? NhanVien4
        {
            get { return Fields.NhanVien4[this]; }
            set { Fields.NhanVien4[this] = value; }
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

        [DisplayName("Ma Hd"), Column("MaHD")]
        public Int32? MaHd
        {
            get { return Fields.MaHd[this]; }
            set { Fields.MaHd[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId1; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Code; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VTrangThaiBoBtpRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId1;
            public Int64Field CardId;
            public StringField Code;
            public Int32Field MaBtp;
            public StringField TenBtp;
            public Int32Field SlThuc;
            public Int32Field SlLoiKh;
            public Int32Field SlLoiIn;
            public StringField MaMau;
            public StringField MaSize;
            public StringField MaStyle;
            public DateTimeField Ngay1;
            public Int32Field NhanVien1;
            public DateTimeField Ngay2;
            public Int32Field NhanVien2;
            public DateTimeField Ngay3;
            public Int32Field NhanVien3;
            public DateTimeField Ngay4;
            public Int32Field NhanVien4;
            public BooleanField HangMau;
            public BooleanField HangBu;
            public Int32Field MaHd;
		}
    }
}
