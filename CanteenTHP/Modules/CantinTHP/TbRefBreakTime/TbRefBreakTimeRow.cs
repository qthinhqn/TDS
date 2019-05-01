
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_BreakTime]")]
    [DisplayName("Tb Ref Break Time"), InstanceName("Tb Ref Break Time")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefBreakTimeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Shift Id"), Column("ShiftID"), Size(10), PrimaryKey, QuickSearch]
        public String ShiftId
        {
            get { return Fields.ShiftId[this]; }
            set { Fields.ShiftId[this] = value; }
        }

        [DisplayName("Shift Name"), Size(25)]
        public String ShiftName
        {
            get { return Fields.ShiftName[this]; }
            set { Fields.ShiftName[this] = value; }
        }

        [DisplayName("Begin Time")]
        public DateTime? BeginTime
        {
            get { return Fields.BeginTime[this]; }
            set { Fields.BeginTime[this] = value; }
        }

        [DisplayName("End Time")]
        public DateTime? EndTime
        {
            get { return Fields.EndTime[this]; }
            set { Fields.EndTime[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }


        [DisplayName("String Name"), QuickSearch]
        [Expression("CONCAT('[' , T0.[ShiftId] , '] ' , T0.[ShiftName])")]
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

        public TbRefBreakTimeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField ShiftId;
            public StringField ShiftName;
            public DateTimeField BeginTime;
            public DateTimeField EndTime;
            public BooleanField Active;

            public StringField StringName;
        }
    }
}
