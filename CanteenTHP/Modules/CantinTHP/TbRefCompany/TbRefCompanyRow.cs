
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_Company]")]
    [DisplayName("Tb Ref Company"), InstanceName("Tb Ref Company")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefCompanyRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Company Key"), Size(10), PrimaryKey, QuickSearch]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
        }

        [DisplayName("Company Name"), Size(255), NotNull]
        public String CompanyName
        {
            get { return Fields.CompanyName[this]; }
            set { Fields.CompanyName[this] = value; }
        }

        [DisplayName("Company Name Eng"), Column("CompanyName_Eng"), Size(255), NotNull]
        public String CompanyNameEng
        {
            get { return Fields.CompanyNameEng[this]; }
            set { Fields.CompanyNameEng[this] = value; }
        }

        [DisplayName("Remarks"), Size(255)]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }


        [DisplayName("String Name"), QuickSearch]
        [Expression("CONCAT('[' , T0.[CompanyKey] , '] ' , T0.[CompanyName])")]
        public String StringName
        {
            get { return Fields.StringName[this]; }
            set { Fields.StringName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.StringName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbRefCompanyRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField CompanyKey;
            public StringField CompanyName;
            public StringField CompanyNameEng;
            public StringField Remarks;
            public BooleanField Active;

            public StringField StringName;
        }
    }
}
