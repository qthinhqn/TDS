
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblKhachHang]")]
    [DisplayName("Tbl Khach Hang"), InstanceName("Tbl Khach Hang")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblKhachHangRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH"), Size(50), QuickSearch]
        public String MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Ten Kh"), Column("TenKH"), Size(50)]
        public String TenKh
        {
            get { return Fields.TenKh[this]; }
            set { Fields.TenKh[this] = value; }
        }

        [DisplayName("Dia Chi"), Size(50)]
        public String DiaChi
        {
            get { return Fields.DiaChi[this]; }
            set { Fields.DiaChi[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien"), ForeignKey("[dbo].[tblRef_NguoiDaiDien]", "KeyID"), LeftJoin("jNguoiDaiDien"), TextualField("NguoiDaiDienHoTen")]
        public Int32? NguoiDaiDien
        {
            get { return Fields.NguoiDaiDien[this]; }
            set { Fields.NguoiDaiDien[this] = value; }
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get { return Fields.Phone[this]; }
            set { Fields.Phone[this] = value; }
        }

        [DisplayName("Mst"), Column("MST"), Size(50)]
        public String Mst
        {
            get { return Fields.Mst[this]; }
            set { Fields.Mst[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Ho Ten"), Expression("jNguoiDaiDien.[HoTen]")]
        public String NguoiDaiDienHoTen
        {
            get { return Fields.NguoiDaiDienHoTen[this]; }
            set { Fields.NguoiDaiDienHoTen[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Gioi Tinh"), Expression("jNguoiDaiDien.[GioiTinh]")]
        public String NguoiDaiDienGioiTinh
        {
            get { return Fields.NguoiDaiDienGioiTinh[this]; }
            set { Fields.NguoiDaiDienGioiTinh[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Phone"), Expression("jNguoiDaiDien.[Phone]")]
        public String NguoiDaiDienPhone
        {
            get { return Fields.NguoiDaiDienPhone[this]; }
            set { Fields.NguoiDaiDienPhone[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Mobile"), Expression("jNguoiDaiDien.[Mobile]")]
        public String NguoiDaiDienMobile
        {
            get { return Fields.NguoiDaiDienMobile[this]; }
            set { Fields.NguoiDaiDienMobile[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Email"), Expression("jNguoiDaiDien.[Email]")]
        public String NguoiDaiDienEmail
        {
            get { return Fields.NguoiDaiDienEmail[this]; }
            set { Fields.NguoiDaiDienEmail[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Chuc Vu"), Expression("jNguoiDaiDien.[ChucVu]")]
        public String NguoiDaiDienChucVu
        {
            get { return Fields.NguoiDaiDienChucVu[this]; }
            set { Fields.NguoiDaiDienChucVu[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Ma Kh"), Expression("jNguoiDaiDien.[MaKH]")]
        public Int32? NguoiDaiDienMaKh
        {
            get { return Fields.NguoiDaiDienMaKh[this]; }
            set { Fields.NguoiDaiDienMaKh[this] = value; }
        }

        [DisplayName("Nguoi Dai Dien Status"), Expression("jNguoiDaiDien.[Status]")]
        public Boolean? NguoiDaiDienStatus
        {
            get { return Fields.NguoiDaiDienStatus[this]; }
            set { Fields.NguoiDaiDienStatus[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenKh; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblKhachHangRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MaKh;
            public StringField TenKh;
            public StringField DiaChi;
            public Int32Field NguoiDaiDien;
            public StringField Phone;
            public StringField Mst;

            public StringField NguoiDaiDienHoTen;
            public StringField NguoiDaiDienGioiTinh;
            public StringField NguoiDaiDienPhone;
            public StringField NguoiDaiDienMobile;
            public StringField NguoiDaiDienEmail;
            public StringField NguoiDaiDienChucVu;
            public Int32Field NguoiDaiDienMaKh;
            public BooleanField NguoiDaiDienStatus;
		}
    }
}
