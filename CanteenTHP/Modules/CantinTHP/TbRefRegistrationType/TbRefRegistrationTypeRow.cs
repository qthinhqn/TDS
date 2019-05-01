
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_RegistrationType]")]
    [DisplayName("Tb Ref Registration Type"), InstanceName("Tb Ref Registration Type")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefRegistrationTypeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Reg Id"), Column("RegID"), Size(10), QuickSearch]
        public String RegId
        {
            get { return Fields.RegId[this]; }
            set { Fields.RegId[this] = value; }
        }

        [DisplayName("Reg Name"), Size(25)]
        public String RegName
        {
            get { return Fields.RegName[this]; }
            set { Fields.RegName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.RegId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbRefRegistrationTypeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField RegId;
            public StringField RegName;
        }
    }
}
