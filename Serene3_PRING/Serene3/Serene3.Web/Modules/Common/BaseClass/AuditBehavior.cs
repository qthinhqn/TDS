using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using Serenity;
using Serene3.Administration;

namespace Serene3.Modules.Common.BaseClass
{
    /// <summary>
    /// This interface is used to log the changes for Insert / Update and Delete.
    /// This identify the Identity Column as Row Id (Unique Id) and save in Audit Table. If Identity column is not found then it use Id (Hard Coded) column.
    /// </summary>
    public interface IAuditLog
    {
    }

    /// <summary>
    /// This is used if want to store specific IdFields instead of default Identity field (or identity field is not avail able  ).
    /// </summary>
    public interface IExAuditLog
    {
        /// <summary>
        /// Assign the field which need to save as reference id in Audit Log Table
        /// </summary>
        Int32Field IdField { get; }
    }

    public class AuditRowBehavior : IImplicitBehavior, ISaveBehavior, IDeleteBehavior
    {
        const string FieldSeperator = "; ";
        string IdFieldName = null;
        public bool ActivateFor(Row row)
        {
            var auditLog = row as IAuditLog;
            if (auditLog == null)
            {
                var exauditLog = row as IExAuditLog;
                if (exauditLog == null)
                    return false;
                else
                    IdFieldName = exauditLog.IdField.PropertyName;
            }
            return true;
        }


        public void OnAfterSave(ISaveRequestHandler handler) { }
        public void OnAudit(ISaveRequestHandler handler)
        {
            string auditLog = "";
            AuditActionType AuditAction = AuditActionType.Delete;
            if (handler.IsCreate)
            {
                auditLog = GetInsertAuditLog(handler.Row);
                AuditAction = AuditActionType.Insert;
            }

            if (handler.IsUpdate)
            {
                auditLog = GetUpdateAuditLog(handler.Row, handler.Old);
                AuditAction = AuditActionType.Update;
            }
            ExecuteAuditLogProc(handler.Connection, AuditAction, handler.Row, auditLog);
        }
        public void OnBeforeSave(ISaveRequestHandler handler) { }
        public void OnPrepareQuery(ISaveRequestHandler handler, SqlQuery query) { }
        public void OnReturn(ISaveRequestHandler handler) { }
        public void OnSetInternalFields(ISaveRequestHandler handler) { }
        public void OnValidateRequest(ISaveRequestHandler handler) { }
        public void OnAfterDelete(IDeleteRequestHandler handler) { }
        public void OnAudit(IDeleteRequestHandler handler)
        {
            var auditLog = GetInsertAuditLog(handler.Row);
            ExecuteAuditLogProc(handler.Connection, AuditActionType.Delete, handler.Row, auditLog);
        }
        public void OnBeforeDelete(IDeleteRequestHandler handler) { }
        public void OnPrepareQuery(IDeleteRequestHandler handler, SqlQuery query) { }
        public void OnReturn(IDeleteRequestHandler handler) { }
        public void OnValidateRequest(IDeleteRequestHandler handler) { }

