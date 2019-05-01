
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_Menu]")]
    [DisplayName("Tb Ref Menu"), InstanceName("Tb Ref Menu")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefMenuRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Menu Id"), Column("MenuID"), Size(10), PrimaryKey, QuickSearch]
        public String MenuId
        {
            get { return Fields.MenuId[this]; }
            set { Fields.MenuId[this] = value; }
        }

        [DisplayName("Menu Name"), Size(255)]
        public String MenuName
        {
            get { return Fields.MenuName[this]; }
            set { Fields.MenuName[this] = value; }
        }

        [DisplayName("M Image"), Column("mImage"), Size(255)]
        public String MImage
        {
            get { return Fields.MImage[this]; }
            set { Fields.MImage[this] = value; }
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
        [Expression("CONCAT('[' , T0.[MenuId] , '] ' , T0.[MenuName])")]
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

        public TbRefMenuRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MenuId;
            public StringField MenuName;
            public StringField MImage;
            public StringField Remarks;
            public BooleanField Active;

            public StringField StringName;
        }
    }
}
