
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vNhapKho_SP]")]
    [DisplayName("V Nhap Kho Sp"), InstanceName("V Nhap Kho Sp")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VNhapKhoSpRow : Row, IIdRow, INameRow
    {
        [DisplayName("Expr1"), NotNull]
        public Int32? Expr1
        {
            get { return Fields.Expr1[this]; }
            set { Fields.Expr1[this] = value; }
        }

        [DisplayName("Key Id"), Column("KeyID"), NotNull]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH")]
        public Int32? MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Ten Kh"), Column("TenKH"), Size(50), QuickSearch]
        public String TenKh
        {
            get { return Fields.TenKh[this]; }
            set { Fields.TenKh[this] = value; }
        }

        [DisplayName("Ngay Nhap")]
        public DateTime? NgayNhap
        {
            get { return Fields.NgayNhap[this]; }
            set { Fields.NgayNhap[this] = value; }
        }

        [DisplayName("Nguoi Nhap")]
        public Int32? NguoiNhap
        {
            get { return Fields.NguoiNhap[this]; }
            set { Fields.NguoiNhap[this] = value; }
        }

        [DisplayName("Ghi Chu"), Size(50)]
        public String GhiChu
        {
            get { return Fields.GhiChu[this]; }
            set { Fields.GhiChu[this] = value; }
        }

        [DisplayName("Ma Btp"), Column("MaBTP"), Size(50)]
        public String MaBtp
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

        [DisplayName("Card Id"), Column("CardID")]
        public Int64? CardId
        {
            get { return Fields.CardId[this]; }
            set { Fields.CardId[this] = value; }
        }

        [DisplayName("Code"), Size(25)]
        public String Code
        {
            get { return Fields.Code[this]; }
            set { Fields.Code[this] = value; }
        }

        [DisplayName("Po"), Column("PO"), Size(50)]
        public String Po
        {
            get { return Fields.Po[this]; }
            set { Fields.Po[this] = value; }
        }

        [DisplayName("Fepo"), Column("FEPO"), Size(50)]
        public String Fepo
        {
            get { return Fields.Fepo[this]; }
            set { Fields.Fepo[this] = value; }
        }

        [DisplayName("Bul No")]
        public Int32? BulNo
        {
            get { return Fields.BulNo[this]; }
            set { Fields.BulNo[this] = value; }
        }

        [DisplayName("Table Num"), Size(50)]
        public String TableNum
        {
            get { return Fields.TableNum[this]; }
            set { Fields.TableNum[this] = value; }
        }

        [DisplayName("Buy"), Size(50)]
        public String Buy
        {
            get { return Fields.Buy[this]; }
            set { Fields.Buy[this] = value; }
        }

        [DisplayName("Style04"), Size(50)]
        public String Style04
        {
            get { return Fields.Style04[this]; }
            set { Fields.Style04[this] = value; }
        }

        [DisplayName("Col"), Column("COL"), Size(50)]
        public String Col
        {
            get { return Fields.Col[this]; }
            set { Fields.Col[this] = value; }
        }

        [DisplayName("Size"), Size(50)]
        public String Size
        {
            get { return Fields.Size[this]; }
            set { Fields.Size[this] = value; }
        }

        [DisplayName("Part"), Size(50)]
        public String Part
        {
            get { return Fields.Part[this]; }
            set { Fields.Part[this] = value; }
        }

        [DisplayName("Quantity")]
        public Int32? Quantity
        {
            get { return Fields.Quantity[this]; }
            set { Fields.Quantity[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Expr1; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenKh; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VNhapKhoSpRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Expr1;
            public Int32Field KeyId;
            public Int32Field MaKh;
            public StringField TenKh;
            public DateTimeField NgayNhap;
            public Int32Field NguoiNhap;
            public StringField GhiChu;
            public StringField MaBtp;
            public Int32Field SlThuc;
            public Int32Field SlLoiKh;
            public Int32Field SlLoiIn;
            public StringField MaMau;
            public StringField MaSize;
            public StringField MaStyle;
            public BooleanField HangMau;
            public BooleanField HangBu;
            public Int64Field CardId;
            public StringField Code;
            public StringField Po;
            public StringField Fepo;
            public Int32Field BulNo;
            public StringField TableNum;
            public StringField Buy;
            public StringField Style04;
            public StringField Col;
            public StringField Size;
            public StringField Part;
            public Int32Field Quantity;
		}
    }
}