        private string GetUpdateAuditLog(Row CurrentRow, Row OldRow)
        {
            List<UpdateField> audiDataList = new List<UpdateField>();
            var tableFields = CurrentRow.GetTableFields();
            foreach (var tfield in tableFields)
            {
                var propInfo = CurrentRow.GetType().GetProperty(tfield.ColumnAlias);

                if (propInfo.GetCustomAttribute(typeof(IgnoreAuditLog)) != null)
                    continue;
                if (propInfo.GetCustomAttribute(typeof(IdentityAttribute)) != null)
                    IdFieldName = propInfo.Name;

                if (propInfo.PropertyType == typeof(DateTime?))
                {
                    var currDate = ((DateTime?)propInfo.GetValue(CurrentRow));
                    var oldDate = ((DateTime?)propInfo.GetValue(OldRow));
                    if ((oldDate.HasValue || currDate.HasValue) && oldDate != currDate)
                        audiDataList.Add(new UpdateField { F = propInfo.Name, V = (currDate.HasValue ? currDate.ToIndianDateFormat() : "<empty>"), O = (oldDate.HasValue ? oldDate.ToIndianDateFormat() : "<empty>") });
                }
                else if (propInfo.PropertyType == typeof(Decimal?))
                {
                    var currValue = ((Decimal?)propInfo.GetValue(CurrentRow));
                    var oldValue = ((Decimal?)propInfo.GetValue(OldRow));
                    if ((currValue.HasValue || oldValue.HasValue) && (Convert.ToDecimal(currValue) - Convert.ToDecimal(oldValue)) != 0)
                        audiDataList.Add(new UpdateField { F = propInfo.Name, O = (oldValue.HasValue ? oldValue.Value.ToString() : "<empty>"), V = (currValue.HasValue ? currValue.Value.ToString() : "<empty>") });
                }
                else
                {
                    var currValue = Convert.ToString(propInfo.GetValue(CurrentRow));
                    var oldValue = Convert.ToString(propInfo.GetValue(OldRow));
                    if (currValue != oldValue)
                        audiDataList.Add(new UpdateField { F = propInfo.Name, O = (oldValue.IsNullOrEmpty() ? "<empty>" : oldValue), V = (currValue.IsNullOrEmpty() ? "<empty>" : currValue) });
                }
            }
            //return auditLog;
            return audiDataList.ToJson(); ;
        }
        private string GetInsertAuditLog(Row CurrentRow)
        {
            List<InsertField> audiDataList = new List<InsertField>();
            var tableFields = CurrentRow.GetTableFields();
            foreach (var tfield in tableFields)
            {
                var propInfo = CurrentRow.GetType().GetProperty(tfield.ColumnAlias);
                if (propInfo.GetCustomAttribute(typeof(IgnoreAuditLog)) != null)
                    continue;
                if (propInfo.GetCustomAttribute(typeof(IdentityAttribute)) != null)
                    IdFieldName = propInfo.Name;
                //Check if field is of DateTime type to convert it in desired format.
                if (propInfo.PropertyType == typeof(DateTime?))
                {
                    var currDate = ((DateTime?)propInfo.GetValue(CurrentRow));
                    if (currDate.HasValue)
                        audiDataList.Add(new InsertField { F = propInfo.Name, V = currDate.ToIndianDateFormat() });
                }
                else
                {
                    var fieldValue = Convert.ToString(propInfo.GetValue(CurrentRow));
                    //Insert in log if values is defined for field.
                    if (!fieldValue.IsNullOrEmpty())
                        audiDataList.Add(new InsertField { F = propInfo.Name, V = fieldValue });
                }
            }
            return audiDataList.ToJson();
        }
        public void ExecuteAuditLogProc(IDbConnection Connection, AuditActionType AuditAction, Row CurrentRow, string AuditLog)
        {
            using (IDbCommand command = Connection.CreateCommand())
            {
                IDbDataParameter pUserId = command.CreateParameter();
                pUserId.ParameterName = "@UserId";
                pUserId.Value = ((UserDefinition)Authorization.UserDefinition).UserId;
                command.Parameters.Add(pUserId);

                IDbDataParameter pUserName = command.CreateParameter();
                pUserName.ParameterName = "@UserName";
                pUserName.Value = ((UserDefinition)Authorization.UserDefinition).Username;
                command.Parameters.Add(pUserName);

                IDbDataParameter pAction = command.CreateParameter();
                pAction.ParameterName = "@Action";
                pAction.Value = AuditAction.GetEnumText();
                command.Parameters.Add(pAction);

                IDbDataParameter pTableName = command.CreateParameter();
                pTableName.ParameterName = "@TableName";
                pTableName.Value = CurrentRow.Table;
                command.Parameters.Add(pTableName);

                IDbDataParameter pRowId = command.CreateParameter();
                pRowId.ParameterName = "@RowId";
                pRowId.Value = Convert.ToString(CurrentRow.GetType().GetProperty(IdFieldName == null ? "Id" : IdFieldName).GetValue(CurrentRow));
                command.Parameters.Add(pRowId);

                IDbDataParameter pModule = command.CreateParameter();
                pModule.ParameterName = "@Module";
                pModule.Value = CurrentRow.GetType().Name;
                command.Parameters.Add(pModule);

                IDbDataParameter pPage = command.CreateParameter();
                pPage.ParameterName = "@Page";
                //Sometimes same module is used for different pages for reusablity. So save page url to know the exact action page.
                pPage.Value = GetPageUrl();
                command.Parameters.Add(pPage);

                IDbDataParameter pChanges = command.CreateParameter();
                pChanges.ParameterName = "@Changes";
                pChanges.Value = AuditLog;
                command.Parameters.Add(pChanges);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Common_AuditLog";
                command.ExecuteNonQuery();
            }
        }

        string GetPageUrl()
        {
            string pageUrl = "";
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.UrlReferrer != null)
                    pageUrl = httpRequest.UrlReferrer.PathAndQuery;
                else if (httpRequest.Url != null)
                    pageUrl = httpRequest.Url.PathAndQuery;
            }
            return pageUrl;
        }
    }

    [EnumKey("Enum.Audit.AuditActionType")]
    public enum AuditActionType
    {
        [Description("INSERT")]
        Insert = 1,
        [Description("UPDATE")]
        Update = 2,
        [Description("DELETE")]
        Delete = 3
    }

    /// <summary>
    /// Any field which does not required to log in audit table. For Example InsertUserId, InsertDate etc
    /// </summary>
    public class IgnoreAuditLog : Attribute
    {
    }

    /*Keep the field name of only one character to save space (string length) while converting this to json*/
    public class InsertField
    {
        //Field Name
        public string F { get; set; }
        //Field Value
        public string V { get; set; }
    }
    public class UpdateField
    {
        //Field Name
        public string F { get; set; }
        //Old Value
        public string O { get; set; }
        //Current Value
        public string V { get; set; }
    }

    public static class ExtensionMethods
    {
        public static string ToIndianDateFormat(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return "";
            return dateTime.Value.ToString("dd/MM/yyyy");
        }

        public static string GetEnumText(this object EnumObj)
        {
            Type type = EnumObj.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "EnumObj");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(EnumObj.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return EnumObj.ToString();

        }
    }
}