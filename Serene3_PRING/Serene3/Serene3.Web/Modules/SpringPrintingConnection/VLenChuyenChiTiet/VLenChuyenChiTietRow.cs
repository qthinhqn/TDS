
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vLenChuyen_ChiTiet]")]
    [DisplayName("V Len Chuyen Chi Tiet"), InstanceName("V Len Chuyen Chi Tiet")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VLenChuyenChiTietRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id 1"), Column("KeyID_1"), NotNull]
        public Int32? KeyId1
        {
            get { return Fields.KeyId1[this]; }
            set { Fields.KeyId1[this] = value; }
        }

        [DisplayName("Ngay")]
        public DateTime? Ngay
        {
            get { return Fields.Ngay[this]; }
            set { Fields.Ngay[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId1; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Code; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VLenChuyenChiTietRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId1;
            public DateTimeField Ngay;
            public Int32Field SlLoiKh;
            public Int32Field SlLoiIn;
            public Int64Field CardId;
            public StringField Code;
            public StringField MaBtp;
            public Int32Field SlThuc;
            public StringField MaMau;
            public StringField MaSize;
            public StringField MaStyle;
		}
    }
}
