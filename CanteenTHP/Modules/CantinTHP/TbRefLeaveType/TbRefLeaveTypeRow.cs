
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_LeaveType]")]
    [DisplayName("Tb Ref Leave Type"), InstanceName("Tb Ref Leave Type")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefLeaveTypeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Leave Id"), Column("LeaveID"), Size(10), PrimaryKey, QuickSearch]
        public String LeaveId
        {
            get { return Fields.LeaveId[this]; }
            set { Fields.LeaveId[this] = value; }
        }

        [DisplayName("Leave Type"), Size(50)]
        public String LeaveType
        {
            get { return Fields.LeaveType[this]; }
            set { Fields.LeaveType[this] = value; }
        }

        [DisplayName("Is Long Term"), Column("IsLong_Term")]
        public Boolean? IsLongTerm
        {
            get { return Fields.IsLongTerm[this]; }
            set { Fields.IsLongTerm[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }


        [DisplayName("String Name"), QuickSearch]
        [Expression("CONCAT('[' , T0.[LeaveId] , '] ' , T0.[LeaveType])")]
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

        public TbRefLeaveTypeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField LeaveId;
            public StringField LeaveType;
            public BooleanField IsLongTerm;
            public BooleanField Active;

            public StringField StringName;
        }
    }
}
