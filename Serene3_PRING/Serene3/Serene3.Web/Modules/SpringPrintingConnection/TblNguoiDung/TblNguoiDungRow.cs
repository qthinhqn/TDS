
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblNguoiDung]")]
    [DisplayName("Tbl Nguoi Dung"), InstanceName("Tbl Nguoi Dung")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblNguoiDungRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ho Ten"), Size(50), QuickSearch]
        public String HoTen
        {
            get { return Fields.HoTen[this]; }
            set { Fields.HoTen[this] = value; }
        }

        [DisplayName("SexID"), Size(25), NotNull, ForeignKey(typeof(TblRefSexRow)), LookupInclude, LeftJoin("jSex")]
        public String GioiTinh
        {
            get { return Fields.GioiTinh[this]; }
            set { Fields.GioiTinh[this] = value; }
        }
        [Origin("jSex"), DisplayName("SexName"), QuickSearch, LookupInclude]
        public String SexName
        {
            get { return Fields.SexName[this]; }
            set { Fields.SexName[this] = value; }
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get { return Fields.Phone[this]; }
            set { Fields.Phone[this] = value; }
        }

        [DisplayName("Mobile"), Size(50)]
        public String Mobile
        {
            get { return Fields.Mobile[this]; }
            set { Fields.Mobile[this] = value; }
        }

        [DisplayName("Email"), Size(50)]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Chuc Vu"), Size(50)]
        public String ChucVu
        {
            get { return Fields.ChucVu[this]; }
            set { Fields.ChucVu[this] = value; }
        }

        [DisplayName("Status")]
        public Boolean? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.HoTen; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblNguoiDungRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField HoTen;
            public StringField GioiTinh;
            public StringField SexName;
            public StringField Phone;
            public StringField Mobile;
            public StringField Email;
            public StringField ChucVu;
            public BooleanField Status;
		}
    }
}
