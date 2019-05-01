
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_Canteen]")]
    [DisplayName("Tb Ref Canteen"), InstanceName("Tb Ref Canteen")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefCanteenRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Canteen Id"), Column("CanteenID"), Size(10), PrimaryKey, QuickSearch]
        public String CanteenId
        {
            get { return Fields.CanteenId[this]; }
            set { Fields.CanteenId[this] = value; }
        }

        [DisplayName("Canteen Name"), Size(255)]
        public String CanteenName
        {
            get { return Fields.CanteenName[this]; }
            set { Fields.CanteenName[this] = value; }
        }

        [DisplayName("Contact Person"), Size(100)]
        public String ContactPerson
        {
            get { return Fields.ContactPerson[this]; }
            set { Fields.ContactPerson[this] = value; }
        }

        [DisplayName("Phone Num"), Size(25)]
        public String PhoneNum
        {
            get { return Fields.PhoneNum[this]; }
            set { Fields.PhoneNum[this] = value; }
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
        [Expression("CONCAT('[' , T0.[CanteenId] , '] ' , T0.[CanteenName])")]
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

        public TbRefCanteenRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField CanteenId;
            public StringField CanteenName;
            public StringField ContactPerson;
            public StringField PhoneNum;
            public StringField Remarks;
            public BooleanField Active;

            public StringField StringName;
        }
    }
}
