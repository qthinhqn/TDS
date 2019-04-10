
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

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblLenChuyen]")]
    [DisplayName("Tbl Len Chuyen"), InstanceName("Tbl Len Chuyen")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.TblLenChuyen.View)]
    [ModifyPermission(PermissionKeys.TblLenChuyen.Modify)]
    [DeletePermission(PermissionKeys.TblLenChuyen.Delete)]
    public sealed class TblLenChuyenRow : Row, IIdRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Nv Quet"), Column("MaNV_Quet"), ForeignKey("[dbo].[tblNguoiDung]", "KeyID"), LeftJoin("jMaNvQuet"), TextualField("MaNvQuetHoTen")]
        public Int32? MaNvQuet
        {
            get { return Fields.MaNvQuet[this]; }
            set { Fields.MaNvQuet[this] = value; }
        }

        [DisplayName("Ngay")]
        public DateTime? Ngay
        {
            get { return Fields.Ngay[this]; }
            set { Fields.Ngay[this] = value; }
        }

        [DisplayName("Ma Nv Quet Ho Ten"), Expression("jMaNvQuet.[HoTen]")]
        public String MaNvQuetHoTen
        {
            get { return Fields.MaNvQuetHoTen[this]; }
            set { Fields.MaNvQuetHoTen[this] = value; }
        }

        [DisplayName("Ma Nv Quet Gioi Tinh"), Expression("jMaNvQuet.[GioiTinh]")]
        public String MaNvQuetGioiTinh
        {
            get { return Fields.MaNvQuetGioiTinh[this]; }
            set { Fields.MaNvQuetGioiTinh[this] = value; }
        }

        [DisplayName("Ma Nv Quet Phone"), Expression("jMaNvQuet.[Phone]")]
        public String MaNvQuetPhone
        {
            get { return Fields.MaNvQuetPhone[this]; }
            set { Fields.MaNvQuetPhone[this] = value; }
        }

        [DisplayName("Ma Nv Quet Mobile"), Expression("jMaNvQuet.[Mobile]")]
        public String MaNvQuetMobile
        {
            get { return Fields.MaNvQuetMobile[this]; }
            set { Fields.MaNvQuetMobile[this] = value; }
        }

        [DisplayName("Ma Nv Quet Email"), Expression("jMaNvQuet.[Email]")]
        public String MaNvQuetEmail
        {
            get { return Fields.MaNvQuetEmail[this]; }
            set { Fields.MaNvQuetEmail[this] = value; }
        }

        [DisplayName("Ma Nv Quet Chuc Vu"), Expression("jMaNvQuet.[ChucVu]")]
        public String MaNvQuetChucVu
        {
            get { return Fields.MaNvQuetChucVu[this]; }
            set { Fields.MaNvQuetChucVu[this] = value; }
        }

        [DisplayName("Ma Nv Quet Status"), Expression("jMaNvQuet.[Status]")]
        public Boolean? MaNvQuetStatus
        {
            get { return Fields.MaNvQuetStatus[this]; }
            set { Fields.MaNvQuetStatus[this] = value; }
        }

        [DisplayName("Details"), MasterDetailRelation(foreignKey: "MaLenChuyen", IncludeColumns = "CT_MaBTP,CT_MaMau,CT_MaSize,CT_MaStyle,CT_SL_Thuc,CT_SL_Loi_KH,CT_SL_Loi_In"), NotMapped]
        public List<TblLenChuyenIn_ChiTietRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblLenChuyenRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaNvQuet;
            public DateTimeField Ngay;

            public StringField MaNvQuetHoTen;
            public StringField MaNvQuetGioiTinh;
            public StringField MaNvQuetPhone;
            public StringField MaNvQuetMobile;
            public StringField MaNvQuetEmail;
            public StringField MaNvQuetChucVu;
            public BooleanField MaNvQuetStatus;

            public RowListField<TblLenChuyenIn_ChiTietRow> DetailList;
        }
    }
}
