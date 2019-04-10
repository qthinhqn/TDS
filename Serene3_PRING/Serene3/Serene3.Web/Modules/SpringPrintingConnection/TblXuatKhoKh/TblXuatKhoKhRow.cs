
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

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tbl_XuatKho_KH]")]
    [DisplayName("Tbl Xuat Kho Kh"), InstanceName("Tbl Xuat Kho Kh")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.TblXuatKhoKh.View)]
    [ModifyPermission(PermissionKeys.TblXuatKhoKh.Modify)]
    [DeletePermission(PermissionKeys.TblXuatKhoKh.Delete)]
    public sealed class TblXuatKhoKhRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH"), ForeignKey("[dbo].[tblKhachHang]", "KeyID"), LeftJoin("jMaKh"), TextualField("MaKh1")]
        public Int32? MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Ngay Xuat")]
        public DateTime? NgayXuat
        {
            get { return Fields.NgayXuat[this]; }
            set { Fields.NgayXuat[this] = value; }
        }

        [DisplayName("Ma Nv Xuat"), Column("MaNV_Xuat"), ForeignKey("[dbo].[tblNguoiDung]", "KeyID"), LeftJoin("jMaNvXuat"), TextualField("MaNvXuatHoTen")]
        public Int32? MaNvXuat
        {
            get { return Fields.MaNvXuat[this]; }
            set { Fields.MaNvXuat[this] = value; }
        }

        [DisplayName("So Phieu"), Size(50), QuickSearch]
        public String SoPhieu
        {
            get { return Fields.SoPhieu[this]; }
            set { Fields.SoPhieu[this] = value; }
        }

        [DisplayName("Ghichu"), Size(500)]
        public String Ghichu
        {
            get { return Fields.Ghichu[this]; }
            set { Fields.Ghichu[this] = value; }
        }

        [DisplayName("Ma Kh"), Expression("jMaKh.[MaKH]")]
        public String MaKh1
        {
            get { return Fields.MaKh1[this]; }
            set { Fields.MaKh1[this] = value; }
        }

        [DisplayName("Ma Kh Ten Kh"), Expression("jMaKh.[TenKH]")]
        public String MaKhTenKh
        {
            get { return Fields.MaKhTenKh[this]; }
            set { Fields.MaKhTenKh[this] = value; }
        }

        [DisplayName("Ma Kh Dia Chi"), Expression("jMaKh.[DiaChi]")]
        public String MaKhDiaChi
        {
            get { return Fields.MaKhDiaChi[this]; }
            set { Fields.MaKhDiaChi[this] = value; }
        }

        [DisplayName("Ma Kh Nguoi Dai Dien"), Expression("jMaKh.[NguoiDaiDien]")]
        public Int32? MaKhNguoiDaiDien
        {
            get { return Fields.MaKhNguoiDaiDien[this]; }
            set { Fields.MaKhNguoiDaiDien[this] = value; }
        }

        [DisplayName("Ma Kh Phone"), Expression("jMaKh.[Phone]")]
        public String MaKhPhone
        {
            get { return Fields.MaKhPhone[this]; }
            set { Fields.MaKhPhone[this] = value; }
        }

        [DisplayName("Ma Kh Mst"), Expression("jMaKh.[MST]")]
        public String MaKhMst
        {
            get { return Fields.MaKhMst[this]; }
            set { Fields.MaKhMst[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Ho Ten"), Expression("jMaNvXuat.[HoTen]")]
        public String MaNvXuatHoTen
        {
            get { return Fields.MaNvXuatHoTen[this]; }
            set { Fields.MaNvXuatHoTen[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Gioi Tinh"), Expression("jMaNvXuat.[GioiTinh]")]
        public String MaNvXuatGioiTinh
        {
            get { return Fields.MaNvXuatGioiTinh[this]; }
            set { Fields.MaNvXuatGioiTinh[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Phone"), Expression("jMaNvXuat.[Phone]")]
        public String MaNvXuatPhone
        {
            get { return Fields.MaNvXuatPhone[this]; }
            set { Fields.MaNvXuatPhone[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Mobile"), Expression("jMaNvXuat.[Mobile]")]
        public String MaNvXuatMobile
        {
            get { return Fields.MaNvXuatMobile[this]; }
            set { Fields.MaNvXuatMobile[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Email"), Expression("jMaNvXuat.[Email]")]
        public String MaNvXuatEmail
        {
            get { return Fields.MaNvXuatEmail[this]; }
            set { Fields.MaNvXuatEmail[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Chuc Vu"), Expression("jMaNvXuat.[ChucVu]")]
        public String MaNvXuatChucVu
        {
            get { return Fields.MaNvXuatChucVu[this]; }
            set { Fields.MaNvXuatChucVu[this] = value; }
        }

        [DisplayName("Ma Nv Xuat Status"), Expression("jMaNvXuat.[Status]")]
        public Boolean? MaNvXuatStatus
        {
            get { return Fields.MaNvXuatStatus[this]; }
            set { Fields.MaNvXuatStatus[this] = value; }
        }

        [DisplayName("Details"), MasterDetailRelation(foreignKey: "MaPhieuXuat", IncludeColumns = "CT_MaBTP,CT_MaMau,CT_MaSize,CT_MaStyle,CT_SL_Thuc,CT_SL_Loi_KH,CT_SL_Loi_In"), NotMapped]
        public List<TblXuatKho_ChiTietRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.SoPhieu; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblXuatKhoKhRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaKh;
            public DateTimeField NgayXuat;
            public Int32Field MaNvXuat;
            public StringField SoPhieu;
            public StringField Ghichu;

            public StringField MaKh1;
            public StringField MaKhTenKh;
            public StringField MaKhDiaChi;
            public Int32Field MaKhNguoiDaiDien;
            public StringField MaKhPhone;
            public StringField MaKhMst;

            public StringField MaNvXuatHoTen;
            public StringField MaNvXuatGioiTinh;
            public StringField MaNvXuatPhone;
            public StringField MaNvXuatMobile;
            public StringField MaNvXuatEmail;
            public StringField MaNvXuatChucVu;
            public BooleanField MaNvXuatStatus;

            public RowListField<TblXuatKho_ChiTietRow> DetailList;
        }
    }
}
