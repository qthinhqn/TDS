
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblLenChuyenIn_ChiTiet]")]
    [DisplayName("Tbl Len Chuyen In Chi Tiet"), InstanceName("Tbl Len Chuyen In Chi Tiet")]
    //[ReadPermission("Administration:General")]
    //[ModifyPermission("Administration:General")]
    [ReadPermission(PermissionKeys.TblLenChuyenInChiTiet.View)]
    [ModifyPermission(PermissionKeys.TblLenChuyenInChiTiet.Modify)]
    [DeletePermission(PermissionKeys.TblLenChuyenInChiTiet.Delete)]
    [LeftJoin("cd", "vChiTiet_BTP", "cd.[KeyID_1] = T0.[MaBo]")]
    [LeftJoin("vNK", "vNhapKho_SP", "vNK.[Expr1] = T0.[MaBo]")]
    public sealed class TblLenChuyenInChiTietRow : Row, IIdRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Bo"), ForeignKey("[dbo].[tblBo_BTP]", "KeyID"), LeftJoin("jMaBo"), TextualField("MaBoCode")]
        public Int32? MaBo
        {
            get { return Fields.MaBo[this]; }
            set { Fields.MaBo[this] = value; }
        }

        [DisplayName("Ngay")]
        public DateTime? Ngay
        {
            get { return Fields.Ngay[this]; }
            set { Fields.Ngay[this] = value; }
        }

        [DisplayName("Status")]
        public Boolean? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        [DisplayName("Ma Len Chuyen"), ForeignKey("[dbo].[tblLenChuyen]", "KeyID"), LeftJoin("jMaLenChuyen")]
        public Int32? MaLenChuyen
        {
            get { return Fields.MaLenChuyen[this]; }
            set { Fields.MaLenChuyen[this] = value; }
        }

        [DisplayName("Ma Bo Ma Lo"), Expression("jMaBo.[MaLo]")]
        public Int32? MaBoMaLo
        {
            get { return Fields.MaBoMaLo[this]; }
            set { Fields.MaBoMaLo[this] = value; }
        }

        [DisplayName("Ma Bo Ma Btp"), Expression("jMaBo.[MaBTP]")]
        public Int32? MaBoMaBtp
        {
            get { return Fields.MaBoMaBtp[this]; }
            set { Fields.MaBoMaBtp[this] = value; }
        }

        [DisplayName("Ma Bo Sl Thuc"), Expression("jMaBo.[SL_Thuc]")]
        public Int32? MaBoSlThuc
        {
            get { return Fields.MaBoSlThuc[this]; }
            set { Fields.MaBoSlThuc[this] = value; }
        }

        [DisplayName("Ma Bo Sl Loi Kh"), Expression("jMaBo.[SL_Loi_KH]")]
        public Int32? MaBoSlLoiKh
        {
            get { return Fields.MaBoSlLoiKh[this]; }
            set { Fields.MaBoSlLoiKh[this] = value; }
        }

        [DisplayName("Ma Bo Sl Loi In"), Expression("jMaBo.[SL_Loi_In]")]
        public Int32? MaBoSlLoiIn
        {
            get { return Fields.MaBoSlLoiIn[this]; }
            set { Fields.MaBoSlLoiIn[this] = value; }
        }

        [DisplayName("Ma Bo Ma In"), Expression("jMaBo.[MaIN]")]
        public Int32? MaBoMaIn
        {
            get { return Fields.MaBoMaIn[this]; }
            set { Fields.MaBoMaIn[this] = value; }
        }

        [DisplayName("Ma Bo Ma Out"), Expression("jMaBo.[MaOUT]")]
        public Int32? MaBoMaOut
        {
            get { return Fields.MaBoMaOut[this]; }
            set { Fields.MaBoMaOut[this] = value; }
        }

        [DisplayName("Ma Bo Ma Len Chuyen"), Expression("jMaBo.[MaLenChuyen]")]
        public Int32? MaBoMaLenChuyen
        {
            get { return Fields.MaBoMaLenChuyen[this]; }
            set { Fields.MaBoMaLenChuyen[this] = value; }
        }

        [DisplayName("Ma Bo Ma Xuong Chuyen"), Expression("jMaBo.[MaXuongChuyen]")]
        public Int32? MaBoMaXuongChuyen
        {
            get { return Fields.MaBoMaXuongChuyen[this]; }
            set { Fields.MaBoMaXuongChuyen[this] = value; }
        }

        [DisplayName("Ma Bo Ma Mau"), Expression("jMaBo.[MaMau]")]
        public Int32? MaBoMaMau
        {
            get { return Fields.MaBoMaMau[this]; }
            set { Fields.MaBoMaMau[this] = value; }
        }

        [DisplayName("Ma Bo Ma Size"), Expression("jMaBo.[MaSize]")]
        public Int32? MaBoMaSize
        {
            get { return Fields.MaBoMaSize[this]; }
            set { Fields.MaBoMaSize[this] = value; }
        }

        [DisplayName("Ma Bo Hang Mau"), Expression("jMaBo.[HangMau]")]
        public Boolean? MaBoHangMau
        {
            get { return Fields.MaBoHangMau[this]; }
            set { Fields.MaBoHangMau[this] = value; }
        }

        [DisplayName("Ma Bo Hang Bu"), Expression("jMaBo.[HangBu]")]
        public Boolean? MaBoHangBu
        {
            get { return Fields.MaBoHangBu[this]; }
            set { Fields.MaBoHangBu[this] = value; }
        }

        [DisplayName("Ma Bo Ma Hd"), Expression("jMaBo.[MaHD]")]
        public Int32? MaBoMaHd
        {
            get { return Fields.MaBoMaHd[this]; }
            set { Fields.MaBoMaHd[this] = value; }
        }

        [DisplayName("Ma Bo Card Id"), Expression("jMaBo.[CardID]")]
        public Int64? MaBoCardId
        {
            get { return Fields.MaBoCardId[this]; }
            set { Fields.MaBoCardId[this] = value; }
        }

        [DisplayName("Ma Bo Code"), Expression("jMaBo.[Code]")]
        public String MaBoCode
        {
            get { return Fields.MaBoCode[this]; }
            set { Fields.MaBoCode[this] = value; }
        }

        [DisplayName("Ma Bo Ma Fe Stock Out"), Expression("jMaBo.[MaFE_StockOut]")]
        public Guid? MaBoMaFeStockOut
        {
            get { return Fields.MaBoMaFeStockOut[this]; }
            set { Fields.MaBoMaFeStockOut[this] = value; }
        }

        [DisplayName("Ma Bo Ma Style"), Expression("jMaBo.[MaStyle]")]
        public Int32? MaBoMaStyle
        {
            get { return Fields.MaBoMaStyle[this]; }
            set { Fields.MaBoMaStyle[this] = value; }
        }

        [DisplayName("Ma Len Chuyen Ma Nv Quet"), Expression("jMaLenChuyen.[MaNV_Quet]")]
        public Int32? MaLenChuyenMaNvQuet
        {
            get { return Fields.MaLenChuyenMaNvQuet[this]; }
            set { Fields.MaLenChuyenMaNvQuet[this] = value; }
        }

        [DisplayName("Ma Len Chuyen Ngay"), Expression("jMaLenChuyen.[Ngay]")]
        public DateTime? MaLenChuyenNgay
        {
            get { return Fields.MaLenChuyenNgay[this]; }
            set { Fields.MaLenChuyenNgay[this] = value; }
        }

        [DisplayName("CT_MaBTP"), Expression("cd.[MaBTP]")]
        public String CT_MaBTP
        {
            get { return Fields.CT_MaBTP[this]; }
            set { Fields.CT_MaBTP[this] = value; }
        }
        [DisplayName("CT_MaMau"), Expression("cd.[MaMau]")]
        public String CT_MaMau
        {
            get { return Fields.CT_MaMau[this]; }
            set { Fields.CT_MaMau[this] = value; }
        }
        [DisplayName("CT_MaSize"), Expression("cd.[MaSize]")]
        public String CT_MaSize
        {
            get { return Fields.CT_MaSize[this]; }
            set { Fields.CT_MaSize[this] = value; }
        }
        [DisplayName("CT_MaStyle"), Expression("cd.[MaStyle]")]
        public String CT_MaStyle
        {
            get { return Fields.CT_MaStyle[this]; }
            set { Fields.CT_MaStyle[this] = value; }
        }
        [DisplayName("CT_SL_Thuc"), Expression("cd.[SL_Thuc]")]
        public Int32? CT_SL_Thuc
        {
            get { return Fields.CT_SL_Thuc[this]; }
            set { Fields.CT_SL_Thuc[this] = value; }
        }
        [DisplayName("CT_SL_Loi_KH"), Expression("cd.[SL_Loi_KH]")]
        public Int32? CT_SL_Loi_KH
        {
            get { return Fields.CT_SL_Loi_KH[this]; }
            set { Fields.CT_SL_Loi_KH[this] = value; }
        }
        [DisplayName("CT_SL_Loi_In"), Expression("cd.[SL_Loi_In]")]
        public Int32? CT_SL_Loi_In
        {
            get { return Fields.CT_SL_Loi_In[this]; }
            set { Fields.CT_SL_Loi_In[this] = value; }
        }


        [DisplayName("Bul No"), Expression("vNK.[BulNo]")]
        public Int32? BulNo
        {
            get { return Fields.BulNo[this]; }
            set { Fields.BulNo[this] = value; }
        }

        [DisplayName("Table Num"), Expression("vNK.[TableNum]")]
        public String TableNum
        {
            get { return Fields.TableNum[this]; }
            set { Fields.TableNum[this] = value; }
        }

        [DisplayName("Fepo"), Expression("vNK.[FEPO]")]
        public String Fepo
        {
            get { return Fields.Fepo[this]; }
            set { Fields.Fepo[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblLenChuyenInChiTietRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field MaBo;
            public DateTimeField Ngay;
            public BooleanField Status;
            public Int32Field MaLenChuyen;

            public Int32Field MaBoMaLo;
            public Int32Field MaBoMaBtp;
            public Int32Field MaBoSlThuc;
            public Int32Field MaBoSlLoiKh;
            public Int32Field MaBoSlLoiIn;
            public Int32Field MaBoMaIn;
            public Int32Field MaBoMaOut;
            public Int32Field MaBoMaLenChuyen;
            public Int32Field MaBoMaXuongChuyen;
            public Int32Field MaBoMaMau;
            public Int32Field MaBoMaSize;
            public BooleanField MaBoHangMau;
            public BooleanField MaBoHangBu;
            public Int32Field MaBoMaHd;
            public Int64Field MaBoCardId;
            public StringField MaBoCode;
            public GuidField MaBoMaFeStockOut;
            public Int32Field MaBoMaStyle;

            public Int32Field MaLenChuyenMaNvQuet;
            public DateTimeField MaLenChuyenNgay;

            public StringField CT_MaBTP;
            public StringField CT_MaMau;
            public StringField CT_MaSize;
            public StringField CT_MaStyle;
            public Int32Field CT_SL_Thuc;
            public Int32Field CT_SL_Loi_KH;
            public Int32Field CT_SL_Loi_In;

            public Int32Field BulNo;
            public StringField TableNum;
            public StringField Fepo;
        }
    }
}
