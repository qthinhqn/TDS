/// <reference types="jquery" />
/// <reference types="jqueryui" />
declare namespace Serene3.Administration {
}
declare namespace Serene3.Administration {
    interface LanguageForm {
        LanguageId: Serenity.StringEditor;
        LanguageName: Serenity.StringEditor;
    }
    class LanguageForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Administration {
    interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }
    namespace LanguageRow {
        const idProperty = "Id";
        const nameProperty = "LanguageName";
        const localTextPrefix = "Administration.Language";
        const lookupKey = "Administration.Language";
        function getLookup(): Q.Lookup<LanguageRow>;
        const enum Fields {
            Id = "Id",
            LanguageId = "LanguageId",
            LanguageName = "LanguageName",
        }
    }
}
declare namespace Serene3.Administration {
    namespace LanguageService {
        const baseUrl = "Administration/Language";
        function Create(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Language/Create",
            Update = "Administration/Language/Update",
            Delete = "Administration/Language/Delete",
            Retrieve = "Administration/Language/Retrieve",
            List = "Administration/Language/List",
        }
    }
}
declare namespace Serene3.Administration {
}
declare namespace Serene3.Administration {
    interface RoleForm {
        RoleName: Serenity.StringEditor;
    }
    class RoleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Administration {
    interface RolePermissionListRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Serene3.Administration {
    interface RolePermissionListResponse extends Serenity.ListResponse<string> {
    }
}
declare namespace Serene3.Administration {
    interface RolePermissionRow {
        RolePermissionId?: number;
        RoleId?: number;
        PermissionKey?: string;
        RoleRoleName?: string;
    }
    namespace RolePermissionRow {
        const idProperty = "RolePermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.RolePermission";
        const enum Fields {
            RolePermissionId = "RolePermissionId",
            RoleId = "RoleId",
            PermissionKey = "PermissionKey",
            RoleRoleName = "RoleRoleName",
        }
    }
}
declare namespace Serene3.Administration {
    namespace RolePermissionService {
        const baseUrl = "Administration/RolePermission";
        function Update(request: RolePermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: RolePermissionListRequest, onSuccess?: (response: RolePermissionListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/RolePermission/Update",
            List = "Administration/RolePermission/List",
        }
    }
}
declare namespace Serene3.Administration {
    interface RolePermissionUpdateRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: string[];
    }
}
declare namespace Serene3.Administration {
    interface RoleRow {
        RoleId?: number;
        RoleName?: string;
    }
    namespace RoleRow {
        const idProperty = "RoleId";
        const nameProperty = "RoleName";
        const localTextPrefix = "Administration.Role";
        const lookupKey = "Administration.Role";
        function getLookup(): Q.Lookup<RoleRow>;
        const enum Fields {
            RoleId = "RoleId",
            RoleName = "RoleName",
        }
    }
}
declare namespace Serene3.Administration {
    namespace RoleService {
        const baseUrl = "Administration/Role";
        function Create(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Role/Create",
            Update = "Administration/Role/Update",
            Delete = "Administration/Role/Delete",
            Retrieve = "Administration/Role/Retrieve",
            List = "Administration/Role/List",
        }
    }
}
declare namespace Serene3.Administration {
    interface TranslationItem {
        Key?: string;
        SourceText?: string;
        TargetText?: string;
        CustomText?: string;
    }
}
declare namespace Serene3.Administration {
    interface TranslationListRequest extends Serenity.ListRequest {
        SourceLanguageID?: string;
        TargetLanguageID?: string;
    }
}
declare namespace Serene3.Administration {
    namespace TranslationService {
        const baseUrl = "Administration/Translation";
        function List(request: TranslationListRequest, onSuccess?: (response: Serenity.ListResponse<TranslationItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: TranslationUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "Administration/Translation/List",
            Update = "Administration/Translation/Update",
        }
    }
}
declare namespace Serene3.Administration {
    interface TranslationUpdateRequest extends Serenity.ServiceRequest {
        TargetLanguageID?: string;
        Translations?: {
            [key: string]: string;
        };
    }
}
declare namespace Serene3.Administration {
}
declare namespace Serene3.Administration {
    interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
    }
    class UserForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Administration {
    interface UserPermissionListRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Serene3.Administration {
    interface UserPermissionRow {
        UserPermissionId?: number;
        UserId?: number;
        PermissionKey?: string;
        Granted?: boolean;
        Username?: string;
        User?: string;
    }
    namespace UserPermissionRow {
        const idProperty = "UserPermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.UserPermission";
        const enum Fields {
            UserPermissionId = "UserPermissionId",
            UserId = "UserId",
            PermissionKey = "PermissionKey",
            Granted = "Granted",
            Username = "Username",
            User = "User",
        }
    }
}
declare namespace Serene3.Administration {
    namespace UserPermissionService {
        const baseUrl = "Administration/UserPermission";
        function Update(request: UserPermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<UserPermissionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListRolePermissions(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListPermissionKeys(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserPermission/Update",
            List = "Administration/UserPermission/List",
            ListRolePermissions = "Administration/UserPermission/ListRolePermissions",
            ListPermissionKeys = "Administration/UserPermission/ListPermissionKeys",
        }
    }
}
declare namespace Serene3.Administration {
    interface UserPermissionUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: UserPermissionRow[];
    }
}
declare namespace Serene3.Administration {
    interface UserRoleListRequest extends Serenity.ServiceRequest {
        UserID?: number;
    }
}
declare namespace Serene3.Administration {
    interface UserRoleListResponse extends Serenity.ListResponse<number> {
    }
}
declare namespace Serene3.Administration {
    interface UserRoleRow {
        UserRoleId?: number;
        UserId?: number;
        RoleId?: number;
        Username?: string;
        User?: string;
    }
    namespace UserRoleRow {
        const idProperty = "UserRoleId";
        const localTextPrefix = "Administration.UserRole";
        const enum Fields {
            UserRoleId = "UserRoleId",
            UserId = "UserId",
            RoleId = "RoleId",
            Username = "Username",
            User = "User",
        }
    }
}
declare namespace Serene3.Administration {
    namespace UserRoleService {
        const baseUrl = "Administration/UserRole";
        function Update(request: UserRoleUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserRoleListRequest, onSuccess?: (response: UserRoleListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserRole/Update",
            List = "Administration/UserRole/List",
        }
    }
}
declare namespace Serene3.Administration {
    interface UserRoleUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Roles?: number[];
    }
}
declare namespace Serene3.Administration {
    interface UserRow {
        UserId?: number;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        Password?: string;
        PasswordConfirm?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace UserRow {
        const idProperty = "UserId";
        const isActiveProperty = "IsActive";
        const nameProperty = "Username";
        const localTextPrefix = "Administration.User";
        const lookupKey = "Administration.User";
        function getLookup(): Q.Lookup<UserRow>;
        const enum Fields {
            UserId = "UserId",
            Username = "Username",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            DisplayName = "DisplayName",
            Email = "Email",
            UserImage = "UserImage",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            IsActive = "IsActive",
            Password = "Password",
            PasswordConfirm = "PasswordConfirm",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate",
        }
    }
}
declare namespace Serene3.Administration {
    namespace UserService {
        const baseUrl = "Administration/User";
        function Create(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Undelete(request: Serenity.UndeleteRequest, onSuccess?: (response: Serenity.UndeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/User/Create",
            Update = "Administration/User/Update",
            Delete = "Administration/User/Delete",
            Undelete = "Administration/User/Undelete",
            Retrieve = "Administration/User/Retrieve",
            List = "Administration/User/List",
        }
    }
}
declare namespace Serene3.BasicSamples {
    namespace BasicSamplesService {
        const baseUrl = "BasicSamples/BasicSamples";
        function OrdersByShipper(request: OrdersByShipperRequest, onSuccess?: (response: OrdersByShipperResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function OrderBulkAction(request: OrderBulkActionRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            OrdersByShipper = "BasicSamples/BasicSamples/OrdersByShipper",
            OrderBulkAction = "BasicSamples/BasicSamples/OrderBulkAction",
        }
    }
}
declare namespace Serene3.BasicSamples {
    interface ChangingLookupTextForm {
        ProductID: ChangingLookupTextEditor;
        UnitPrice: Serenity.DecimalEditor;
        Quantity: Serenity.IntegerEditor;
        Discount: Serenity.DecimalEditor;
    }
    class ChangingLookupTextForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
}
declare namespace Serene3.BasicSamples {
    interface CustomerGrossSalesListRequest extends Serenity.ListRequest {
        StartDate?: string;
        EndDate?: string;
    }
}
declare namespace Serene3.BasicSamples {
    namespace CustomerGrossSalesService {
        const baseUrl = "BasicSamples/CustomerGrossSales";
        function List(request: CustomerGrossSalesListRequest, onSuccess?: (response: Serenity.ListResponse<Northwind.CustomerGrossSalesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "BasicSamples/CustomerGrossSales/List",
        }
    }
}
declare namespace Serene3.BasicSamples {
}
declare namespace Serene3.BasicSamples {
    interface DragDropSampleForm {
        Title: Serenity.StringEditor;
    }
    class DragDropSampleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
    interface DragDropSampleRow {
        Id?: number;
        ParentId?: number;
        Title?: string;
    }
    namespace DragDropSampleRow {
        const idProperty = "Id";
        const nameProperty = "Title";
        const localTextPrefix = "Northwind.DragDropSample";
        const enum Fields {
            Id = "Id",
            ParentId = "ParentId",
            Title = "Title",
        }
    }
}
declare namespace Serene3.BasicSamples {
    namespace DragDropSampleService {
        const baseUrl = "BasicSamples/DragDropSample";
        function Create(request: Serenity.SaveRequest<DragDropSampleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DragDropSampleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DragDropSampleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DragDropSampleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "BasicSamples/DragDropSample/Create",
            Update = "BasicSamples/DragDropSample/Update",
            Delete = "BasicSamples/DragDropSample/Delete",
            Retrieve = "BasicSamples/DragDropSample/Retrieve",
            List = "BasicSamples/DragDropSample/List",
        }
    }
}
declare namespace Serene3.BasicSamples {
    interface FilteredLookupInDetailForm {
        CustomerID: Northwind.CustomerEditor;
        OrderDate: Serenity.DateEditor;
        CategoryID: Serenity.LookupEditor;
        DetailList: FilteredLookupDetailEditor;
    }
    class FilteredLookupInDetailForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
    interface HardcodedValuesForm {
        SomeValue: HardcodedValuesEditor;
    }
    class HardcodedValuesForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
}
declare namespace Serene3.BasicSamples {
    interface LookupFilterByMultipleForm {
        ProductName: Serenity.StringEditor;
        ProductImage: Serenity.ImageUploadEditor;
        Discontinued: Serenity.BooleanEditor;
        SupplierID: Serenity.LookupEditor;
        CategoryID: ProduceSeafoodCategoryEditor;
        QuantityPerUnit: Serenity.StringEditor;
        UnitPrice: Serenity.DecimalEditor;
        UnitsInStock: Serenity.IntegerEditor;
        UnitsOnOrder: Serenity.IntegerEditor;
        ReorderLevel: Serenity.IntegerEditor;
    }
    class LookupFilterByMultipleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
    interface OrderBulkActionRequest extends Serenity.ServiceRequest {
        OrderIDs?: number[];
    }
}
declare namespace Serene3.BasicSamples {
    interface OrdersByShipperRequest extends Serenity.ServiceRequest {
    }
}
declare namespace Serene3.BasicSamples {
    interface OrdersByShipperResponse extends Serenity.ServiceResponse {
        Values?: {
            [key: string]: any;
        }[];
        ShipperKeys?: string[];
        ShipperLabels?: string[];
    }
}
declare namespace Serene3.BasicSamples {
    interface PopulateLinkedDataForm {
        CustomerID: Northwind.CustomerEditor;
        CustomerContactName: Serenity.StringEditor;
        CustomerContactTitle: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerRegion: Serenity.StringEditor;
        CustomerCountry: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerFax: Serenity.StringEditor;
        OrderDate: Serenity.DateEditor;
        RequiredDate: Serenity.DateEditor;
        EmployeeID: Serenity.LookupEditor;
        DetailList: Northwind.OrderDetailsEditor;
    }
    class PopulateLinkedDataForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
    interface ProductExcelImportForm {
        FileName: Serenity.ImageUploadEditor;
    }
    class ProductExcelImportForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
    namespace ProductExcelImportService {
        const baseUrl = "BasicSamples/ProductExcelImport";
        function ExcelImport(request: ExcelImportRequest, onSuccess?: (response: ExcelImportResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            ExcelImport = "BasicSamples/ProductExcelImport/ExcelImport",
        }
    }
}
declare namespace Serene3.BasicSamples {
    interface StaticTextBlockForm {
        StaticText: StaticTextBlock;
        SomeInput: Serenity.StringEditor;
        HtmlList: StaticTextBlock;
        FromLocalText: StaticTextBlock;
        DisplayFieldValue: StaticTextBlock;
    }
    class StaticTextBlockForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.BasicSamples {
}
declare namespace Serene3.BasicSamples {
    interface VSGalleryQAPost {
        PostId?: number;
        PostedOn?: string;
        PostedByName?: string;
        PostedByUserId?: string;
        Message?: string;
    }
}
declare namespace Serene3.BasicSamples {
    namespace VSGalleryQAService {
        const baseUrl = "BasicSamples/VSGalleryQA";
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VSGalleryQAThread>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "BasicSamples/VSGalleryQA/List",
        }
    }
}
declare namespace Serene3.BasicSamples {
    interface VSGalleryQAThread {
        ThreadId?: number;
        Title?: string;
        StartedOn?: string;
        StartedByName?: string;
        StartedByUserId?: string;
        LastPostOn?: string;
        PostCount?: number;
        Posts?: VSGalleryQAPost[];
    }
}
declare namespace Serene3.Common.Pages {
    interface UploadResponse extends Serenity.ServiceResponse {
        TemporaryFile?: string;
        Size?: number;
        IsImage?: boolean;
        Width?: number;
        Height?: number;
    }
}
declare namespace Serene3.Common {
    interface UserPreferenceRetrieveRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
    }
}
declare namespace Serene3.Common {
    interface UserPreferenceRetrieveResponse extends Serenity.ServiceResponse {
        Value?: string;
    }
}
declare namespace Serene3.Common {
    interface UserPreferenceRow {
        UserPreferenceId?: number;
        UserId?: number;
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
    namespace UserPreferenceRow {
        const idProperty = "UserPreferenceId";
        const nameProperty = "Name";
        const localTextPrefix = "Common.UserPreference";
        const enum Fields {
            UserPreferenceId = "UserPreferenceId",
            UserId = "UserId",
            PreferenceType = "PreferenceType",
            Name = "Name",
            Value = "Value",
        }
    }
}
declare namespace Serene3.Common {
    namespace UserPreferenceService {
        const baseUrl = "Common/UserPreference";
        function Update(request: UserPreferenceUpdateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: UserPreferenceRetrieveRequest, onSuccess?: (response: UserPreferenceRetrieveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Common/UserPreference/Update",
            Retrieve = "Common/UserPreference/Retrieve",
        }
    }
}
declare namespace Serene3.Common {
    interface UserPreferenceUpdateRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
}
declare namespace Serene3 {
    interface ExcelImportRequest extends Serenity.ServiceRequest {
        FileName?: string;
    }
}
declare namespace Serene3 {
    interface ExcelImportResponse extends Serenity.ServiceResponse {
        Inserted?: number;
        Updated?: number;
        ErrorList?: string[];
    }
}
declare namespace Serene3 {
    interface GetNextNumberRequest extends Serenity.ServiceRequest {
        Prefix?: string;
        Length?: number;
    }
}
declare namespace Serene3 {
    interface GetNextNumberResponse extends Serenity.ServiceResponse {
        Number?: number;
        Serial?: string;
    }
}
declare namespace Serene3.Membership {
    interface ChangePasswordForm {
        OldPassword: Serenity.PasswordEditor;
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Membership {
    interface ChangePasswordRequest extends Serenity.ServiceRequest {
        OldPassword?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Serene3.Membership {
    interface ForgotPasswordForm {
        Email: Serenity.EmailEditor;
    }
    class ForgotPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Membership {
    interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
declare namespace Serene3.Membership {
    interface LoginForm {
        Username: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
    }
    class LoginForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Membership {
    interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
    }
}
declare namespace Serene3.Membership {
    interface ResetPasswordForm {
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ResetPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Membership {
    interface ResetPasswordRequest extends Serenity.ServiceRequest {
        Token?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Serene3.Membership {
    interface SignUpForm {
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ConfirmEmail: Serenity.EmailEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class SignUpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Membership {
    interface SignUpRequest extends Serenity.ServiceRequest {
        DisplayName?: string;
        Email?: string;
        Password?: string;
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface CategoryForm {
        CategoryName: Serenity.StringEditor;
        Description: Serenity.StringEditor;
    }
    class CategoryForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface CategoryLangRow {
        Id?: number;
        CategoryId?: number;
        LanguageId?: number;
        CategoryName?: string;
        Description?: string;
    }
    namespace CategoryLangRow {
        const idProperty = "Id";
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.CategoryLang";
        const enum Fields {
            Id = "Id",
            CategoryId = "CategoryId",
            LanguageId = "LanguageId",
            CategoryName = "CategoryName",
            Description = "Description",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace CategoryLangService {
        const baseUrl = "Northwind/CategoryLang";
        function Create(request: Serenity.SaveRequest<CategoryLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CategoryLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CategoryLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CategoryLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/CategoryLang/Create",
            Update = "Northwind/CategoryLang/Update",
            Delete = "Northwind/CategoryLang/Delete",
            Retrieve = "Northwind/CategoryLang/Retrieve",
            List = "Northwind/CategoryLang/List",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CategoryRow {
        CategoryID?: number;
        CategoryName?: string;
        Description?: string;
        Picture?: number[];
    }
    namespace CategoryRow {
        const idProperty = "CategoryID";
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.Category";
        const lookupKey = "Northwind.Category";
        function getLookup(): Q.Lookup<CategoryRow>;
        const enum Fields {
            CategoryID = "CategoryID",
            CategoryName = "CategoryName",
            Description = "Description",
            Picture = "Picture",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace CategoryService {
        const baseUrl = "Northwind/Category";
        function Create(request: Serenity.SaveRequest<CategoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CategoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Category/Create",
            Update = "Northwind/Category/Update",
            Delete = "Northwind/Category/Delete",
            Retrieve = "Northwind/Category/Retrieve",
            List = "Northwind/Category/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface CustomerCustomerDemoRow {
        ID?: number;
        CustomerID?: string;
        CustomerTypeID?: string;
        CustomerCompanyName?: string;
        CustomerContactName?: string;
        CustomerContactTitle?: string;
        CustomerAddress?: string;
        CustomerCity?: string;
        CustomerRegion?: string;
        CustomerPostalCode?: string;
        CustomerCountry?: string;
        CustomerPhone?: string;
        CustomerFax?: string;
        CustomerTypeCustomerDesc?: string;
    }
    namespace CustomerCustomerDemoRow {
        const idProperty = "ID";
        const nameProperty = "CustomerID";
        const localTextPrefix = "Northwind.CustomerCustomerDemo";
        const enum Fields {
            ID = "ID",
            CustomerID = "CustomerID",
            CustomerTypeID = "CustomerTypeID",
            CustomerCompanyName = "CustomerCompanyName",
            CustomerContactName = "CustomerContactName",
            CustomerContactTitle = "CustomerContactTitle",
            CustomerAddress = "CustomerAddress",
            CustomerCity = "CustomerCity",
            CustomerRegion = "CustomerRegion",
            CustomerPostalCode = "CustomerPostalCode",
            CustomerCountry = "CustomerCountry",
            CustomerPhone = "CustomerPhone",
            CustomerFax = "CustomerFax",
            CustomerTypeCustomerDesc = "CustomerTypeCustomerDesc",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CustomerDemographicRow {
        ID?: number;
        CustomerTypeID?: string;
        CustomerDesc?: string;
    }
    namespace CustomerDemographicRow {
        const idProperty = "ID";
        const nameProperty = "CustomerTypeID";
        const localTextPrefix = "Northwind.CustomerDemographic";
        const enum Fields {
            ID = "ID",
            CustomerTypeID = "CustomerTypeID",
            CustomerDesc = "CustomerDesc",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CustomerDetailsRow {
        Id?: number;
        LastContactDate?: string;
        LastContactedBy?: number;
        Email?: string;
        SendBulletin?: boolean;
        LastContactedByLastName?: string;
        LastContactedByFirstName?: string;
        LastContactedByTitle?: string;
        LastContactedByTitleOfCourtesy?: string;
        LastContactedByBirthDate?: string;
        LastContactedByHireDate?: string;
        LastContactedByAddress?: string;
        LastContactedByCity?: string;
        LastContactedByRegion?: string;
        LastContactedByPostalCode?: string;
        LastContactedByCountry?: string;
        LastContactedByHomePhone?: string;
        LastContactedByExtension?: string;
        LastContactedByPhoto?: number[];
        LastContactedByNotes?: string;
        LastContactedByReportsTo?: number;
        LastContactedByPhotoPath?: string;
    }
    namespace CustomerDetailsRow {
        const idProperty = "Id";
        const nameProperty = "Email";
        const localTextPrefix = "Northwind.CustomerDetails";
        const enum Fields {
            Id = "Id",
            LastContactDate = "LastContactDate",
            LastContactedBy = "LastContactedBy",
            Email = "Email",
            SendBulletin = "SendBulletin",
            LastContactedByLastName = "LastContactedByLastName",
            LastContactedByFirstName = "LastContactedByFirstName",
            LastContactedByTitle = "LastContactedByTitle",
            LastContactedByTitleOfCourtesy = "LastContactedByTitleOfCourtesy",
            LastContactedByBirthDate = "LastContactedByBirthDate",
            LastContactedByHireDate = "LastContactedByHireDate",
            LastContactedByAddress = "LastContactedByAddress",
            LastContactedByCity = "LastContactedByCity",
            LastContactedByRegion = "LastContactedByRegion",
            LastContactedByPostalCode = "LastContactedByPostalCode",
            LastContactedByCountry = "LastContactedByCountry",
            LastContactedByHomePhone = "LastContactedByHomePhone",
            LastContactedByExtension = "LastContactedByExtension",
            LastContactedByPhoto = "LastContactedByPhoto",
            LastContactedByNotes = "LastContactedByNotes",
            LastContactedByReportsTo = "LastContactedByReportsTo",
            LastContactedByPhotoPath = "LastContactedByPhotoPath",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CustomerForm {
        CustomerID: Serenity.StringEditor;
        CompanyName: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        ContactTitle: Serenity.StringEditor;
        Representatives: Serenity.LookupEditor;
        Address: Serenity.StringEditor;
        Country: Serenity.LookupEditor;
        City: Serenity.LookupEditor;
        Region: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        NoteList: NotesEditor;
        LastContactDate: Serenity.DateEditor;
        LastContactedBy: Serenity.LookupEditor;
        Email: Serenity.EmailEditor;
        SendBulletin: Serenity.BooleanEditor;
    }
    class CustomerForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface CustomerGrossSalesRow {
        CustomerId?: string;
        ContactName?: string;
        ProductId?: number;
        ProductName?: string;
        GrossAmount?: number;
    }
    namespace CustomerGrossSalesRow {
        const nameProperty = "ContactName";
        const localTextPrefix = "Northwind.CustomerGrossSales";
        const enum Fields {
            CustomerId = "CustomerId",
            ContactName = "ContactName",
            ProductId = "ProductId",
            ProductName = "ProductName",
            GrossAmount = "GrossAmount",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CustomerRepresentativesRow {
        RepresentativeId?: number;
        CustomerId?: number;
        EmployeeId?: number;
    }
    namespace CustomerRepresentativesRow {
        const idProperty = "RepresentativeId";
        const localTextPrefix = "Northwind.CustomerRepresentatives";
        const enum Fields {
            RepresentativeId = "RepresentativeId",
            CustomerId = "CustomerId",
            EmployeeId = "EmployeeId",
        }
    }
}
declare namespace Serene3.Northwind {
    interface CustomerRow {
        ID?: number;
        CustomerID?: string;
        CompanyName?: string;
        ContactName?: string;
        ContactTitle?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        Phone?: string;
        Fax?: string;
        NoteList?: NoteRow[];
        Representatives?: number[];
        LastContactDate?: string;
        LastContactedBy?: number;
        Email?: string;
        SendBulletin?: boolean;
    }
    namespace CustomerRow {
        const idProperty = "ID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Customer";
        const lookupKey = "Northwind.Customer";
        function getLookup(): Q.Lookup<CustomerRow>;
        const enum Fields {
            ID = "ID",
            CustomerID = "CustomerID",
            CompanyName = "CompanyName",
            ContactName = "ContactName",
            ContactTitle = "ContactTitle",
            Address = "Address",
            City = "City",
            Region = "Region",
            PostalCode = "PostalCode",
            Country = "Country",
            Phone = "Phone",
            Fax = "Fax",
            NoteList = "NoteList",
            Representatives = "Representatives",
            LastContactDate = "LastContactDate",
            LastContactedBy = "LastContactedBy",
            Email = "Email",
            SendBulletin = "SendBulletin",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace CustomerService {
        const baseUrl = "Northwind/Customer";
        function Create(request: Serenity.SaveRequest<CustomerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CustomerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetNextNumber(request: GetNextNumberRequest, onSuccess?: (response: GetNextNumberResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CustomerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CustomerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Customer/Create",
            Update = "Northwind/Customer/Update",
            Delete = "Northwind/Customer/Delete",
            GetNextNumber = "Northwind/Customer/GetNextNumber",
            Retrieve = "Northwind/Customer/Retrieve",
            List = "Northwind/Customer/List",
        }
    }
}
declare namespace Serene3.Northwind {
    interface EmployeeRow {
        EmployeeID?: number;
        LastName?: string;
        FirstName?: string;
        FullName?: string;
        Title?: string;
        TitleOfCourtesy?: string;
        BirthDate?: string;
        HireDate?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        HomePhone?: string;
        Extension?: string;
        Photo?: number[];
        Notes?: string;
        ReportsTo?: number;
        PhotoPath?: string;
        ReportsToFullName?: string;
        ReportsToLastName?: string;
        ReportsToFirstName?: string;
        ReportsToTitle?: string;
        ReportsToTitleOfCourtesy?: string;
        ReportsToBirthDate?: string;
        ReportsToHireDate?: string;
        ReportsToAddress?: string;
        ReportsToCity?: string;
        ReportsToRegion?: string;
        ReportsToPostalCode?: string;
        ReportsToCountry?: string;
        ReportsToHomePhone?: string;
        ReportsToExtension?: string;
        ReportsToPhoto?: number[];
        ReportsToNotes?: string;
        ReportsToReportsTo?: number;
        ReportsToPhotoPath?: string;
        Gender?: Gender;
    }
    namespace EmployeeRow {
        const idProperty = "EmployeeID";
        const nameProperty = "FullName";
        const localTextPrefix = "Northwind.Employee";
        const lookupKey = "Northwind.Employee";
        function getLookup(): Q.Lookup<EmployeeRow>;
        const enum Fields {
            EmployeeID = "EmployeeID",
            LastName = "LastName",
            FirstName = "FirstName",
            FullName = "FullName",
            Title = "Title",
            TitleOfCourtesy = "TitleOfCourtesy",
            BirthDate = "BirthDate",
            HireDate = "HireDate",
            Address = "Address",
            City = "City",
            Region = "Region",
            PostalCode = "PostalCode",
            Country = "Country",
            HomePhone = "HomePhone",
            Extension = "Extension",
            Photo = "Photo",
            Notes = "Notes",
            ReportsTo = "ReportsTo",
            PhotoPath = "PhotoPath",
            ReportsToFullName = "ReportsToFullName",
            ReportsToLastName = "ReportsToLastName",
            ReportsToFirstName = "ReportsToFirstName",
            ReportsToTitle = "ReportsToTitle",
            ReportsToTitleOfCourtesy = "ReportsToTitleOfCourtesy",
            ReportsToBirthDate = "ReportsToBirthDate",
            ReportsToHireDate = "ReportsToHireDate",
            ReportsToAddress = "ReportsToAddress",
            ReportsToCity = "ReportsToCity",
            ReportsToRegion = "ReportsToRegion",
            ReportsToPostalCode = "ReportsToPostalCode",
            ReportsToCountry = "ReportsToCountry",
            ReportsToHomePhone = "ReportsToHomePhone",
            ReportsToExtension = "ReportsToExtension",
            ReportsToPhoto = "ReportsToPhoto",
            ReportsToNotes = "ReportsToNotes",
            ReportsToReportsTo = "ReportsToReportsTo",
            ReportsToPhotoPath = "ReportsToPhotoPath",
            Gender = "Gender",
        }
    }
}
declare namespace Serene3.Northwind {
    interface EmployeeTerritoryRow {
        EmployeeID?: number;
        TerritoryID?: string;
        EmployeeLastName?: string;
        EmployeeFirstName?: string;
        EmployeeTitle?: string;
        EmployeeTitleOfCourtesy?: string;
        EmployeeBirthDate?: string;
        EmployeeHireDate?: string;
        EmployeeAddress?: string;
        EmployeeCity?: string;
        EmployeeRegion?: string;
        EmployeePostalCode?: string;
        EmployeeCountry?: string;
        EmployeeHomePhone?: string;
        EmployeeExtension?: string;
        EmployeePhoto?: number[];
        EmployeeNotes?: string;
        EmployeeReportsTo?: number;
        EmployeePhotoPath?: string;
        TerritoryTerritoryDescription?: string;
        TerritoryRegionID?: number;
    }
    namespace EmployeeTerritoryRow {
        const idProperty = "EmployeeID";
        const nameProperty = "TerritoryID";
        const localTextPrefix = "Northwind.EmployeeTerritory";
        const enum Fields {
            EmployeeID = "EmployeeID",
            TerritoryID = "TerritoryID",
            EmployeeLastName = "EmployeeLastName",
            EmployeeFirstName = "EmployeeFirstName",
            EmployeeTitle = "EmployeeTitle",
            EmployeeTitleOfCourtesy = "EmployeeTitleOfCourtesy",
            EmployeeBirthDate = "EmployeeBirthDate",
            EmployeeHireDate = "EmployeeHireDate",
            EmployeeAddress = "EmployeeAddress",
            EmployeeCity = "EmployeeCity",
            EmployeeRegion = "EmployeeRegion",
            EmployeePostalCode = "EmployeePostalCode",
            EmployeeCountry = "EmployeeCountry",
            EmployeeHomePhone = "EmployeeHomePhone",
            EmployeeExtension = "EmployeeExtension",
            EmployeePhoto = "EmployeePhoto",
            EmployeeNotes = "EmployeeNotes",
            EmployeeReportsTo = "EmployeeReportsTo",
            EmployeePhotoPath = "EmployeePhotoPath",
            TerritoryTerritoryDescription = "TerritoryTerritoryDescription",
            TerritoryRegionID = "TerritoryRegionID",
        }
    }
}
declare namespace Serene3.Northwind {
    enum Gender {
        Male = 1,
        Female = 2,
    }
}
declare namespace Serene3.Northwind {
    interface NoteRow {
        NoteId?: number;
        EntityType?: string;
        EntityId?: number;
        Text?: string;
        InsertUserId?: number;
        InsertDate?: string;
        InsertUserDisplayName?: string;
    }
    namespace NoteRow {
        const idProperty = "NoteId";
        const nameProperty = "EntityType";
        const localTextPrefix = "Northwind.Note";
        const enum Fields {
            NoteId = "NoteId",
            EntityType = "EntityType",
            EntityId = "EntityId",
            Text = "Text",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            InsertUserDisplayName = "InsertUserDisplayName",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface OrderDetailForm {
        ProductID: Serenity.LookupEditor;
        UnitPrice: Serenity.DecimalEditor;
        Quantity: Serenity.IntegerEditor;
        Discount: Serenity.DecimalEditor;
    }
    class OrderDetailForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface OrderDetailRow {
        DetailID?: number;
        OrderID?: number;
        ProductID?: number;
        UnitPrice?: number;
        Quantity?: number;
        Discount?: number;
        OrderCustomerID?: string;
        OrderEmployeeID?: number;
        OrderDate?: string;
        OrderShippedDate?: string;
        OrderShipVia?: number;
        OrderShipCity?: string;
        OrderShipCountry?: string;
        ProductName?: string;
        ProductDiscontinued?: boolean;
        ProductSupplierID?: number;
        ProductQuantityPerUnit?: string;
        ProductUnitPrice?: number;
        LineTotal?: number;
    }
    namespace OrderDetailRow {
        const idProperty = "DetailID";
        const localTextPrefix = "Northwind.OrderDetail";
        const enum Fields {
            DetailID = "DetailID",
            OrderID = "OrderID",
            ProductID = "ProductID",
            UnitPrice = "UnitPrice",
            Quantity = "Quantity",
            Discount = "Discount",
            OrderCustomerID = "OrderCustomerID",
            OrderEmployeeID = "OrderEmployeeID",
            OrderDate = "OrderDate",
            OrderShippedDate = "OrderShippedDate",
            OrderShipVia = "OrderShipVia",
            OrderShipCity = "OrderShipCity",
            OrderShipCountry = "OrderShipCountry",
            ProductName = "ProductName",
            ProductDiscontinued = "ProductDiscontinued",
            ProductSupplierID = "ProductSupplierID",
            ProductQuantityPerUnit = "ProductQuantityPerUnit",
            ProductUnitPrice = "ProductUnitPrice",
            LineTotal = "LineTotal",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace OrderDetailService {
        const baseUrl = "Northwind/OrderDetail";
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<OrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Retrieve = "Northwind/OrderDetail/Retrieve",
            List = "Northwind/OrderDetail/List",
        }
    }
}
declare namespace Serene3.Northwind {
    interface OrderForm {
        CustomerID: CustomerEditor;
        OrderDate: Serenity.DateEditor;
        RequiredDate: Serenity.DateEditor;
        EmployeeID: Serenity.LookupEditor;
        DetailList: OrderDetailsEditor;
        ShippedDate: Serenity.DateEditor;
        ShipVia: Serenity.LookupEditor;
        Freight: Serenity.DecimalEditor;
        ShipName: Serenity.StringEditor;
        ShipAddress: Serenity.StringEditor;
        ShipCity: Serenity.StringEditor;
        ShipRegion: Serenity.StringEditor;
        ShipPostalCode: Serenity.StringEditor;
        ShipCountry: Serenity.StringEditor;
    }
    class OrderForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface OrderListRequest extends Serenity.ListRequest {
        ProductID?: number;
    }
}
declare namespace Serene3.Northwind {
    interface OrderRow {
        OrderID?: number;
        CustomerID?: string;
        EmployeeID?: number;
        OrderDate?: string;
        RequiredDate?: string;
        ShippedDate?: string;
        ShipVia?: number;
        Freight?: number;
        ShipName?: string;
        ShipAddress?: string;
        ShipCity?: string;
        ShipRegion?: string;
        ShipPostalCode?: string;
        ShipCountry?: string;
        CustomerCompanyName?: string;
        CustomerContactName?: string;
        CustomerContactTitle?: string;
        CustomerCity?: string;
        CustomerRegion?: string;
        CustomerCountry?: string;
        CustomerPhone?: string;
        CustomerFax?: string;
        EmployeeFullName?: string;
        EmployeeGender?: Gender;
        EmployeeReportsToFullName?: string;
        ShipViaCompanyName?: string;
        ShipViaPhone?: string;
        ShippingState?: OrderShippingState;
        DetailList?: OrderDetailRow[];
    }
    namespace OrderRow {
        const idProperty = "OrderID";
        const nameProperty = "CustomerID";
        const localTextPrefix = "Northwind.Order";
        const enum Fields {
            OrderID = "OrderID",
            CustomerID = "CustomerID",
            EmployeeID = "EmployeeID",
            OrderDate = "OrderDate",
            RequiredDate = "RequiredDate",
            ShippedDate = "ShippedDate",
            ShipVia = "ShipVia",
            Freight = "Freight",
            ShipName = "ShipName",
            ShipAddress = "ShipAddress",
            ShipCity = "ShipCity",
            ShipRegion = "ShipRegion",
            ShipPostalCode = "ShipPostalCode",
            ShipCountry = "ShipCountry",
            CustomerCompanyName = "CustomerCompanyName",
            CustomerContactName = "CustomerContactName",
            CustomerContactTitle = "CustomerContactTitle",
            CustomerCity = "CustomerCity",
            CustomerRegion = "CustomerRegion",
            CustomerCountry = "CustomerCountry",
            CustomerPhone = "CustomerPhone",
            CustomerFax = "CustomerFax",
            EmployeeFullName = "EmployeeFullName",
            EmployeeGender = "EmployeeGender",
            EmployeeReportsToFullName = "EmployeeReportsToFullName",
            ShipViaCompanyName = "ShipViaCompanyName",
            ShipViaPhone = "ShipViaPhone",
            ShippingState = "ShippingState",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace OrderService {
        const baseUrl = "Northwind/Order";
        function Create(request: Serenity.SaveRequest<OrderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<OrderRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<OrderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: OrderListRequest, onSuccess?: (response: Serenity.ListResponse<OrderRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Order/Create",
            Update = "Northwind/Order/Update",
            Delete = "Northwind/Order/Delete",
            Retrieve = "Northwind/Order/Retrieve",
            List = "Northwind/Order/List",
        }
    }
}
declare namespace Serene3.Northwind {
    enum OrderShippingState {
        NotShipped = 0,
        Shipped = 1,
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface ProductForm {
        ProductName: Serenity.StringEditor;
        ProductImage: Serenity.ImageUploadEditor;
        Discontinued: Serenity.BooleanEditor;
        SupplierID: Serenity.LookupEditor;
        CategoryID: Serenity.LookupEditor;
        QuantityPerUnit: Serenity.StringEditor;
        UnitPrice: Serenity.DecimalEditor;
        UnitsInStock: Serenity.IntegerEditor;
        UnitsOnOrder: Serenity.IntegerEditor;
        ReorderLevel: Serenity.IntegerEditor;
    }
    class ProductForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface ProductLangRow {
        Id?: number;
        ProductId?: number;
        LanguageId?: number;
        ProductName?: string;
    }
    namespace ProductLangRow {
        const idProperty = "Id";
        const nameProperty = "ProductName";
        const localTextPrefix = "Northwind.ProductLang";
        const enum Fields {
            Id = "Id",
            ProductId = "ProductId",
            LanguageId = "LanguageId",
            ProductName = "ProductName",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace ProductLangService {
        const baseUrl = "Northwind/ProductLang";
        function Create(request: Serenity.SaveRequest<ProductLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ProductLangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProductLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProductLangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/ProductLang/Create",
            Update = "Northwind/ProductLang/Update",
            Delete = "Northwind/ProductLang/Delete",
            Retrieve = "Northwind/ProductLang/Retrieve",
            List = "Northwind/ProductLang/List",
        }
    }
}
declare namespace Serene3.Northwind {
    interface ProductLogRow {
        ProductLogID?: number;
        OperationType?: Serenity.CaptureOperationType;
        ChangingUserId?: number;
        ValidFrom?: string;
        ValidUntil?: string;
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        QuantityPerUnit?: string;
        UnitPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
    }
    namespace ProductLogRow {
        const idProperty = "ProductLogID";
        const localTextPrefix = "Northwind.ProductLog";
        const enum Fields {
            ProductLogID = "ProductLogID",
            OperationType = "OperationType",
            ChangingUserId = "ChangingUserId",
            ValidFrom = "ValidFrom",
            ValidUntil = "ValidUntil",
            ProductID = "ProductID",
            ProductName = "ProductName",
            ProductImage = "ProductImage",
            Discontinued = "Discontinued",
            SupplierID = "SupplierID",
            CategoryID = "CategoryID",
            QuantityPerUnit = "QuantityPerUnit",
            UnitPrice = "UnitPrice",
            UnitsInStock = "UnitsInStock",
            UnitsOnOrder = "UnitsOnOrder",
            ReorderLevel = "ReorderLevel",
        }
    }
}
declare namespace Serene3.Northwind {
    interface ProductRow {
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        QuantityPerUnit?: string;
        UnitPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
        SupplierCompanyName?: string;
        SupplierContactName?: string;
        SupplierContactTitle?: string;
        SupplierAddress?: string;
        SupplierCity?: string;
        SupplierRegion?: string;
        SupplierPostalCode?: string;
        SupplierCountry?: string;
        SupplierPhone?: string;
        SupplierFax?: string;
        SupplierHomePage?: string;
        CategoryName?: string;
        CategoryDescription?: string;
        CategoryPicture?: number[];
    }
    namespace ProductRow {
        const idProperty = "ProductID";
        const nameProperty = "ProductName";
        const localTextPrefix = "Northwind.Product";
        const lookupKey = "Northwind.Product";
        function getLookup(): Q.Lookup<ProductRow>;
        const enum Fields {
            ProductID = "ProductID",
            ProductName = "ProductName",
            ProductImage = "ProductImage",
            Discontinued = "Discontinued",
            SupplierID = "SupplierID",
            CategoryID = "CategoryID",
            QuantityPerUnit = "QuantityPerUnit",
            UnitPrice = "UnitPrice",
            UnitsInStock = "UnitsInStock",
            UnitsOnOrder = "UnitsOnOrder",
            ReorderLevel = "ReorderLevel",
            SupplierCompanyName = "SupplierCompanyName",
            SupplierContactName = "SupplierContactName",
            SupplierContactTitle = "SupplierContactTitle",
            SupplierAddress = "SupplierAddress",
            SupplierCity = "SupplierCity",
            SupplierRegion = "SupplierRegion",
            SupplierPostalCode = "SupplierPostalCode",
            SupplierCountry = "SupplierCountry",
            SupplierPhone = "SupplierPhone",
            SupplierFax = "SupplierFax",
            SupplierHomePage = "SupplierHomePage",
            CategoryName = "CategoryName",
            CategoryDescription = "CategoryDescription",
            CategoryPicture = "CategoryPicture",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace ProductService {
        const baseUrl = "Northwind/Product";
        function Create(request: Serenity.SaveRequest<ProductRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ProductRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ProductRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ProductRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Product/Create",
            Update = "Northwind/Product/Update",
            Delete = "Northwind/Product/Delete",
            Retrieve = "Northwind/Product/Retrieve",
            List = "Northwind/Product/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface RegionForm {
        RegionID: Serenity.IntegerEditor;
        RegionDescription: Serenity.StringEditor;
    }
    class RegionForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface RegionRow {
        RegionID?: number;
        RegionDescription?: string;
    }
    namespace RegionRow {
        const idProperty = "RegionID";
        const nameProperty = "RegionDescription";
        const localTextPrefix = "Northwind.Region";
        const lookupKey = "Northwind.Region";
        function getLookup(): Q.Lookup<RegionRow>;
        const enum Fields {
            RegionID = "RegionID",
            RegionDescription = "RegionDescription",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace RegionService {
        const baseUrl = "Northwind/Region";
        function Create(request: Serenity.SaveRequest<RegionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RegionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RegionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RegionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Region/Create",
            Update = "Northwind/Region/Update",
            Delete = "Northwind/Region/Delete",
            Retrieve = "Northwind/Region/Retrieve",
            List = "Northwind/Region/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface SalesByCategoryRow {
        CategoryId?: number;
        CategoryName?: string;
        ProductName?: string;
        ProductSales?: number;
    }
    namespace SalesByCategoryRow {
        const nameProperty = "CategoryName";
        const localTextPrefix = "Northwind.SalesByCategory";
        const enum Fields {
            CategoryId = "CategoryId",
            CategoryName = "CategoryName",
            ProductName = "ProductName",
            ProductSales = "ProductSales",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace SalesByCategoryService {
        const baseUrl = "Northwind/SalesByCategory";
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SalesByCategoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "Northwind/SalesByCategory/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface ShipperForm {
        CompanyName: Serenity.StringEditor;
        Phone: PhoneEditor;
    }
    class ShipperForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface ShipperRow {
        ShipperID?: number;
        CompanyName?: string;
        Phone?: string;
    }
    namespace ShipperRow {
        const idProperty = "ShipperID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Shipper";
        const lookupKey = "Northwind.Shipper";
        function getLookup(): Q.Lookup<ShipperRow>;
        const enum Fields {
            ShipperID = "ShipperID",
            CompanyName = "CompanyName",
            Phone = "Phone",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace ShipperService {
        const baseUrl = "Northwind/Shipper";
        function Create(request: Serenity.SaveRequest<ShipperRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ShipperRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ShipperRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ShipperRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Shipper/Create",
            Update = "Northwind/Shipper/Update",
            Delete = "Northwind/Shipper/Delete",
            Retrieve = "Northwind/Shipper/Retrieve",
            List = "Northwind/Shipper/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface SupplierForm {
        CompanyName: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        ContactTitle: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Region: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        Country: Serenity.StringEditor;
        City: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        HomePage: Serenity.StringEditor;
    }
    class SupplierForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface SupplierRow {
        SupplierID?: number;
        CompanyName?: string;
        ContactName?: string;
        ContactTitle?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        Phone?: string;
        Fax?: string;
        HomePage?: string;
    }
    namespace SupplierRow {
        const idProperty = "SupplierID";
        const nameProperty = "CompanyName";
        const localTextPrefix = "Northwind.Supplier";
        const lookupKey = "Northwind.Supplier";
        function getLookup(): Q.Lookup<SupplierRow>;
        const enum Fields {
            SupplierID = "SupplierID",
            CompanyName = "CompanyName",
            ContactName = "ContactName",
            ContactTitle = "ContactTitle",
            Address = "Address",
            City = "City",
            Region = "Region",
            PostalCode = "PostalCode",
            Country = "Country",
            Phone = "Phone",
            Fax = "Fax",
            HomePage = "HomePage",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace SupplierService {
        const baseUrl = "Northwind/Supplier";
        function Create(request: Serenity.SaveRequest<SupplierRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SupplierRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SupplierRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SupplierRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Supplier/Create",
            Update = "Northwind/Supplier/Update",
            Delete = "Northwind/Supplier/Delete",
            Retrieve = "Northwind/Supplier/Retrieve",
            List = "Northwind/Supplier/List",
        }
    }
}
declare namespace Serene3.Northwind {
}
declare namespace Serene3.Northwind {
    interface TerritoryForm {
        TerritoryID: Serenity.StringEditor;
        TerritoryDescription: Serenity.StringEditor;
        RegionID: Serenity.LookupEditor;
    }
    class TerritoryForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.Northwind {
    interface TerritoryRow {
        ID?: number;
        TerritoryID?: string;
        TerritoryDescription?: string;
        RegionID?: number;
        RegionDescription?: string;
    }
    namespace TerritoryRow {
        const idProperty = "ID";
        const nameProperty = "TerritoryID";
        const localTextPrefix = "Northwind.Territory";
        const lookupKey = "Northwind.Territory";
        function getLookup(): Q.Lookup<TerritoryRow>;
        const enum Fields {
            ID = "ID",
            TerritoryID = "TerritoryID",
            TerritoryDescription = "TerritoryDescription",
            RegionID = "RegionID",
            RegionDescription = "RegionDescription",
        }
    }
}
declare namespace Serene3.Northwind {
    namespace TerritoryService {
        const baseUrl = "Northwind/Territory";
        function Create(request: Serenity.SaveRequest<TerritoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TerritoryRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TerritoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TerritoryRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Northwind/Territory/Create",
            Update = "Northwind/Territory/Update",
            Delete = "Northwind/Territory/Delete",
            Retrieve = "Northwind/Territory/Retrieve",
            List = "Northwind/Territory/List",
        }
    }
}
declare namespace Serene3 {
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        Permissions?: {
            [key: string]: boolean;
        };
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBanThanhPhamForm {
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        NgayTao: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
    }
    class TblBanThanhPhamForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBanThanhPhamRow {
        KeyId?: number;
        MotaBtp?: string;
        DonViTinh?: string;
        NgayTao?: string;
        Status?: boolean;
    }
    namespace TblBanThanhPhamRow {
        const idProperty = "KeyId";
        const nameProperty = "MotaBtp";
        const localTextPrefix = "SpringPrintingConnection.TblBanThanhPham";
        const lookupKey = "SpringPrintingConnection.TblBanThanhPham";
        function getLookup(): Q.Lookup<TblBanThanhPhamRow>;
        const enum Fields {
            KeyId = "KeyId",
            MotaBtp = "MotaBtp",
            DonViTinh = "DonViTinh",
            NgayTao = "NgayTao",
            Status = "Status",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblBanThanhPhamService {
        const baseUrl = "SpringPrintingConnection/TblBanThanhPham";
        function Create(request: Serenity.SaveRequest<TblBanThanhPhamRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblBanThanhPhamRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBanThanhPhamRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBanThanhPhamRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblBanThanhPham/Create",
            Update = "SpringPrintingConnection/TblBanThanhPham/Update",
            Delete = "SpringPrintingConnection/TblBanThanhPham/Delete",
            Retrieve = "SpringPrintingConnection/TblBanThanhPham/Retrieve",
            List = "SpringPrintingConnection/TblBanThanhPham/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBoBtpForm {
        MaLo: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaHd: Serenity.LookupEditor;
        TypeID: Serenity.LookupEditor;
    }
    class TblBoBtpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBoBtpRow {
        KeyId?: number;
        MaLo?: number;
        MaBtp?: number;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaIn?: number;
        MaOut?: number;
        MaLenChuyen?: number;
        MaXuongChuyen?: number;
        MaMau?: number;
        MaSize?: number;
        HangMau?: boolean;
        HangBu?: boolean;
        MaHd?: number;
        CardId?: number;
        Code?: string;
        MaFeStockOut?: string;
        MaStyle?: number;
        TypeID?: string;
        BulNo?: number;
        TableNum?: string;
        Fepo?: string;
        MaLoMaKh?: number;
        MaLoNgayNhap?: string;
        MaLoNguoiNhap?: number;
        MaLoSoLuong?: number;
        MaLoGhiChu?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        MaStyle1?: string;
        MaStyleTenStyle?: string;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        TypeID1?: string;
        MaTypeTenType?: string;
    }
    namespace TblBoBtpRow {
        const idProperty = "KeyId";
        const nameProperty = "Code";
        const localTextPrefix = "SpringPrintingConnection.TblBoBtp";
        const enum Fields {
            KeyId = "KeyId",
            MaLo = "MaLo",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaIn = "MaIn",
            MaOut = "MaOut",
            MaLenChuyen = "MaLenChuyen",
            MaXuongChuyen = "MaXuongChuyen",
            MaMau = "MaMau",
            MaSize = "MaSize",
            HangMau = "HangMau",
            HangBu = "HangBu",
            MaHd = "MaHd",
            CardId = "CardId",
            Code = "Code",
            MaFeStockOut = "MaFeStockOut",
            MaStyle = "MaStyle",
            TypeID = "TypeID",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Fepo = "Fepo",
            MaLoMaKh = "MaLoMaKh",
            MaLoNgayNhap = "MaLoNgayNhap",
            MaLoNguoiNhap = "MaLoNguoiNhap",
            MaLoSoLuong = "MaLoSoLuong",
            MaLoGhiChu = "MaLoGhiChu",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            MaStyle1 = "MaStyle1",
            MaStyleTenStyle = "MaStyleTenStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            TypeID1 = "TypeID1",
            MaTypeTenType = "MaTypeTenType",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblBoBtpService {
        const baseUrl = "SpringPrintingConnection/TblBoBtp";
        function Create(request: Serenity.SaveRequest<TblBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetData(request: SpringPrintingConnection.TTblBoBtpRow.TblBoBtpRowListRequest, onSuccess?: (response: System.String) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblBoBtp/Create",
            Update = "SpringPrintingConnection/TblBoBtp/Update",
            Delete = "SpringPrintingConnection/TblBoBtp/Delete",
            Retrieve = "SpringPrintingConnection/TblBoBtp/Retrieve",
            List = "SpringPrintingConnection/TblBoBtp/List",
            GetData = "SpringPrintingConnection/TblBoBtp/GetData",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBo_BTPForm {
        MaLo: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        MaHd: Serenity.LookupEditor;
        TypeID: Serenity.LookupEditor;
    }
    class TblBo_BTPForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblBo_BTPRow {
        KeyId?: number;
        MaLo?: number;
        MaBtp?: number;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaIn?: number;
        MaOut?: number;
        MaLenChuyen?: number;
        MaXuongChuyen?: number;
        MaMau?: number;
        MaSize?: number;
        HangMau?: boolean;
        HangBu?: boolean;
        MaHd?: number;
        CardId?: number;
        Code?: string;
        MaFeStockOut?: string;
        MaStyle?: number;
        TypeID?: string;
        MaLoMaKh?: number;
        MaLoNgayNhap?: string;
        MaLoNguoiNhap?: number;
        MaLoSoLuong?: number;
        MaLoGhiChu?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        MaStyle1?: string;
        MaStyleTenStyle?: string;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        TypeID1?: string;
        MaTypeTenType?: string;
    }
    namespace TblBo_BTPRow {
        const idProperty = "KeyId";
        const nameProperty = "MaBtpMotaBtp";
        const localTextPrefix = "SpringPrintingConnection.TblBo_BTP";
        const lookupKey = "SpringPrintingConnection.TblBo_BTP";
        function getLookup(): Q.Lookup<TblBo_BTPRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaLo = "MaLo",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaIn = "MaIn",
            MaOut = "MaOut",
            MaLenChuyen = "MaLenChuyen",
            MaXuongChuyen = "MaXuongChuyen",
            MaMau = "MaMau",
            MaSize = "MaSize",
            HangMau = "HangMau",
            HangBu = "HangBu",
            MaHd = "MaHd",
            CardId = "CardId",
            Code = "Code",
            MaFeStockOut = "MaFeStockOut",
            MaStyle = "MaStyle",
            TypeID = "TypeID",
            MaLoMaKh = "MaLoMaKh",
            MaLoNgayNhap = "MaLoNgayNhap",
            MaLoNguoiNhap = "MaLoNguoiNhap",
            MaLoSoLuong = "MaLoSoLuong",
            MaLoGhiChu = "MaLoGhiChu",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            MaStyle1 = "MaStyle1",
            MaStyleTenStyle = "MaStyleTenStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            TypeID1 = "TypeID1",
            MaTypeTenType = "MaTypeTenType",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblBo_BTPService {
        const baseUrl = "SpringPrintingConnection/TblBo_BTP";
        function Create(request: Serenity.SaveRequest<TblBo_BTPRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblBo_BTPRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBo_BTPRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBo_BTPRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblBo_BTP/Create",
            Update = "SpringPrintingConnection/TblBo_BTP/Update",
            Delete = "SpringPrintingConnection/TblBo_BTP/Delete",
            Retrieve = "SpringPrintingConnection/TblBo_BTP/Retrieve",
            List = "SpringPrintingConnection/TblBo_BTP/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblFeCardInfoForm {
        CardId: Serenity.StringEditor;
        RefBarCode: Serenity.StringEditor;
        CreateTime: Serenity.DateEditor;
        ImportTime: Serenity.DateEditor;
    }
    class TblFeCardInfoForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblFeCardInfoRow {
        RecId?: string;
        CardId?: number;
        RefBarCode?: string;
        CreateTime?: string;
        ImportTime?: string;
    }
    namespace TblFeCardInfoRow {
        const idProperty = "RecId";
        const nameProperty = "RefBarCode";
        const localTextPrefix = "SpringPrintingConnection.TblFeCardInfo";
        const enum Fields {
            RecId = "RecId",
            CardId = "CardId",
            RefBarCode = "RefBarCode",
            CreateTime = "CreateTime",
            ImportTime = "ImportTime",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblFeCardInfoService {
        const baseUrl = "SpringPrintingConnection/TblFeCardInfo";
        function Create(request: Serenity.SaveRequest<TblFeCardInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblFeCardInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblFeCardInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblFeCardInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblFeCardInfo/Create",
            Update = "SpringPrintingConnection/TblFeCardInfo/Update",
            Delete = "SpringPrintingConnection/TblFeCardInfo/Delete",
            Retrieve = "SpringPrintingConnection/TblFeCardInfo/Retrieve",
            List = "SpringPrintingConnection/TblFeCardInfo/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblFeStockOutInfoForm {
        RfidOutputId: Serenity.IntegerEditor;
        DDate: Serenity.DateEditor;
        Fty: Serenity.StringEditor;
        Po: Serenity.StringEditor;
        Fepo: Serenity.StringEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        BulNo: Serenity.IntegerEditor;
        TableNum: Serenity.StringEditor;
        Buy: Serenity.StringEditor;
        Style04: Serenity.StringEditor;
        Col: Serenity.StringEditor;
        Size: Serenity.StringEditor;
        Part: Serenity.StringEditor;
        OpNo: Serenity.StringEditor;
        OpName: Serenity.StringEditor;
        Quantity: Serenity.IntegerEditor;
        ImportTime: Serenity.DateEditor;
    }
    class TblFeStockOutInfoForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblFeStockOutInfoRow {
        RecId?: string;
        RfidOutputId?: number;
        DDate?: string;
        Fty?: string;
        Po?: string;
        Fepo?: string;
        CardId?: number;
        Code?: string;
        BulNo?: number;
        TableNum?: string;
        Buy?: string;
        Style04?: string;
        Col?: string;
        Size?: string;
        Part?: string;
        OpNo?: string;
        OpName?: string;
        Quantity?: number;
        ImportTime?: string;
    }
    namespace TblFeStockOutInfoRow {
        const idProperty = "RecId";
        const nameProperty = "Fty";
        const localTextPrefix = "SpringPrintingConnection.TblFeStockOutInfo";
        const enum Fields {
            RecId = "RecId",
            RfidOutputId = "RfidOutputId",
            DDate = "DDate",
            Fty = "Fty",
            Po = "Po",
            Fepo = "Fepo",
            CardId = "CardId",
            Code = "Code",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Buy = "Buy",
            Style04 = "Style04",
            Col = "Col",
            Size = "Size",
            Part = "Part",
            OpNo = "OpNo",
            OpName = "OpName",
            Quantity = "Quantity",
            ImportTime = "ImportTime",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblFeStockOutInfoService {
        const baseUrl = "SpringPrintingConnection/TblFeStockOutInfo";
        function Create(request: Serenity.SaveRequest<TblFeStockOutInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblFeStockOutInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblFeStockOutInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblFeStockOutInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblFeStockOutInfo/Create",
            Update = "SpringPrintingConnection/TblFeStockOutInfo/Update",
            Delete = "SpringPrintingConnection/TblFeStockOutInfo/Delete",
            Retrieve = "SpringPrintingConnection/TblFeStockOutInfo/Retrieve",
            List = "SpringPrintingConnection/TblFeStockOutInfo/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongChiTietForm {
        KeyId: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
    }
    class TblHopDongChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongChiTietRow {
        KeyId?: number;
        MaHd?: number;
        MaBtp?: number;
        MaMau?: number;
        MaSize?: number;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        MaStyle?: number;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        MaStyle1?: string;
        MaStyleTenStyle?: string;
    }
    namespace TblHopDongChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblHopDongChiTiet";
        const lookupKey = "SpringPrintingConnection.TblHopDongChiTiet";
        function getLookup(): Q.Lookup<TblHopDongChiTietRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            MaBtp = "MaBtp",
            MaMau = "MaMau",
            MaSize = "MaSize",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
            MaStyle = "MaStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            MaStyle1 = "MaStyle1",
            MaStyleTenStyle = "MaStyleTenStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblHopDongChiTietService {
        const baseUrl = "SpringPrintingConnection/TblHopDongChiTiet";
        function Create(request: Serenity.SaveRequest<TblHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblHopDongChiTiet/Create",
            Update = "SpringPrintingConnection/TblHopDongChiTiet/Update",
            Delete = "SpringPrintingConnection/TblHopDongChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDongChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblHopDongChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongDieuChinhForm {
        MaChiTietHd: Serenity.LookupEditor;
        SlNhan: Serenity.IntegerEditor;
        SlNhanHu: Serenity.IntegerEditor;
        SlInHu: Serenity.IntegerEditor;
        SlXuat: Serenity.IntegerEditor;
        MaNv: Serenity.LookupEditor;
        NgayDc: Serenity.DateEditor;
    }
    class TblHopDongDieuChinhForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongDieuChinhRow {
        KeyId?: number;
        MaHd?: number;
        SlNhan?: number;
        SlNhanHu?: number;
        SlInHu?: number;
        SlXuat?: number;
        MaNv?: number;
        NgayDc?: string;
        MaChiTietHd?: number;
        MaHd1?: number;
        MaHdMaBtp?: number;
        MaHdMaMau?: number;
        MaHdMaSize?: number;
        MaHdSoLuong?: number;
        MaHdDonGia?: number;
        MaHdThanhTien?: number;
        MaHdMaStyle?: number;
        MaNvHoTen?: string;
        MaNvGioiTinh?: string;
        MaNvPhone?: string;
        MaNvMobile?: string;
        MaNvEmail?: string;
        MaNvChucVu?: string;
        MaNvStatus?: boolean;
        MaChiTietHdMaHd?: number;
        MaChiTietHdMaBtp?: number;
        MaChiTietHdMaMau?: number;
        MaChiTietHdMaSize?: number;
        MaChiTietHdSoLuong?: number;
        MaChiTietHdDonGia?: number;
        MaChiTietHdThanhTien?: number;
        MaChiTietHdMaStyle?: number;
    }
    namespace TblHopDongDieuChinhRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblHopDongDieuChinh";
        const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            SlNhan = "SlNhan",
            SlNhanHu = "SlNhanHu",
            SlInHu = "SlInHu",
            SlXuat = "SlXuat",
            MaNv = "MaNv",
            NgayDc = "NgayDc",
            MaChiTietHd = "MaChiTietHd",
            MaHd1 = "MaHd1",
            MaHdMaBtp = "MaHdMaBtp",
            MaHdMaMau = "MaHdMaMau",
            MaHdMaSize = "MaHdMaSize",
            MaHdSoLuong = "MaHdSoLuong",
            MaHdDonGia = "MaHdDonGia",
            MaHdThanhTien = "MaHdThanhTien",
            MaHdMaStyle = "MaHdMaStyle",
            MaNvHoTen = "MaNvHoTen",
            MaNvGioiTinh = "MaNvGioiTinh",
            MaNvPhone = "MaNvPhone",
            MaNvMobile = "MaNvMobile",
            MaNvEmail = "MaNvEmail",
            MaNvChucVu = "MaNvChucVu",
            MaNvStatus = "MaNvStatus",
            MaChiTietHdMaHd = "MaChiTietHdMaHd",
            MaChiTietHdMaBtp = "MaChiTietHdMaBtp",
            MaChiTietHdMaMau = "MaChiTietHdMaMau",
            MaChiTietHdMaSize = "MaChiTietHdMaSize",
            MaChiTietHdSoLuong = "MaChiTietHdSoLuong",
            MaChiTietHdDonGia = "MaChiTietHdDonGia",
            MaChiTietHdThanhTien = "MaChiTietHdThanhTien",
            MaChiTietHdMaStyle = "MaChiTietHdMaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblHopDongDieuChinhService {
        const baseUrl = "SpringPrintingConnection/TblHopDongDieuChinh";
        function Create(request: Serenity.SaveRequest<TblHopDongDieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblHopDongDieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDongDieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDongDieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblHopDongDieuChinh/Create",
            Update = "SpringPrintingConnection/TblHopDongDieuChinh/Update",
            Delete = "SpringPrintingConnection/TblHopDongDieuChinh/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDongDieuChinh/Retrieve",
            List = "SpringPrintingConnection/TblHopDongDieuChinh/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongForm {
        MaKh: Serenity.LookupEditor;
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        NvTao: Serenity.LookupEditor;
        DetailList: TblHopDongChiTiet_Editor;
    }
    class TblHopDongForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDongRow {
        KeyId?: number;
        MaKh?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        NvTao?: number;
        Ngay?: string;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
        NvTaoHoTen?: string;
        NvTaoGioiTinh?: string;
        NvTaoPhone?: string;
        NvTaoMobile?: string;
        NvTaoEmail?: string;
        NvTaoChucVu?: string;
        NvTaoStatus?: boolean;
        DetailList?: TblHopDong_ChiTietRow[];
    }
    namespace TblHopDongRow {
        const idProperty = "KeyId";
        const nameProperty = "SoHd";
        const localTextPrefix = "SpringPrintingConnection.TblHopDong";
        const lookupKey = "SpringPrintingConnection.TblHopDong";
        function getLookup(): Q.Lookup<TblHopDongRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            NvTao = "NvTao",
            Ngay = "Ngay",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst",
            NvTaoHoTen = "NvTaoHoTen",
            NvTaoGioiTinh = "NvTaoGioiTinh",
            NvTaoPhone = "NvTaoPhone",
            NvTaoMobile = "NvTaoMobile",
            NvTaoEmail = "NvTaoEmail",
            NvTaoChucVu = "NvTaoChucVu",
            NvTaoStatus = "NvTaoStatus",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblHopDongService {
        const baseUrl = "SpringPrintingConnection/TblHopDong";
        function Create(request: Serenity.SaveRequest<TblHopDongRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblHopDongRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDongRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDongRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblHopDong/Create",
            Update = "SpringPrintingConnection/TblHopDong/Update",
            Delete = "SpringPrintingConnection/TblHopDong/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDong/Retrieve",
            List = "SpringPrintingConnection/TblHopDong/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDong_ChiTietForm {
        KeyId: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
        AdjDetailList: TblHopDong_DieuChinhEditor;
    }
    class TblHopDong_ChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDong_ChiTietRow {
        KeyId?: number;
        MaHd?: number;
        MaBtp?: number;
        MaMau?: number;
        MaSize?: number;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        MaStyle?: number;
        MaStyleTenStyle?: string;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        AdjDetailList?: TblHopDong_DieuChinhRow[];
    }
    namespace TblHopDong_ChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblHopDong_ChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            MaBtp = "MaBtp",
            MaMau = "MaMau",
            MaSize = "MaSize",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
            MaStyle = "MaStyle",
            MaStyleTenStyle = "MaStyleTenStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            AdjDetailList = "AdjDetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblHopDong_ChiTietService {
        const baseUrl = "SpringPrintingConnection/TblHopDong_ChiTiet";
        function Create(request: Serenity.SaveRequest<TblHopDong_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblHopDong_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDong_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDong_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblHopDong_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblHopDong_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblHopDong_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDong_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblHopDong_ChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDong_DieuChinhForm {
        MaNv: Serenity.LookupEditor;
        SlNhan: Serenity.IntegerEditor;
        SlNhanHu: Serenity.IntegerEditor;
        SlInHu: Serenity.IntegerEditor;
        SlXuat: Serenity.IntegerEditor;
        NgayDc: Serenity.DateEditor;
    }
    class TblHopDong_DieuChinhForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblHopDong_DieuChinhRow {
        KeyId?: number;
        MaHd?: number;
        SlNhan?: number;
        SlNhanHu?: number;
        SlInHu?: number;
        SlXuat?: number;
        MaNv?: number;
        NgayDc?: string;
        MaChiTietHd?: number;
        MaHd1?: number;
        MaHdMaBtp?: number;
        MaHdMaMau?: number;
        MaHdMaSize?: number;
        MaHdSoLuong?: number;
        MaHdDonGia?: number;
        MaHdThanhTien?: number;
        MaHdMaStyle?: number;
        MaNvHoTen?: string;
        MaNvGioiTinh?: string;
        MaNvPhone?: string;
        MaNvMobile?: string;
        MaNvEmail?: string;
        MaNvChucVu?: string;
        MaNvStatus?: boolean;
        MaChiTietHdMaHd?: number;
        MaChiTietHdMaBtp?: number;
        MaChiTietHdMaMau?: number;
        MaChiTietHdMaSize?: number;
        MaChiTietHdSoLuong?: number;
        MaChiTietHdDonGia?: number;
        MaChiTietHdThanhTien?: number;
        MaChiTietHdMaStyle?: number;
    }
    namespace TblHopDong_DieuChinhRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblHopDong_DieuChinh";
        const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            SlNhan = "SlNhan",
            SlNhanHu = "SlNhanHu",
            SlInHu = "SlInHu",
            SlXuat = "SlXuat",
            MaNv = "MaNv",
            NgayDc = "NgayDc",
            MaChiTietHd = "MaChiTietHd",
            MaHd1 = "MaHd1",
            MaHdMaBtp = "MaHdMaBtp",
            MaHdMaMau = "MaHdMaMau",
            MaHdMaSize = "MaHdMaSize",
            MaHdSoLuong = "MaHdSoLuong",
            MaHdDonGia = "MaHdDonGia",
            MaHdThanhTien = "MaHdThanhTien",
            MaHdMaStyle = "MaHdMaStyle",
            MaNvHoTen = "MaNvHoTen",
            MaNvGioiTinh = "MaNvGioiTinh",
            MaNvPhone = "MaNvPhone",
            MaNvMobile = "MaNvMobile",
            MaNvEmail = "MaNvEmail",
            MaNvChucVu = "MaNvChucVu",
            MaNvStatus = "MaNvStatus",
            MaChiTietHdMaHd = "MaChiTietHdMaHd",
            MaChiTietHdMaBtp = "MaChiTietHdMaBtp",
            MaChiTietHdMaMau = "MaChiTietHdMaMau",
            MaChiTietHdMaSize = "MaChiTietHdMaSize",
            MaChiTietHdSoLuong = "MaChiTietHdSoLuong",
            MaChiTietHdDonGia = "MaChiTietHdDonGia",
            MaChiTietHdThanhTien = "MaChiTietHdThanhTien",
            MaChiTietHdMaStyle = "MaChiTietHdMaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblHopDong_DieuChinhService {
        const baseUrl = "SpringPrintingConnection/TblHopDong_DieuChinh";
        function Create(request: Serenity.SaveRequest<TblHopDong_DieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblHopDong_DieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDong_DieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDong_DieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblHopDong_DieuChinh/Create",
            Update = "SpringPrintingConnection/TblHopDong_DieuChinh/Update",
            Delete = "SpringPrintingConnection/TblHopDong_DieuChinh/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDong_DieuChinh/Retrieve",
            List = "SpringPrintingConnection/TblHopDong_DieuChinh/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblKhachHangForm {
        MaKh: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        DiaChi: Serenity.StringEditor;
        NguoiDaiDien: Serenity.IntegerEditor;
        Phone: Serenity.StringEditor;
        Mst: Serenity.StringEditor;
    }
    class TblKhachHangForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblKhachHangRow {
        KeyId?: number;
        MaKh?: string;
        TenKh?: string;
        DiaChi?: string;
        NguoiDaiDien?: number;
        Phone?: string;
        Mst?: string;
        NguoiDaiDienHoTen?: string;
        NguoiDaiDienGioiTinh?: string;
        NguoiDaiDienPhone?: string;
        NguoiDaiDienMobile?: string;
        NguoiDaiDienEmail?: string;
        NguoiDaiDienChucVu?: string;
        NguoiDaiDienMaKh?: number;
        NguoiDaiDienStatus?: boolean;
    }
    namespace TblKhachHangRow {
        const idProperty = "KeyId";
        const nameProperty = "TenKh";
        const localTextPrefix = "SpringPrintingConnection.TblKhachHang";
        const lookupKey = "SpringPrintingConnection.TblKhachHang";
        function getLookup(): Q.Lookup<TblKhachHangRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            TenKh = "TenKh",
            DiaChi = "DiaChi",
            NguoiDaiDien = "NguoiDaiDien",
            Phone = "Phone",
            Mst = "Mst",
            NguoiDaiDienHoTen = "NguoiDaiDienHoTen",
            NguoiDaiDienGioiTinh = "NguoiDaiDienGioiTinh",
            NguoiDaiDienPhone = "NguoiDaiDienPhone",
            NguoiDaiDienMobile = "NguoiDaiDienMobile",
            NguoiDaiDienEmail = "NguoiDaiDienEmail",
            NguoiDaiDienChucVu = "NguoiDaiDienChucVu",
            NguoiDaiDienMaKh = "NguoiDaiDienMaKh",
            NguoiDaiDienStatus = "NguoiDaiDienStatus",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblKhachHangService {
        const baseUrl = "SpringPrintingConnection/TblKhachHang";
        function Create(request: Serenity.SaveRequest<TblKhachHangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblKhachHangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblKhachHangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblKhachHangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblKhachHang/Create",
            Update = "SpringPrintingConnection/TblKhachHang/Update",
            Delete = "SpringPrintingConnection/TblKhachHang/Delete",
            Retrieve = "SpringPrintingConnection/TblKhachHang/Retrieve",
            List = "SpringPrintingConnection/TblKhachHang/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenForm {
        MaNvQuet: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        DetailList: TblLenChuyenIn_ChiTietEditor;
    }
    class TblLenChuyenForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection.TblLenChuyenInChiTiet {
    interface TblLenChuyenInChiTietListRequest extends Serenity.ListRequest {
        Note?: string;
        MaLenChuyen?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection.TblLenChuyenInChiTiet {
    interface TblLenChuyenInChiTietListResponse extends Serenity.ListResponse<TblLenChuyenInChiTietListResponse> {
        KeyID?: string;
        ErrorCode?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenInChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        MaLenChuyen: Serenity.IntegerEditor;
        CT_SL_Thuc: Serenity.IntegerEditor;
        CT_SL_Loi_KH: Serenity.IntegerEditor;
    }
    class TblLenChuyenInChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenInChiTietRow {
        KeyId?: number;
        MaBo?: number;
        Ngay?: string;
        Status?: boolean;
        MaLenChuyen?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaLenChuyenMaNvQuet?: number;
        MaLenChuyenNgay?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
        BulNo?: number;
        TableNum?: string;
        Fepo?: string;
    }
    namespace TblLenChuyenInChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblLenChuyenInChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            Ngay = "Ngay",
            Status = "Status",
            MaLenChuyen = "MaLenChuyen",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaLenChuyenMaNvQuet = "MaLenChuyenMaNvQuet",
            MaLenChuyenNgay = "MaLenChuyenNgay",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Fepo = "Fepo",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblLenChuyenInChiTietService {
        const baseUrl = "SpringPrintingConnection/TblLenChuyenInChiTiet";
        function Create(request: Serenity.SaveRequest<TblLenChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblLenChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetData(request: SpringPrintingConnection.TblLenChuyenInChiTiet.TblLenChuyenInChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblLenChuyenInChiTiet.TblLenChuyenInChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyenInChiTiet/Create",
            Update = "SpringPrintingConnection/TblLenChuyenInChiTiet/Update",
            Delete = "SpringPrintingConnection/TblLenChuyenInChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyenInChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyenInChiTiet/List",
            GetData = "SpringPrintingConnection/TblLenChuyenInChiTiet/GetData",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenIn_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaLenChuyen: Serenity.IntegerEditor;
    }
    class TblLenChuyenIn_ChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenIn_ChiTietRow {
        KeyId?: number;
        MaBo?: number;
        MotaBTP?: string;
        Ngay?: string;
        Status?: boolean;
        MaLenChuyen?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaLenChuyenMaNvQuet?: number;
        MaLenChuyenNgay?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
    }
    namespace TblLenChuyenIn_ChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblLenChuyenIn_ChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            MotaBTP = "MotaBTP",
            Ngay = "Ngay",
            Status = "Status",
            MaLenChuyen = "MaLenChuyen",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaLenChuyenMaNvQuet = "MaLenChuyenMaNvQuet",
            MaLenChuyenNgay = "MaLenChuyenNgay",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblLenChuyenIn_ChiTietService {
        const baseUrl = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet";
        function Create(request: Serenity.SaveRequest<TblLenChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblLenChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLenChuyenRow {
        KeyId?: number;
        MaNvQuet?: number;
        Ngay?: string;
        MaNvQuetHoTen?: string;
        MaNvQuetGioiTinh?: string;
        MaNvQuetPhone?: string;
        MaNvQuetMobile?: string;
        MaNvQuetEmail?: string;
        MaNvQuetChucVu?: string;
        MaNvQuetStatus?: boolean;
        DetailList?: TblLenChuyenIn_ChiTietRow[];
    }
    namespace TblLenChuyenRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblLenChuyen";
        const enum Fields {
            KeyId = "KeyId",
            MaNvQuet = "MaNvQuet",
            Ngay = "Ngay",
            MaNvQuetHoTen = "MaNvQuetHoTen",
            MaNvQuetGioiTinh = "MaNvQuetGioiTinh",
            MaNvQuetPhone = "MaNvQuetPhone",
            MaNvQuetMobile = "MaNvQuetMobile",
            MaNvQuetEmail = "MaNvQuetEmail",
            MaNvQuetChucVu = "MaNvQuetChucVu",
            MaNvQuetStatus = "MaNvQuetStatus",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblLenChuyenService {
        const baseUrl = "SpringPrintingConnection/TblLenChuyen";
        function Create(request: Serenity.SaveRequest<TblLenChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblLenChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyen/Create",
            Update = "SpringPrintingConnection/TblLenChuyen/Update",
            Delete = "SpringPrintingConnection/TblLenChuyen/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyen/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyen/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection.TblLoSp {
    interface TblLoSpRowListRequest extends Serenity.ListRequest {
        Note?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLoSpForm {
        KeyId: Serenity.IntegerEditor;
        MaKh: Serenity.LookupEditor;
        NgayNhap: Serenity.DateEditor;
        NguoiNhap: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        GhiChu: Serenity.StringEditor;
        DetailList: TblBo_BTPEditor;
    }
    class TblLoSpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblLoSpRow {
        KeyId?: number;
        MaKh?: number;
        NgayNhap?: string;
        NguoiNhap?: number;
        SoLuong?: number;
        GhiChu?: string;
        TenKH?: string;
        NguoiNhapHoTen?: string;
        NguoiNhapGioiTinh?: string;
        NguoiNhapPhone?: string;
        NguoiNhapMobile?: string;
        NguoiNhapEmail?: string;
        NguoiNhapChucVu?: string;
        NguoiNhapStatus?: boolean;
        Note?: string;
        DetailList?: TblBo_BTPRow[];
    }
    namespace TblLoSpRow {
        const idProperty = "KeyId";
        const nameProperty = "TenKH";
        const localTextPrefix = "SpringPrintingConnection.TblLoSp";
        const lookupKey = "SpringPrintingConnection.TblLoSp";
        function getLookup(): Q.Lookup<TblLoSpRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayNhap = "NgayNhap",
            NguoiNhap = "NguoiNhap",
            SoLuong = "SoLuong",
            GhiChu = "GhiChu",
            TenKH = "TenKH",
            NguoiNhapHoTen = "NguoiNhapHoTen",
            NguoiNhapGioiTinh = "NguoiNhapGioiTinh",
            NguoiNhapPhone = "NguoiNhapPhone",
            NguoiNhapMobile = "NguoiNhapMobile",
            NguoiNhapEmail = "NguoiNhapEmail",
            NguoiNhapChucVu = "NguoiNhapChucVu",
            NguoiNhapStatus = "NguoiNhapStatus",
            Note = "Note",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblLoSpService {
        const baseUrl = "SpringPrintingConnection/TblLoSp";
        function Create(request: Serenity.SaveRequest<TblLoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblLoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetData(request: SpringPrintingConnection.TblLoSp.TblLoSpRowListRequest, onSuccess?: (response: System.String) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblLoSp/Create",
            Update = "SpringPrintingConnection/TblLoSp/Update",
            Delete = "SpringPrintingConnection/TblLoSp/Delete",
            Retrieve = "SpringPrintingConnection/TblLoSp/Retrieve",
            List = "SpringPrintingConnection/TblLoSp/List",
            GetData = "SpringPrintingConnection/TblLoSp/GetData",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblNguoiDungForm {
        HoTen: Serenity.StringEditor;
        GioiTinh: Serenity.LookupEditor;
        Phone: Serenity.StringEditor;
        Mobile: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ChucVu: Serenity.StringEditor;
        Status: Serenity.BooleanEditor;
    }
    class TblNguoiDungForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblNguoiDungRow {
        KeyId?: number;
        HoTen?: string;
        GioiTinh?: string;
        SexName?: string;
        Phone?: string;
        Mobile?: string;
        Email?: string;
        ChucVu?: string;
        Status?: boolean;
    }
    namespace TblNguoiDungRow {
        const idProperty = "KeyId";
        const nameProperty = "HoTen";
        const localTextPrefix = "SpringPrintingConnection.TblNguoiDung";
        const lookupKey = "SpringPrintingConnection.TblNguoiDung";
        function getLookup(): Q.Lookup<TblNguoiDungRow>;
        const enum Fields {
            KeyId = "KeyId",
            HoTen = "HoTen",
            GioiTinh = "GioiTinh",
            SexName = "SexName",
            Phone = "Phone",
            Mobile = "Mobile",
            Email = "Email",
            ChucVu = "ChucVu",
            Status = "Status",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblNguoiDungService {
        const baseUrl = "SpringPrintingConnection/TblNguoiDung";
        function Create(request: Serenity.SaveRequest<TblNguoiDungRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblNguoiDungRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblNguoiDungRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblNguoiDungRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblNguoiDung/Create",
            Update = "SpringPrintingConnection/TblNguoiDung/Update",
            Delete = "SpringPrintingConnection/TblNguoiDung/Delete",
            Retrieve = "SpringPrintingConnection/TblNguoiDung/Retrieve",
            List = "SpringPrintingConnection/TblNguoiDung/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefMauForm {
        MaMau: Serenity.StringEditor;
        TenMau: Serenity.StringEditor;
    }
    class TblRefMauForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefMauRow {
        KeyId?: number;
        MaMau?: string;
        TenMau?: string;
    }
    namespace TblRefMauRow {
        const idProperty = "KeyId";
        const nameProperty = "TenMau";
        const localTextPrefix = "SpringPrintingConnection.TblRefMau";
        const lookupKey = "SpringPrintingConnection.TblRefMau";
        function getLookup(): Q.Lookup<TblRefMauRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaMau = "MaMau",
            TenMau = "TenMau",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefMauService {
        const baseUrl = "SpringPrintingConnection/TblRefMau";
        function Create(request: Serenity.SaveRequest<TblRefMauRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefMauRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefMauRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefMauRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefMau/Create",
            Update = "SpringPrintingConnection/TblRefMau/Update",
            Delete = "SpringPrintingConnection/TblRefMau/Delete",
            Retrieve = "SpringPrintingConnection/TblRefMau/Retrieve",
            List = "SpringPrintingConnection/TblRefMau/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefNguoiDaiDienForm {
        HoTen: Serenity.StringEditor;
        GioiTinh: Serenity.LookupEditor;
        Phone: Serenity.StringEditor;
        Mobile: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ChucVu: Serenity.StringEditor;
        MaKh: Serenity.LookupEditor;
        Status: Serenity.BooleanEditor;
    }
    class TblRefNguoiDaiDienForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefNguoiDaiDienRow {
        KeyId?: number;
        HoTen?: string;
        GioiTinh?: string;
        SexName?: string;
        Phone?: string;
        Mobile?: string;
        Email?: string;
        ChucVu?: string;
        MaKh?: number;
        Status?: boolean;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
    }
    namespace TblRefNguoiDaiDienRow {
        const idProperty = "KeyId";
        const nameProperty = "HoTen";
        const localTextPrefix = "SpringPrintingConnection.TblRefNguoiDaiDien";
        const lookupKey = "SpringPrintingConnection.TblRefNguoiDaiDien";
        function getLookup(): Q.Lookup<TblRefNguoiDaiDienRow>;
        const enum Fields {
            KeyId = "KeyId",
            HoTen = "HoTen",
            GioiTinh = "GioiTinh",
            SexName = "SexName",
            Phone = "Phone",
            Mobile = "Mobile",
            Email = "Email",
            ChucVu = "ChucVu",
            MaKh = "MaKh",
            Status = "Status",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefNguoiDaiDienService {
        const baseUrl = "SpringPrintingConnection/TblRefNguoiDaiDien";
        function Create(request: Serenity.SaveRequest<TblRefNguoiDaiDienRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefNguoiDaiDienRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefNguoiDaiDienRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefNguoiDaiDienRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefNguoiDaiDien/Create",
            Update = "SpringPrintingConnection/TblRefNguoiDaiDien/Update",
            Delete = "SpringPrintingConnection/TblRefNguoiDaiDien/Delete",
            Retrieve = "SpringPrintingConnection/TblRefNguoiDaiDien/Retrieve",
            List = "SpringPrintingConnection/TblRefNguoiDaiDien/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefSexForm {
        SexName: Serenity.StringEditor;
    }
    class TblRefSexForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefSexRow {
        SexId?: string;
        SexName?: string;
    }
    namespace TblRefSexRow {
        const idProperty = "SexId";
        const nameProperty = "SexId";
        const localTextPrefix = "SpringPrintingConnection.TblRefSex";
        const lookupKey = "SpringPrintingConnection.TblRefSex";
        function getLookup(): Q.Lookup<TblRefSexRow>;
        const enum Fields {
            SexId = "SexId",
            SexName = "SexName",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefSexService {
        const baseUrl = "SpringPrintingConnection/TblRefSex";
        function Create(request: Serenity.SaveRequest<TblRefSexRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefSexRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefSexRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefSexRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefSex/Create",
            Update = "SpringPrintingConnection/TblRefSex/Update",
            Delete = "SpringPrintingConnection/TblRefSex/Delete",
            Retrieve = "SpringPrintingConnection/TblRefSex/Retrieve",
            List = "SpringPrintingConnection/TblRefSex/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefSizeForm {
        MaSize: Serenity.StringEditor;
        TenSize: Serenity.StringEditor;
    }
    class TblRefSizeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefSizeRow {
        KeyId?: number;
        MaSize?: string;
        TenSize?: string;
    }
    namespace TblRefSizeRow {
        const idProperty = "KeyId";
        const nameProperty = "TenSize";
        const localTextPrefix = "SpringPrintingConnection.TblRefSize";
        const lookupKey = "SpringPrintingConnection.TblRefSize";
        function getLookup(): Q.Lookup<TblRefSizeRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaSize = "MaSize",
            TenSize = "TenSize",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefSizeService {
        const baseUrl = "SpringPrintingConnection/TblRefSize";
        function Create(request: Serenity.SaveRequest<TblRefSizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefSizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefSizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefSizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefSize/Create",
            Update = "SpringPrintingConnection/TblRefSize/Update",
            Delete = "SpringPrintingConnection/TblRefSize/Delete",
            Retrieve = "SpringPrintingConnection/TblRefSize/Retrieve",
            List = "SpringPrintingConnection/TblRefSize/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefStyleForm {
        MaStyle: Serenity.StringEditor;
        TenStyle: Serenity.StringEditor;
    }
    class TblRefStyleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefStyleRow {
        KeyId?: number;
        MaStyle?: string;
        TenStyle?: string;
    }
    namespace TblRefStyleRow {
        const idProperty = "KeyId";
        const nameProperty = "TenStyle";
        const localTextPrefix = "SpringPrintingConnection.TblRefStyle";
        const lookupKey = "SpringPrintingConnection.TblRefStyle";
        function getLookup(): Q.Lookup<TblRefStyleRow>;
        const enum Fields {
            KeyId = "KeyId",
            MaStyle = "MaStyle",
            TenStyle = "TenStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefStyleService {
        const baseUrl = "SpringPrintingConnection/TblRefStyle";
        function Create(request: Serenity.SaveRequest<TblRefStyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefStyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefStyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefStyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefStyle/Create",
            Update = "SpringPrintingConnection/TblRefStyle/Update",
            Delete = "SpringPrintingConnection/TblRefStyle/Delete",
            Retrieve = "SpringPrintingConnection/TblRefStyle/Retrieve",
            List = "SpringPrintingConnection/TblRefStyle/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefTypeForm {
        TypeName: Serenity.StringEditor;
    }
    class TblRefTypeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblRefTypeRow {
        TypeId?: string;
        TypeName?: string;
    }
    namespace TblRefTypeRow {
        const idProperty = "TypeId";
        const nameProperty = "TypeName";
        const localTextPrefix = "SpringPrintingConnection.TblRefType";
        const lookupKey = "SpringPrintingConnection.TblRefType";
        function getLookup(): Q.Lookup<TblRefTypeRow>;
        const enum Fields {
            TypeId = "TypeId",
            TypeName = "TypeName",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblRefTypeService {
        const baseUrl = "SpringPrintingConnection/TblRefType";
        function Create(request: Serenity.SaveRequest<TblRefTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblRefTypeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefTypeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblRefType/Create",
            Update = "SpringPrintingConnection/TblRefType/Update",
            Delete = "SpringPrintingConnection/TblRefType/Delete",
            Retrieve = "SpringPrintingConnection/TblRefType/Retrieve",
            List = "SpringPrintingConnection/TblRefType/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection.TblXuatKhoChiTiet {
    interface TblXuatKhoChiTietListRequest extends Serenity.ListRequest {
        Note?: string;
        MaBo?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection.TblXuatKhoChiTiet {
    interface TblXuatKhoChiTietListResponse extends Serenity.ListResponse<TblXuatKhoChiTietListResponse> {
        KeyID?: string;
        ErrorCode?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKhoChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaPhieuXuat: Serenity.IntegerEditor;
    }
    class TblXuatKhoChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKhoChiTietRow {
        KeyId?: number;
        MaBo?: number;
        Ngay?: string;
        Status?: boolean;
        MaPhieuXuat?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaPhieuXuatMaKh?: number;
        MaPhieuXuatNgayXuat?: string;
        MaPhieuXuatMaNvXuat?: number;
        MaPhieuXuatSoPhieu?: string;
        MaPhieuXuatGhichu?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
        BulNo?: number;
        TableNum?: string;
        Fepo?: string;
    }
    namespace TblXuatKhoChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblXuatKhoChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            Ngay = "Ngay",
            Status = "Status",
            MaPhieuXuat = "MaPhieuXuat",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaPhieuXuatMaKh = "MaPhieuXuatMaKh",
            MaPhieuXuatNgayXuat = "MaPhieuXuatNgayXuat",
            MaPhieuXuatMaNvXuat = "MaPhieuXuatMaNvXuat",
            MaPhieuXuatSoPhieu = "MaPhieuXuatSoPhieu",
            MaPhieuXuatGhichu = "MaPhieuXuatGhichu",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Fepo = "Fepo",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuatKhoChiTietService {
        const baseUrl = "SpringPrintingConnection/TblXuatKhoChiTiet";
        function Create(request: Serenity.SaveRequest<TblXuatKhoChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuatKhoChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKhoChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKhoChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetData(request: SpringPrintingConnection.TblXuatKhoChiTiet.TblXuatKhoChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblXuatKhoChiTiet.TblXuatKhoChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKhoChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuatKhoChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuatKhoChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKhoChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuatKhoChiTiet/List",
            GetData = "SpringPrintingConnection/TblXuatKhoChiTiet/GetData",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKhoKhForm {
        MaKh: Serenity.LookupEditor;
        NgayXuat: Serenity.DateEditor;
        MaNvXuat: Serenity.LookupEditor;
        SoPhieu: Serenity.StringEditor;
        Ghichu: Serenity.StringEditor;
        DetailList: TblXuatKho_ChiTietEditor;
    }
    class TblXuatKhoKhForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKhoKhRow {
        KeyId?: number;
        MaKh?: number;
        NgayXuat?: string;
        MaNvXuat?: number;
        SoPhieu?: string;
        Ghichu?: string;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
        MaNvXuatHoTen?: string;
        MaNvXuatGioiTinh?: string;
        MaNvXuatPhone?: string;
        MaNvXuatMobile?: string;
        MaNvXuatEmail?: string;
        MaNvXuatChucVu?: string;
        MaNvXuatStatus?: boolean;
        DetailList?: TblXuatKho_ChiTietRow[];
    }
    namespace TblXuatKhoKhRow {
        const idProperty = "KeyId";
        const nameProperty = "SoPhieu";
        const localTextPrefix = "SpringPrintingConnection.TblXuatKhoKh";
        const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayXuat = "NgayXuat",
            MaNvXuat = "MaNvXuat",
            SoPhieu = "SoPhieu",
            Ghichu = "Ghichu",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst",
            MaNvXuatHoTen = "MaNvXuatHoTen",
            MaNvXuatGioiTinh = "MaNvXuatGioiTinh",
            MaNvXuatPhone = "MaNvXuatPhone",
            MaNvXuatMobile = "MaNvXuatMobile",
            MaNvXuatEmail = "MaNvXuatEmail",
            MaNvXuatChucVu = "MaNvXuatChucVu",
            MaNvXuatStatus = "MaNvXuatStatus",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuatKhoKhService {
        const baseUrl = "SpringPrintingConnection/TblXuatKhoKh";
        function Create(request: Serenity.SaveRequest<TblXuatKhoKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuatKhoKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKhoKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKhoKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKhoKh/Create",
            Update = "SpringPrintingConnection/TblXuatKhoKh/Update",
            Delete = "SpringPrintingConnection/TblXuatKhoKh/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKhoKh/Retrieve",
            List = "SpringPrintingConnection/TblXuatKhoKh/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKho_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaPhieuXuat: Serenity.IntegerEditor;
    }
    class TblXuatKho_ChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuatKho_ChiTietRow {
        KeyId?: number;
        MaBo?: number;
        Ngay?: string;
        Status?: boolean;
        MaPhieuXuat?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaPhieuXuatMaKh?: number;
        MaPhieuXuatNgayXuat?: string;
        MaPhieuXuatMaNvXuat?: number;
        MaPhieuXuatSoPhieu?: string;
        MaPhieuXuatGhichu?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
    }
    namespace TblXuatKho_ChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblXuatKho_ChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            Ngay = "Ngay",
            Status = "Status",
            MaPhieuXuat = "MaPhieuXuat",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaPhieuXuatMaKh = "MaPhieuXuatMaKh",
            MaPhieuXuatNgayXuat = "MaPhieuXuatNgayXuat",
            MaPhieuXuatMaNvXuat = "MaPhieuXuatMaNvXuat",
            MaPhieuXuatSoPhieu = "MaPhieuXuatSoPhieu",
            MaPhieuXuatGhichu = "MaPhieuXuatGhichu",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuatKho_ChiTietService {
        const baseUrl = "SpringPrintingConnection/TblXuatKho_ChiTiet";
        function Create(request: Serenity.SaveRequest<TblXuatKho_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuatKho_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKho_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKho_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKho_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuatKho_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuatKho_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKho_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuatKho_ChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenForm {
        MaNvQuet: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        DetailList: TblXuongChuyenIn_ChiTietEditor;
    }
    class TblXuongChuyenForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection.TblXuongChuyenInChiTiet {
    interface TblXuongChuyenInChiTietListRequest extends Serenity.ListRequest {
        Note?: string;
        MaXuongChuyen?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection.TblXuongChuyenInChiTiet {
    interface TblXuongChuyenInChiTietListResponse extends Serenity.ListResponse<TblXuongChuyenInChiTietListResponse> {
        KeyID?: string;
        ErrorCode?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenInChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        MaXuongChuyen: Serenity.IntegerEditor;
        Status: Serenity.BooleanEditor;
        CT_SL_Thuc: Serenity.IntegerEditor;
        CT_SL_Loi_KH: Serenity.IntegerEditor;
        LoiIn: Serenity.IntegerEditor;
    }
    class TblXuongChuyenInChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenInChiTietRow {
        KeyId?: number;
        MaBo?: number;
        Ngay?: string;
        MaXuongChuyen?: number;
        Status?: boolean;
        LoiIn?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaXuongChuyenMaNvQuet?: number;
        MaXuongChuyenNgay?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
        BulNo?: number;
        TableNum?: string;
        Fepo?: string;
    }
    namespace TblXuongChuyenInChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblXuongChuyenInChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            Ngay = "Ngay",
            MaXuongChuyen = "MaXuongChuyen",
            Status = "Status",
            LoiIn = "LoiIn",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaXuongChuyenMaNvQuet = "MaXuongChuyenMaNvQuet",
            MaXuongChuyenNgay = "MaXuongChuyenNgay",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Fepo = "Fepo",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuongChuyenInChiTietService {
        const baseUrl = "SpringPrintingConnection/TblXuongChuyenInChiTiet";
        function Create(request: Serenity.SaveRequest<TblXuongChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuongChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetData(request: SpringPrintingConnection.TblXuongChuyenInChiTiet.TblXuongChuyenInChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblXuongChuyenInChiTiet.TblXuongChuyenInChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyenInChiTiet/List",
            GetData = "SpringPrintingConnection/TblXuongChuyenInChiTiet/GetData",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenIn_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        MaXuongChuyen: Serenity.IntegerEditor;
        Status: Serenity.BooleanEditor;
    }
    class TblXuongChuyenIn_ChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenIn_ChiTietRow {
        KeyId?: number;
        MaBo?: number;
        Ngay?: string;
        MaXuongChuyen?: number;
        Status?: boolean;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaXuongChuyenMaNvQuet?: number;
        MaXuongChuyenNgay?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
    }
    namespace TblXuongChuyenIn_ChiTietRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblXuongChuyenIn_ChiTiet";
        const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            Ngay = "Ngay",
            MaXuongChuyen = "MaXuongChuyen",
            Status = "Status",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaXuongChuyenMaNvQuet = "MaXuongChuyenMaNvQuet",
            MaXuongChuyenNgay = "MaXuongChuyenNgay",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuongChuyenIn_ChiTietService {
        const baseUrl = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet";
        function Create(request: Serenity.SaveRequest<TblXuongChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuongChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface TblXuongChuyenRow {
        KeyId?: number;
        MaNvQuet?: number;
        Ngay?: string;
        MaNvQuetHoTen?: string;
        MaNvQuetGioiTinh?: string;
        MaNvQuetPhone?: string;
        MaNvQuetMobile?: string;
        MaNvQuetEmail?: string;
        MaNvQuetChucVu?: string;
        MaNvQuetStatus?: boolean;
        DetailList?: TblXuongChuyenIn_ChiTietRow[];
    }
    namespace TblXuongChuyenRow {
        const idProperty = "KeyId";
        const localTextPrefix = "SpringPrintingConnection.TblXuongChuyen";
        const enum Fields {
            KeyId = "KeyId",
            MaNvQuet = "MaNvQuet",
            Ngay = "Ngay",
            MaNvQuetHoTen = "MaNvQuetHoTen",
            MaNvQuetGioiTinh = "MaNvQuetGioiTinh",
            MaNvQuetPhone = "MaNvQuetPhone",
            MaNvQuetMobile = "MaNvQuetMobile",
            MaNvQuetEmail = "MaNvQuetEmail",
            MaNvQuetChucVu = "MaNvQuetChucVu",
            MaNvQuetStatus = "MaNvQuetStatus",
            DetailList = "DetailList",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace TblXuongChuyenService {
        const baseUrl = "SpringPrintingConnection/TblXuongChuyen";
        function Create(request: Serenity.SaveRequest<TblXuongChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TblXuongChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyen/Create",
            Update = "SpringPrintingConnection/TblXuongChuyen/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyen/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyen/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyen/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection.TTblBoBtpRow {
    interface TblBoBtpRowListRequest extends Serenity.ListRequest {
        Note?: string;
        MaLo?: string;
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtpForm {
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }
    class VChiTietBtpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtpRow {
        KeyId1?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }
    namespace VChiTietBtpRow {
        const idProperty = "KeyId1";
        const nameProperty = "MaBtp";
        const localTextPrefix = "SpringPrintingConnection.VChiTietBtp";
        const lookupKey = "SpringPrintingConnection.VChiTietBtp";
        function getLookup(): Q.Lookup<VChiTietBtpRow>;
        const enum Fields {
            KeyId1 = "KeyId1",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VChiTietBtpService {
        const baseUrl = "SpringPrintingConnection/VChiTietBtp";
        function Create(request: Serenity.SaveRequest<VChiTietBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VChiTietBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp/Create",
            Update = "SpringPrintingConnection/VChiTietBtp/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_SizeForm {
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }
    class VChiTietBtp_SizeForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_SizeRow {
        KeyId1?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }
    namespace VChiTietBtp_SizeRow {
        const idProperty = "KeyId1";
        const nameProperty = "MaSize";
        const localTextPrefix = "SpringPrintingConnection.VChiTietBtp_Size";
        const lookupKey = "SpringPrintingConnection.VChiTietBtp_Size";
        function getLookup(): Q.Lookup<VChiTietBtp_SizeRow>;
        const enum Fields {
            KeyId1 = "KeyId1",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VChiTietBtp_SizeService {
        const baseUrl = "SpringPrintingConnection/VChiTietBtp_Size";
        function Create(request: Serenity.SaveRequest<VChiTietBtp_SizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VChiTietBtp_SizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_SizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_SizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Size/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Size/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Size/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Size/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Size/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_StyleForm {
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }
    class VChiTietBtp_StyleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_StyleRow {
        KeyId1?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }
    namespace VChiTietBtp_StyleRow {
        const idProperty = "KeyId1";
        const nameProperty = "MaStyle";
        const localTextPrefix = "SpringPrintingConnection.VChiTietBtp_Style";
        const lookupKey = "SpringPrintingConnection.VChiTietBtp_Style";
        function getLookup(): Q.Lookup<VChiTietBtp_StyleRow>;
        const enum Fields {
            KeyId1 = "KeyId1",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VChiTietBtp_StyleService {
        const baseUrl = "SpringPrintingConnection/VChiTietBtp_Style";
        function Create(request: Serenity.SaveRequest<VChiTietBtp_StyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VChiTietBtp_StyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_StyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_StyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Style/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Style/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Style/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Style/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Style/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_Style_ColorForm {
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }
    class VChiTietBtp_Style_ColorForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VChiTietBtp_Style_ColorRow {
        KeyId1?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }
    namespace VChiTietBtp_Style_ColorRow {
        const idProperty = "KeyId1";
        const nameProperty = "MaMau";
        const localTextPrefix = "SpringPrintingConnection.VChiTietBtp_Style_Color";
        const lookupKey = "SpringPrintingConnection.VChiTietBtp_Style_Color";
        function getLookup(): Q.Lookup<VChiTietBtp_Style_ColorRow>;
        const enum Fields {
            KeyId1 = "KeyId1",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VChiTietBtp_Style_ColorService {
        const baseUrl = "SpringPrintingConnection/VChiTietBtp_Style_Color";
        function Create(request: Serenity.SaveRequest<VChiTietBtp_Style_ColorRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VChiTietBtp_Style_ColorRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_Style_ColorRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_Style_ColorRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Style_Color/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Style_Color/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Style_Color/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Style_Color/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Style_Color/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VHopDongChiTietForm {
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        MaKh: Serenity.StringEditor;
        MaBtp: Serenity.IntegerEditor;
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        MaMau: Serenity.StringEditor;
        TenMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        TenSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        TenStyle: Serenity.StringEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
    }
    class VHopDongChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VHopDongChiTietRow {
        MaHd?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        TenKh?: string;
        MaKh?: string;
        MaBtp?: number;
        MotaBtp?: string;
        DonViTinh?: string;
        MaMau?: string;
        TenMau?: string;
        MaSize?: string;
        TenSize?: string;
        MaStyle?: string;
        TenStyle?: string;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
    }
    namespace VHopDongChiTietRow {
        const idProperty = "MaHd";
        const nameProperty = "NoiDung";
        const localTextPrefix = "SpringPrintingConnection.VHopDongChiTiet";
        const enum Fields {
            MaHd = "MaHd",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            TenKh = "TenKh",
            MaKh = "MaKh",
            MaBtp = "MaBtp",
            MotaBtp = "MotaBtp",
            DonViTinh = "DonViTinh",
            MaMau = "MaMau",
            TenMau = "TenMau",
            MaSize = "MaSize",
            TenSize = "TenSize",
            MaStyle = "MaStyle",
            TenStyle = "TenStyle",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VHopDongChiTietService {
        const baseUrl = "SpringPrintingConnection/VHopDongChiTiet";
        function Create(request: Serenity.SaveRequest<VHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VHopDongChiTiet/Create",
            Update = "SpringPrintingConnection/VHopDongChiTiet/Update",
            Delete = "SpringPrintingConnection/VHopDongChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/VHopDongChiTiet/Retrieve",
            List = "SpringPrintingConnection/VHopDongChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VHopDongTrangThaiForm {
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        MaKh: Serenity.StringEditor;
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        MaMau: Serenity.IntegerEditor;
        TenMau: Serenity.StringEditor;
        MaSize: Serenity.IntegerEditor;
        TenSize: Serenity.StringEditor;
        MaStyle: Serenity.IntegerEditor;
        TenStyle: Serenity.StringEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
        SlNhap: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        SlThucXuat: Serenity.IntegerEditor;
        SlThieu: Serenity.IntegerEditor;
    }
    class VHopDongTrangThaiForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VHopDongTrangThaiRow {
        MaHd?: number;
        MaCT?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        TenKh?: string;
        MaKh?: string;
        MotaBtp?: string;
        DonViTinh?: string;
        MaMau?: number;
        TenMau?: string;
        MaSize?: number;
        TenSize?: string;
        MaStyle?: number;
        TenStyle?: string;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        SlNhap?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        SlThucXuat?: number;
        SlThieu?: number;
    }
    namespace VHopDongTrangThaiRow {
        const idProperty = "MaCT";
        const nameProperty = "NoiDung";
        const localTextPrefix = "SpringPrintingConnection.VHopDongTrangThai";
        const enum Fields {
            MaHd = "MaHd",
            MaCT = "MaCT",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            TenKh = "TenKh",
            MaKh = "MaKh",
            MotaBtp = "MotaBtp",
            DonViTinh = "DonViTinh",
            MaMau = "MaMau",
            TenMau = "TenMau",
            MaSize = "MaSize",
            TenSize = "TenSize",
            MaStyle = "MaStyle",
            TenStyle = "TenStyle",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
            SlNhap = "SlNhap",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            SlThucXuat = "SlThucXuat",
            SlThieu = "SlThieu",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VHopDongTrangThaiService {
        const baseUrl = "SpringPrintingConnection/VHopDongTrangThai";
        function Create(request: Serenity.SaveRequest<VHopDongTrangThaiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VHopDongTrangThaiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VHopDongTrangThaiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VHopDongTrangThaiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VHopDongTrangThai/Create",
            Update = "SpringPrintingConnection/VHopDongTrangThai/Update",
            Delete = "SpringPrintingConnection/VHopDongTrangThai/Delete",
            Retrieve = "SpringPrintingConnection/VHopDongTrangThai/Retrieve",
            List = "SpringPrintingConnection/VHopDongTrangThai/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VLenChuyenChiTietForm {
        Ngay: Serenity.DateEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }
    class VLenChuyenChiTietForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VLenChuyenChiTietRow {
        KeyId1?: number;
        Ngay?: string;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }
    namespace VLenChuyenChiTietRow {
        const idProperty = "KeyId1";
        const nameProperty = "Code";
        const localTextPrefix = "SpringPrintingConnection.VLenChuyenChiTiet";
        const enum Fields {
            KeyId1 = "KeyId1",
            Ngay = "Ngay",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VLenChuyenChiTietService {
        const baseUrl = "SpringPrintingConnection/VLenChuyenChiTiet";
        function Create(request: Serenity.SaveRequest<VLenChuyenChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VLenChuyenChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VLenChuyenChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VLenChuyenChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VLenChuyenChiTiet/Create",
            Update = "SpringPrintingConnection/VLenChuyenChiTiet/Update",
            Delete = "SpringPrintingConnection/VLenChuyenChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/VLenChuyenChiTiet/Retrieve",
            List = "SpringPrintingConnection/VLenChuyenChiTiet/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VLoSpKhForm {
        MaKh: Serenity.IntegerEditor;
        TenKh: Serenity.StringEditor;
    }
    class VLoSpKhForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VLoSpKhRow {
        KeyId1?: number;
        MaKh?: number;
        TenKh?: string;
    }
    namespace VLoSpKhRow {
        const idProperty = "KeyId1";
        const nameProperty = "TenKh";
        const localTextPrefix = "SpringPrintingConnection.VLoSpKh";
        const enum Fields {
            KeyId1 = "KeyId1",
            MaKh = "MaKh",
            TenKh = "TenKh",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VLoSpKhService {
        const baseUrl = "SpringPrintingConnection/VLoSpKh";
        function Create(request: Serenity.SaveRequest<VLoSpKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VLoSpKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VLoSpKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VLoSpKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VLoSpKh/Create",
            Update = "SpringPrintingConnection/VLoSpKh/Update",
            Delete = "SpringPrintingConnection/VLoSpKh/Delete",
            Retrieve = "SpringPrintingConnection/VLoSpKh/Retrieve",
            List = "SpringPrintingConnection/VLoSpKh/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VNhapKhoSpForm {
        KeyId: Serenity.IntegerEditor;
        MaKh: Serenity.IntegerEditor;
        TenKh: Serenity.StringEditor;
        NgayNhap: Serenity.DateEditor;
        NguoiNhap: Serenity.IntegerEditor;
        GhiChu: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        HangMau: Serenity.BooleanEditor;
        HangBu: Serenity.BooleanEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        Po: Serenity.StringEditor;
        Fepo: Serenity.StringEditor;
        BulNo: Serenity.IntegerEditor;
        TableNum: Serenity.StringEditor;
        Buy: Serenity.StringEditor;
        Style04: Serenity.StringEditor;
        Col: Serenity.StringEditor;
        Size: Serenity.StringEditor;
        Part: Serenity.StringEditor;
        Quantity: Serenity.IntegerEditor;
    }
    class VNhapKhoSpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VNhapKhoSpRow {
        Expr1?: number;
        KeyId?: number;
        MaKh?: number;
        TenKh?: string;
        NgayNhap?: string;
        NguoiNhap?: number;
        GhiChu?: string;
        MaBtp?: string;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
        HangMau?: boolean;
        HangBu?: boolean;
        CardId?: number;
        Code?: string;
        Po?: string;
        Fepo?: string;
        BulNo?: number;
        TableNum?: string;
        Buy?: string;
        Style04?: string;
        Col?: string;
        Size?: string;
        Part?: string;
        Quantity?: number;
    }
    namespace VNhapKhoSpRow {
        const idProperty = "Expr1";
        const nameProperty = "TenKh";
        const localTextPrefix = "SpringPrintingConnection.VNhapKhoSp";
        const enum Fields {
            Expr1 = "Expr1",
            KeyId = "KeyId",
            MaKh = "MaKh",
            TenKh = "TenKh",
            NgayNhap = "NgayNhap",
            NguoiNhap = "NguoiNhap",
            GhiChu = "GhiChu",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
            HangMau = "HangMau",
            HangBu = "HangBu",
            CardId = "CardId",
            Code = "Code",
            Po = "Po",
            Fepo = "Fepo",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Buy = "Buy",
            Style04 = "Style04",
            Col = "Col",
            Size = "Size",
            Part = "Part",
            Quantity = "Quantity",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VNhapKhoSpService {
        const baseUrl = "SpringPrintingConnection/VNhapKhoSp";
        function Create(request: Serenity.SaveRequest<VNhapKhoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VNhapKhoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VNhapKhoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VNhapKhoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VNhapKhoSp/Create",
            Update = "SpringPrintingConnection/VNhapKhoSp/Update",
            Delete = "SpringPrintingConnection/VNhapKhoSp/Delete",
            Retrieve = "SpringPrintingConnection/VNhapKhoSp/Retrieve",
            List = "SpringPrintingConnection/VNhapKhoSp/List",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
}
declare namespace Serene3.SpringPrintingConnection {
    interface VTrangThaiBoBtpForm {
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.IntegerEditor;
        TenBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        Ngay1: Serenity.DateEditor;
        NhanVien1: Serenity.IntegerEditor;
        Ngay2: Serenity.DateEditor;
        NhanVien2: Serenity.IntegerEditor;
        Ngay3: Serenity.DateEditor;
        NhanVien3: Serenity.IntegerEditor;
        Ngay4: Serenity.DateEditor;
        NhanVien4: Serenity.IntegerEditor;
        HangMau: Serenity.BooleanEditor;
        HangBu: Serenity.BooleanEditor;
        MaHd: Serenity.IntegerEditor;
    }
    class VTrangThaiBoBtpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    interface VTrangThaiBoBtpRow {
        KeyId1?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: number;
        TenBtp?: string;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
        Ngay1?: string;
        NhanVien1?: number;
        Ngay2?: string;
        NhanVien2?: number;
        Ngay3?: string;
        NhanVien3?: number;
        Ngay4?: string;
        NhanVien4?: number;
        HangMau?: boolean;
        HangBu?: boolean;
        MaHd?: number;
    }
    namespace VTrangThaiBoBtpRow {
        const idProperty = "KeyId1";
        const nameProperty = "Code";
        const localTextPrefix = "SpringPrintingConnection.VTrangThaiBoBtp";
        const enum Fields {
            KeyId1 = "KeyId1",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            TenBtp = "TenBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
            Ngay1 = "Ngay1",
            NhanVien1 = "NhanVien1",
            Ngay2 = "Ngay2",
            NhanVien2 = "NhanVien2",
            Ngay3 = "Ngay3",
            NhanVien3 = "NhanVien3",
            Ngay4 = "Ngay4",
            NhanVien4 = "NhanVien4",
            HangMau = "HangMau",
            HangBu = "HangBu",
            MaHd = "MaHd",
        }
    }
}
declare namespace Serene3.SpringPrintingConnection {
    namespace VTrangThaiBoBtpService {
        const baseUrl = "SpringPrintingConnection/VTrangThaiBoBtp";
        function Create(request: Serenity.SaveRequest<VTrangThaiBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VTrangThaiBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VTrangThaiBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VTrangThaiBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "SpringPrintingConnection/VTrangThaiBoBtp/Create",
            Update = "SpringPrintingConnection/VTrangThaiBoBtp/Update",
            Delete = "SpringPrintingConnection/VTrangThaiBoBtp/Delete",
            Retrieve = "SpringPrintingConnection/VTrangThaiBoBtp/Retrieve",
            List = "SpringPrintingConnection/VTrangThaiBoBtp/List",
        }
    }
}
declare namespace Serene3.LanguageList {
    function getValue(): string[][];
}
declare namespace Serene3.ScriptInitialization {
}
declare namespace Serene3.Administration {
    class LanguageDialog extends Serenity.EntityDialog<LanguageRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: LanguageForm;
    }
}
declare namespace Serene3.Administration {
    class LanguageGrid extends Serenity.EntityGrid<LanguageRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LanguageDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Administration {
    class RoleDialog extends Serenity.EntityDialog<RoleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RoleForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace Serene3.Administration {
    class RoleGrid extends Serenity.EntityGrid<RoleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RoleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Administration {
    class RolePermissionDialog extends Serenity.TemplatedDialog<RolePermissionDialogOptions> {
        private permissions;
        constructor(opt: RolePermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface RolePermissionDialogOptions {
        roleID?: number;
        title?: string;
    }
}
declare namespace Serene3.Administration {
    class TranslationGrid extends Serenity.EntityGrid<TranslationItem, any> {
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private hasChanges;
        private searchText;
        private sourceLanguage;
        private targetLanguage;
        private targetLanguageKey;
        constructor(container: JQuery);
        protected onClick(e: JQueryEventObject, row: number, cell: number): any;
        protected getColumns(): Slick.Column[];
        protected createToolbarExtensions(): void;
        protected saveChanges(language: string): PromiseLike<any>;
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
        protected createQuickSearchInput(): void;
        protected onViewFilter(item: TranslationItem): boolean;
        protected usePager(): boolean;
    }
}
declare namespace Serene3.Administration {
    class UserDialog extends Serenity.EntityDialog<UserRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UserForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace Serene3.Administration {
    class UserGrid extends Serenity.EntityGrid<UserRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDialog;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Administration {
    class PermissionCheckEditor extends Serenity.DataGrid<PermissionCheckItem, PermissionCheckEditorOptions> {
        protected getIdProperty(): string;
        private searchText;
        private byParentKey;
        constructor(container: JQuery, opt: PermissionCheckEditorOptions);
        private getItemGrantRevokeClass(item, grant);
        private roleOrImplicit(key);
        private getItemEffectiveClass(item);
        protected getColumns(): Slick.Column[];
        setItems(items: PermissionCheckItem[]): void;
        protected onViewSubmit(): boolean;
        protected onViewFilter(item: PermissionCheckItem): boolean;
        private matchContains(item);
        private getDescendants(item, excludeGroups);
        protected onClick(e: any, row: any, cell: any): void;
        private getParentKey(key);
        protected getButtons(): Serenity.ToolButton[];
        protected createToolbarExtensions(): void;
        private getSortedGroupAndPermissionKeys(titleByKey);
        value: UserPermissionRow[];
        private _rolePermissions;
        rolePermissions: string[];
        private _implicitPermissions;
        implicitPermissions: Q.Dictionary<string[]>;
    }
    interface PermissionCheckEditorOptions {
        showRevoke?: boolean;
    }
    interface PermissionCheckItem {
        ParentKey?: string;
        Key?: string;
        Title?: string;
        IsGroup?: boolean;
        GrantRevoke?: boolean;
    }
}
declare namespace Serene3.Administration {
    class UserPermissionDialog extends Serenity.TemplatedDialog<UserPermissionDialogOptions> {
        private permissions;
        constructor(opt: UserPermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserPermissionDialogOptions {
        userID?: number;
        username?: string;
    }
}
declare namespace Serene3.Administration {
    class RoleCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {
        private searchText;
        constructor(div: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): any[];
        protected getTreeItems(): Serenity.CheckTreeItem<any>[];
        protected onViewFilter(item: any): boolean;
    }
}
declare namespace Serene3.Administration {
    class UserRoleDialog extends Serenity.TemplatedDialog<UserRoleDialogOptions> {
        private permissions;
        constructor(opt: UserRoleDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserRoleDialogOptions {
        userID: number;
        username: string;
    }
}
declare namespace Serene3 {
    class BasicProgressDialog extends Serenity.TemplatedDialog<any> {
        constructor();
        cancelled: boolean;
        max: number;
        value: number;
        title: string;
        cancelTitle: string;
        getDialogOptions(): JQueryUI.DialogOptions;
        initDialog(): void;
        getTemplate(): string;
    }
}
declare namespace Serene3.Common {
    class BulkServiceAction {
        protected keys: string[];
        protected queue: string[];
        protected queueIndex: number;
        protected progressDialog: BasicProgressDialog;
        protected pendingRequests: number;
        protected completedRequests: number;
        protected errorByKey: Q.Dictionary<Serenity.ServiceError>;
        private successCount;
        private errorCount;
        done: () => void;
        protected createProgressDialog(): void;
        protected getConfirmationFormat(): string;
        protected getConfirmationMessage(targetCount: any): string;
        protected confirm(targetCount: any, action: any): void;
        protected getNothingToProcessMessage(): string;
        protected nothingToProcess(): void;
        protected getParallelRequests(): number;
        protected getBatchSize(): number;
        protected startParallelExecution(): void;
        protected serviceCallCleanup(): void;
        protected executeForBatch(batch: string[]): void;
        protected executeNextBatch(): void;
        protected getAllHadErrorsFormat(): string;
        protected showAllHadErrors(): void;
        protected getSomeHadErrorsFormat(): string;
        protected showSomeHadErrors(): void;
        protected getAllSuccessFormat(): string;
        protected showAllSuccess(): void;
        protected showResults(): void;
        execute(keys: string[]): void;
        get_successCount(): any;
        set_successCount(value: number): void;
        get_errorCount(): any;
        set_errorCount(value: number): void;
    }
}
declare namespace Serene3.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare namespace Serene3.Common {
    class EnumSelectFormatter implements Slick.Formatter {
        constructor();
        format(ctx: Slick.FormatterContext): string;
        enumKey: string;
        allowClear: boolean;
        emptyItemText: string;
    }
}
declare namespace Serene3.Common {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare namespace Serene3.Common {
    class GridEditorBase<TEntity> extends Serenity.EntityGrid<TEntity, any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getIdProperty(): string;
        protected nextId: number;
        constructor(container: JQuery);
        protected id(entity: TEntity): any;
        protected getNextId(): string;
        protected setNewId(entity: TEntity): void;
        protected save(opt: Serenity.ServiceOptions<any>, callback: (r: Serenity.ServiceResponse) => void): void;
        protected deleteEntity(id: number): boolean;
        protected validateEntity(row: TEntity, id: number): boolean;
        protected setEntities(items: TEntity[]): void;
        protected getNewEntity(): TEntity;
        protected getButtons(): Serenity.ToolButton[];
        protected editItem(entityOrId: any): void;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        value: TEntity[];
        protected getGridCanLoad(): boolean;
        protected usePager(): boolean;
        protected getInitialTitle(): any;
        protected createQuickSearchInput(): void;
    }
}
declare namespace Serene3.Common {
    class GridEditorDialog<TEntity> extends Serenity.EntityDialog<TEntity, any> {
        protected getIdProperty(): string;
        onSave: (options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void) => void;
        onDelete: (options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void) => void;
        destroy(): void;
        protected updateInterface(): void;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
    }
}
declare namespace Serene3 {
    /**
     * This is an editor widget but it only displays a text, not edits it.
     *
     */
    class StaticTextBlock extends Serenity.Widget<StaticTextBlockOptions> implements Serenity.ISetEditValue {
        private value;
        constructor(container: JQuery, options: StaticTextBlockOptions);
        private updateElementContent();
        /**
         * By implementing ISetEditValue interface, we allow this editor to display its field value.
         * But only do this when our text content is not explicitly set in options
         */
        setEditValue(source: any, property: Serenity.PropertyItem): void;
    }
    interface StaticTextBlockOptions {
        text: string;
        isHtml: boolean;
        isLocalText: boolean;
        hideLabel: boolean;
    }
}
declare namespace Serene3.Common {
    class LanguageSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentLanguage: string);
    }
}
declare namespace Serene3.Common {
    class SidebarSearch extends Serenity.Widget<any> {
        private menuUL;
        constructor(input: JQuery, menuUL: JQuery);
        protected updateMatchFlags(text: string): void;
    }
}
declare namespace Serene3.Common {
    class ThemeSelection extends Serenity.Widget<any> {
        constructor(select: JQuery);
        protected getCurrentTheme(): string;
    }
}
declare var jsPDF: any;
declare namespace Serene3.Common {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
        printDateTimeHeader?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare var jsPDF: any;
declare namespace Serene3.Common {
    class ReportDialog extends Serenity.TemplatedDialog<ReportDialogOptions> {
        private report;
        private propertyGrid;
        constructor(options: ReportDialogOptions);
        protected getDialogButtons(): any;
        protected createPropertyGrid(): void;
        protected loadReport(reportKey: string): void;
        protected updateInterface(): void;
        executeReport(target: string, ext: string, download: boolean): void;
        getToolbarButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
    interface ReportDialogOptions {
        reportKey: string;
    }
}
declare namespace Serene3.Common {
    interface ReportExecuteOptions {
        reportKey: string;
        download?: boolean;
        extension?: 'pdf' | 'htm' | 'html' | 'xlsx' | 'docx';
        getParams?: () => any;
        params?: {
            [key: string]: any;
        };
        target?: string;
    }
    interface ReportButtonOptions extends ReportExecuteOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
        function execute(options: ReportExecuteOptions): void;
    }
}
declare var jsPDF: any;
declare namespace Serene3.Common {
    class ReportPage extends Serenity.Widget<any> {
        private reportKey;
        private propertyItems;
        private propertyGrid;
        constructor(element: JQuery);
        protected updateMatchFlags(text: string): void;
        protected categoryClick(e: any): void;
        protected reportLinkClick(e: any): void;
    }
}
declare namespace Serene3.Common {
    class UserPreferenceStorage implements Serenity.SettingStorage {
        getItem(key: string): string;
        setItem(key: string, data: string): void;
    }
}
declare namespace Serene3.Northwind {
    class CategoryDialog extends Serenity.EntityDialog<CategoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CategoryForm;
    }
}
declare namespace Serene3.Northwind {
    class CategoryGrid extends Serenity.EntityGrid<CategoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Northwind {
    class CustomerDialog extends Serenity.EntityDialog<CustomerRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CustomerForm;
        private ordersGrid;
        private loadedState;
        constructor();
        getSaveState(): string;
        loadResponse(data: any): void;
        loadEntity(entity: CustomerRow): void;
        onSaveSuccess(response: any): void;
    }
}
declare namespace Serene3.Northwind {
    class CustomerEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, CustomerRow> {
        constructor(hidden: JQuery);
        protected getLookupKey(): string;
        protected getItemText(item: any, lookup: any): string;
    }
}
declare namespace Serene3.Northwind {
    class CustomerGrid extends Serenity.EntityGrid<CustomerRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.Northwind {
    class OrderDialog extends Serenity.EntityDialog<OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: OrderForm;
        constructor();
        getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace Serene3.Northwind {
    class CustomerOrderDialog extends OrderDialog {
        constructor();
        updateInterface(): void;
    }
}
declare namespace Serene3.Northwind {
    class OrderGrid extends Serenity.EntityGrid<OrderRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected shippingStateFilter: Serenity.EnumEditor;
        constructor(container: JQuery);
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected createQuickFilters(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        set_shippingState(value: number): void;
        protected addButtonClick(): void;
    }
}
declare namespace Serene3.Northwind {
    class CustomerOrdersGrid extends OrderGrid {
        protected getDialogType(): typeof CustomerOrderDialog;
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected initEntityDialog(itemType: any, dialog: any): void;
        protected addButtonClick(): void;
        protected getInitialTitle(): any;
        protected getGridCanLoad(): boolean;
        private _customerID;
        customerID: string;
    }
}
declare namespace Serene3.Northwind {
    class EmployeeListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Serene3.Northwind {
    class EmployeeFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
        genderProperty: string;
        initializeColumn(column: Slick.Column): void;
    }
}
declare namespace Serene3.Northwind {
    class NoteDialog extends Serenity.TemplatedDialog<any> {
        private textEditor;
        constructor();
        protected getTemplate(): string;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        text: string;
        okClick: () => void;
    }
}
declare namespace Serene3.Northwind {
    class NotesEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        private isDirty;
        private items;
        constructor(div: JQuery);
        protected getTemplate(): string;
        protected updateContent(): void;
        protected addClick(): void;
        protected editClick(e: any): void;
        deleteClick(e: any): void;
        value: NoteRow[];
        getEditValue(prop: Serenity.PropertyItem, target: any): void;
        setEditValue(source: any, prop: Serenity.PropertyItem): void;
        get_isDirty(): boolean;
        set_isDirty(value: any): void;
        onChange: () => void;
    }
}
declare namespace Serene3.Northwind {
    class FreightFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Serene3.Northwind {
    class OrderDetailDialog extends Common.GridEditorDialog<OrderDetailRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: OrderDetailForm;
        constructor();
    }
}
declare namespace Serene3.Northwind {
    class OrderDetailsEditor extends Common.GridEditorBase<OrderDetailRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof OrderDetailDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.Northwind {
    class ProductDialog extends Serenity.EntityDialog<ProductRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ProductForm;
    }
}
declare namespace Serene3.Northwind {
    class ProductGrid extends Serenity.EntityGrid<ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
        protected onViewProcessData(response: any): Serenity.ListResponse<ProductRow>;
        /**
         * It would be nice if we could use autonumeric, Serenity editors etc. here, to control input validation,
         * but it's not supported by SlickGrid as we are only allowed to return a string, and should attach
         * no event handlers to rendered cell contents
         */
        private numericInputFormatter(ctx);
        private stringInputFormatter(ctx);
        /**
         * Sorry but you cannot use LookupEditor, e.g. Select2 here, only possible is a SELECT element
         */
        private selectFormatter(ctx, idField, lookup);
        private getEffectiveValue(item, field);
        protected getColumns(): Slick.Column[];
        private inputsChange(e);
        private setSaveButtonState();
        private saveClick();
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.Northwind {
    class RegionDialog extends Serenity.EntityDialog<RegionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RegionForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Serene3.Northwind {
    class RegionGrid extends Serenity.EntityGrid<RegionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Northwind {
    class PhoneEditor extends Serenity.StringEditor {
        constructor(input: JQuery);
        protected formatValue(): void;
        protected getFormattedValue(): string;
        multiple: boolean;
        get_value(): string;
        set_value(value: string): void;
        static validate(phone: string, isMultiple: boolean): string;
        static isValidPhone(phone: string): boolean;
        static formatPhone(phone: any): any;
        static formatMulti(phone: string, format: (s: string) => string): string;
        static isValidMulti(phone: string, check: (s: string) => boolean): boolean;
    }
}
declare namespace Serene3.Northwind {
    class ShipperDialog extends Serenity.EntityDialog<ShipperRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ShipperForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Serene3.Northwind {
    class ShipperFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace Serene3.Northwind {
    class ShipperGrid extends Serenity.EntityGrid<ShipperRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Northwind {
    class SupplierDialog extends Serenity.EntityDialog<SupplierRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: SupplierForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Serene3.Northwind {
    class SupplierGrid extends Serenity.EntityGrid<SupplierRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Northwind {
    class TerritoryDialog extends Serenity.EntityDialog<TerritoryRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TerritoryForm;
        protected getLanguages(): string[][];
    }
}
declare namespace Serene3.Northwind {
    class TerritoryGrid extends Serenity.EntityGrid<TerritoryRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VTrangThaiBoBtpGrid extends Serenity.EntityGrid<VTrangThaiBoBtpRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VTrangThaiBoBtpDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class GroupingInGrid extends Serene3.SpringPrintingConnection.VTrangThaiBoBtpGrid {
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBanThanhPhamDialog extends Serenity.EntityDialog<TblBanThanhPhamRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblBanThanhPhamForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBanThanhPhamGrid extends Serenity.EntityGrid<TblBanThanhPhamRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblBanThanhPhamDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBoBtpDialog extends Serenity.EntityDialog<TblBoBtpRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblBoBtpForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBoBtpEditDialog extends Common.GridEditorDialog<TblBoBtpRow> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblBoBtpForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBoBtpEditor extends Common.GridEditorBase<TblBoBtpRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblBoBtpEditDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBoBtpGrid extends Serenity.EntityGrid<TblBoBtpRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblBoBtpDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        private month;
        private sMaLo;
        private sMaLo111;
        protected createToolbarExtensions(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBo_BTPDialog extends Common.GridEditorDialog<TblBo_BTPRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: TblBo_BTPForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBo_BTPEditor extends Common.GridEditorBase<TblBo_BTPRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblBo_BTPDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblBo_BTPGrid extends Serenity.EntityGrid<TblBo_BTPRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblBo_BTPDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblFeCardInfoDialog extends Serenity.EntityDialog<TblFeCardInfoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblFeCardInfoForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblFeCardInfoGrid extends Serenity.EntityGrid<TblFeCardInfoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblFeCardInfoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblFeStockOutInfoDialog extends Serenity.EntityDialog<TblFeStockOutInfoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblFeStockOutInfoForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblFeStockOutInfoGrid extends Serenity.EntityGrid<TblFeStockOutInfoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblFeStockOutInfoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongDialog extends Serenity.EntityDialog<TblHopDongRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblHopDongForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongGrid extends Serenity.EntityGrid<TblHopDongRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDongDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongChiTietDialog extends Serenity.EntityDialog<TblHopDongChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblHopDongChiTietForm;
        constructor();
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongChiTietEditor extends Common.GridEditorBase<TblHopDongChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDongChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongChiTietGrid extends Serenity.EntityGrid<TblHopDongChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDongChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongDieuChinhDialog extends Common.GridEditorDialog<TblHopDongDieuChinhRow> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblHopDongDieuChinhForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongDieuChinhGrid extends Serenity.EntityGrid<TblHopDongDieuChinhRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDongDieuChinhDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongDieuChinhsEditor extends Common.GridEditorBase<TblHopDongDieuChinhRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDongDieuChinhDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDongChiTiet_Editor extends Common.GridEditorBase<TblHopDong_ChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDong_ChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDong_ChiTietDialog extends Common.GridEditorDialog<TblHopDong_ChiTietRow> {
        protected getFormKey(): string;
        protected getService(): string;
        protected form: TblHopDong_ChiTietForm;
        constructor();
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDong_ChiTietGrid extends Serenity.EntityGrid<TblHopDong_ChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDong_ChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDong_DieuChinhDialog extends Common.GridEditorDialog<TblHopDong_DieuChinhRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: TblHopDong_DieuChinhForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDong_DieuChinhEditor extends Common.GridEditorBase<TblHopDong_DieuChinhRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDong_DieuChinhDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblHopDong_DieuChinhGrid extends Serenity.EntityGrid<TblHopDong_DieuChinhRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblHopDong_DieuChinhDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblKhachHangDialog extends Serenity.EntityDialog<TblKhachHangRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblKhachHangForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblKhachHangGrid extends Serenity.EntityGrid<TblKhachHangRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblKhachHangDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenDialog extends Serenity.EntityDialog<TblLenChuyenRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblLenChuyenForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenGrid extends Serenity.EntityGrid<TblLenChuyenRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLenChuyenDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenInChiTietDialog extends Serenity.EntityDialog<TblLenChuyenInChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblLenChuyenInChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenInChiTietGrid extends Serenity.EntityGrid<TblLenChuyenInChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLenChuyenInChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        private month;
        private sMaLo;
        private sMaLo111;
        protected createToolbarExtensions(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenInChiTietsEditor extends Common.GridEditorBase<TblLenChuyenInChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLenChuyenInChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenIn_ChiTietDialog extends Common.GridEditorDialog<TblLenChuyenIn_ChiTietRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: TblLenChuyenIn_ChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenIn_ChiTietEditor extends Common.GridEditorBase<TblLenChuyenIn_ChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLenChuyenIn_ChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLenChuyenIn_ChiTietGrid extends Serenity.EntityGrid<TblLenChuyenIn_ChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLenChuyenIn_ChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLoSpDialog extends Serenity.EntityDialog<TblLoSpRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblLoSpForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblLoSpGrid extends Serenity.EntityGrid<TblLoSpRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblLoSpDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblNguoiDungDialog extends Serenity.EntityDialog<TblNguoiDungRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblNguoiDungForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblNguoiDungGrid extends Serenity.EntityGrid<TblNguoiDungRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblNguoiDungDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefMauDialog extends Serenity.EntityDialog<TblRefMauRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefMauForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefMauGrid extends Serenity.EntityGrid<TblRefMauRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefMauDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefNguoiDaiDienDialog extends Serenity.EntityDialog<TblRefNguoiDaiDienRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefNguoiDaiDienForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefNguoiDaiDienGrid extends Serenity.EntityGrid<TblRefNguoiDaiDienRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefNguoiDaiDienDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefSexDialog extends Serenity.EntityDialog<TblRefSexRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefSexForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefSexGrid extends Serenity.EntityGrid<TblRefSexRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefSexDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefSizeDialog extends Serenity.EntityDialog<TblRefSizeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefSizeForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefSizeGrid extends Serenity.EntityGrid<TblRefSizeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefSizeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefStyleDialog extends Serenity.EntityDialog<TblRefStyleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefStyleForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefStyleGrid extends Serenity.EntityGrid<TblRefStyleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefStyleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefTypeDialog extends Serenity.EntityDialog<TblRefTypeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblRefTypeForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblRefTypeGrid extends Serenity.EntityGrid<TblRefTypeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblRefTypeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKhoChiTietDialog extends Serenity.EntityDialog<TblXuatKhoChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblXuatKhoChiTietForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKhoChiTietGrid extends Serenity.EntityGrid<TblXuatKhoChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuatKhoChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        private month;
        private sMaLo;
        private sMaLo111;
        protected createToolbarExtensions(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKhoChiTietsEditor extends Common.GridEditorBase<TblXuatKhoChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuatKhoChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKhoKhDialog extends Serenity.EntityDialog<TblXuatKhoKhRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TblXuatKhoKhForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKhoKhGrid extends Serenity.EntityGrid<TblXuatKhoKhRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuatKhoKhDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKho_ChiTietDialog extends Common.GridEditorDialog<TblXuatKho_ChiTietRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: TblXuatKho_ChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKho_ChiTietEditor extends Common.GridEditorBase<TblXuatKho_ChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuatKho_ChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuatKho_ChiTietGrid extends Serenity.EntityGrid<TblXuatKho_ChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuatKho_ChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenDialog extends Serenity.EntityDialog<TblXuongChuyenRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblXuongChuyenForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenGrid extends Serenity.EntityGrid<TblXuongChuyenRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuongChuyenDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenInChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenInChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: TblXuongChuyenInChiTietForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenInChiTietGrid extends Serenity.EntityGrid<TblXuongChuyenInChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuongChuyenInChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
        private month;
        private sMaLo;
        private sMaLo111;
        protected createToolbarExtensions(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenInChiTietsEditor extends Common.GridEditorBase<TblXuongChuyenInChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuongChuyenInChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenIn_ChiTietDialog extends Common.GridEditorDialog<TblXuongChuyenIn_ChiTietRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: TblXuongChuyenIn_ChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenIn_ChiTietEditor extends Common.GridEditorBase<TblXuongChuyenIn_ChiTietRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuongChuyenIn_ChiTietDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        validateEntity(row: any, id: any): boolean;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class TblXuongChuyenIn_ChiTietGrid extends Serenity.EntityGrid<TblXuongChuyenIn_ChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TblXuongChuyenIn_ChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtpDialog extends Serenity.EntityDialog<VChiTietBtpRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VChiTietBtpForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtpGrid extends Serenity.EntityGrid<VChiTietBtpRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VChiTietBtpDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_SizeDialog extends Serenity.EntityDialog<VChiTietBtp_SizeRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VChiTietBtp_SizeForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_SizeGrid extends Serenity.EntityGrid<VChiTietBtp_SizeRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VChiTietBtp_SizeDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_StyleDialog extends Serenity.EntityDialog<VChiTietBtp_StyleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VChiTietBtp_StyleForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_StyleGrid extends Serenity.EntityGrid<VChiTietBtp_StyleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VChiTietBtp_StyleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_Style_ColorDialog extends Serenity.EntityDialog<VChiTietBtp_Style_ColorRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VChiTietBtp_Style_ColorForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VChiTietBtp_Style_ColorGrid extends Serenity.EntityGrid<VChiTietBtp_Style_ColorRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VChiTietBtp_Style_ColorDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VHopDongChiTietDialog extends Serenity.EntityDialog<VHopDongChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VHopDongChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VHopDongChiTietGrid extends Serenity.EntityGrid<VHopDongChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VHopDongChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VHopDongTrangThaiDialog extends Serenity.EntityDialog<VHopDongTrangThaiRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VHopDongTrangThaiForm;
        protected updateInterface(): void;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VHopDongTrangThaiGrid extends Serenity.EntityGrid<VHopDongTrangThaiRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VHopDongTrangThaiDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected createSlickGrid(): Slick.Grid;
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VLenChuyenChiTietDialog extends Serenity.EntityDialog<VLenChuyenChiTietRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VLenChuyenChiTietForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VLenChuyenChiTietGrid extends Serenity.EntityGrid<VLenChuyenChiTietRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VLenChuyenChiTietDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VLoSpKhDialog extends Serenity.EntityDialog<VLoSpKhRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VLoSpKhForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VLoSpKhGrid extends Serenity.EntityGrid<VLoSpKhRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VLoSpKhDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VNhapKhoSpDialog extends Serenity.EntityDialog<VNhapKhoSpRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VNhapKhoSpForm;
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VNhapKhoSpGrid extends Serenity.EntityGrid<VNhapKhoSpRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VNhapKhoSpDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.SpringPrintingConnection {
    class VTrangThaiBoBtpDialog extends Serenity.EntityDialog<VTrangThaiBoBtpRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VTrangThaiBoBtpForm;
    }
}
declare namespace Serene3.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
}
declare var Morris: any;
declare namespace Serene3.BasicSamples {
    class ChartInDialog extends Serenity.TemplatedDialog<any> {
        private areaChart;
        static initializePage(): void;
        protected onDialogOpen(): void;
        protected arrange(): void;
        protected getTemplate(): string;
        protected getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace Serene3.BasicSamples {
    class CloneableEntityDialog extends Northwind.ProductDialog {
        protected updateInterface(): void;
        /**
         * Overriding this method is optional to customize cloned entity
         */
        protected getCloningEntity(): Northwind.ProductRow;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    class CloneableEntityGrid extends Northwind.ProductGrid {
        protected getDialogType(): typeof CloneableEntityDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class DefaultValuesInNewGrid extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick(): void;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.BasicSamples.DialogBoxes {
    function initializePage(): void;
}
declare namespace Serene3.BasicSamples {
    /**
     * A version of order dialog converted to a panel by adding Serenity.Decorators.panel decorator.
     */
    class EntityDialogAsPanel extends Northwind.OrderDialog {
        constructor();
        protected updateInterface(): void;
        protected onSaveSuccess(response: any): void;
    }
}
declare namespace Serene3.BasicSamples {
    class GetInsertedRecordIdDialog extends Northwind.CategoryDialog {
        /**
         * This method is called after the save request to service
         * is completed succesfully. This can be an insert or update.
         *
         * @param response Response that is returned from server
         */
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of CategoryGrid to override dialog type to GetInsertedRecordIdDialog
     */
    class GetInsertedRecordIdGrid extends Northwind.CategoryGrid {
        protected getDialogType(): typeof GetInsertedRecordIdDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
     */
    class OtherFormInTabDialog extends Northwind.OrderDialog {
        private customerPropertyGrid;
        private customerForm;
        private customerValidator;
        constructor();
        getCustomerID(): number;
        loadEntity(entity: Northwind.OrderRow): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabDialog
     */
    class OtherFormInTabGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof OtherFormInTabDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our custom order dialog subclass that will have a tab to display and edit selected customer details.
     * With single toolbar for all forms
     */
    class OtherFormOneBarDialog extends Northwind.OrderDialog {
        private customerPropertyGrid;
        private customerForm;
        private customerValidator;
        private selfChange;
        constructor();
        getCustomerID(): number;
        loadEntity(entity: Northwind.OrderRow): void;
        protected saveCustomer(callback: (response: Serenity.SaveResponse) => void, onSuccess?: (response: Serenity.SaveResponse) => void): boolean;
        protected saveOrder(callback: (response: Serenity.SaveResponse) => void): void;
        protected saveAll(callback: (response: Serenity.SaveResponse) => void): void;
        protected save(callback: (response: Serenity.SaveResponse) => void): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabOneBarDialog
     */
    class OtherFormInTabOneBarGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof OtherFormOneBarDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class PopulateLinkedDataDialog extends Serenity.EntityDialog<Northwind.OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: PopulateLinkedDataForm;
        constructor();
        private setCustomerDetails(details);
        /**
         * This dialog will have CSS class "s-PopulateLinkedDataDialog"
         * We are changing it here to "s-OrderDialog", to make it use default OrderDialog styles
         * This has no effect other than looks on populate linked data demonstration
         */
        protected getCssClass(): string;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * A subclass of OrderGrid that launches PopulateLinkedDataDialog
     */
    class PopulateLinkedDataGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof PopulateLinkedDataDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class ReadOnlyDialog extends Northwind.SupplierDialog {
        /**
         * This is the method that gets list of tool
         * buttons to be created in a dialog.
         *
         * Here we'll remove save and close button, and
         * apply changes buttons.
         */
        protected getToolbarButtons(): Serenity.ToolButton[];
        /**
         * This method is a good place to update states of
         * interface elements. It is called after dialog
         * is initialized and an entity is loaded into dialog.
         * This is also called in new item mode.
         */
        protected updateInterface(): void;
        /**
         * This method is called when dialog title needs to be updated.
         * Base class returns something like 'Edit xyz' for edit mode,
         * and 'New xyz' for new record mode.
         *
         * But our dialog is readonly, so we should change it to 'View xyz'
         */
        protected getEntityTitle(): string;
        /**
         * This method is actually the one that calls getEntityTitle()
         * and updates the dialog title. We could do it here too...
         */
        protected updateTitle(): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * A readonly grid that launches ReadOnlyDialog
     */
    class ReadOnlyGrid extends Northwind.SupplierGrid {
        protected getDialogType(): typeof ReadOnlyDialog;
        constructor(container: JQuery);
        /**
         * Removing add button from grid using its css class
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.BasicSamples {
    class SerialAutoNumberDialog extends Northwind.CustomerDialog {
        constructor();
        protected afterLoadEntity(): void;
        private getNextNumber();
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of CustomerGrid to override dialog type to SerialAutoNumberDialog
     */
    class SerialAutoNumberGrid extends Northwind.CustomerGrid {
        protected getDialogType(): typeof SerialAutoNumberDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class ChangingLookupTextDialog extends Common.GridEditorDialog<Northwind.OrderDetailRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: ChangingLookupTextForm;
        constructor();
        protected updateInterface(): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our custom product editor type
     */
    class ChangingLookupTextEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, Northwind.ProductRow> {
        constructor(container: JQuery, options: Serenity.LookupEditorOptions);
        protected getLookupKey(): string;
        protected getItemText(item: Northwind.ProductRow, lookup: Q.Lookup<Northwind.ProductRow>): string;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our subclass of order detail dialog with a CategoryID property
     * that will be used to set CascadeValue of product editor
     */
    class FilteredLookupOrderDetailDialog extends Northwind.OrderDetailDialog {
        constructor();
        /**
         * This method is called just before an entity is loaded to dialog
         * This is also called for new record mode with an empty entity
         */
        protected beforeLoadEntity(entity: any): void;
        categoryID: number;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our subclass of Order Details editor with a CategoryID property
     */
    class FilteredLookupDetailEditor extends Northwind.OrderDetailsEditor {
        protected getDialogType(): typeof FilteredLookupOrderDetailDialog;
        constructor(container: JQuery);
        categoryID: number;
        /**
         * This method is called to initialize an edit dialog created by
         * grid editor when Add button or an edit link is clicked
         * We have an opportunity here to pass CategoryID to edit dialog
         */
        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>): void;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Basic order dialog with a category selection
     */
    class FilteredLookupInDetailDialog extends Serenity.EntityDialog<Northwind.OrderRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        private form;
        constructor();
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of OrderGrid to override dialog type to FilteredLookupInDetailDialog
     */
    class FilteredLookupInDetailGrid extends Northwind.OrderGrid {
        protected getDialogType(): typeof FilteredLookupInDetailDialog;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * This is our custom product dialog that uses a different product form
     * (LookupFilterByMultipleForm) with our special category editor.
     */
    class LookupFilterByMultipleDialog extends Northwind.ProductDialog {
        protected getFormKey(): string;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    class LookupFilterByMultipleGrid extends Northwind.ProductGrid {
        protected getDialogType(): typeof LookupFilterByMultipleDialog;
        constructor(container: JQuery);
        /**
         * This method is called just before List request is sent to service.
         * You have an opportunity here to cancel request or modify it.
         * Here we'll add a custom criteria to list request.
         */
        protected onViewSubmit(): boolean;
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * This is our category editor that will show only categories of Produce and
     * Seafood. We are subclassing LookupEditorBase which also LookupEditor
     * derives from.
     *
     * After compiling and transforming templates, this editor type will be
     * available in server side to use in our LookupFilterByMultipleForm,
     * which is a version of ProductForm that uses our custom editor.
     */
    class ProduceSeafoodCategoryEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, Northwind.CategoryRow> {
        constructor(container: JQuery, opt: Serenity.LookupEditorOptions);
        /**
         * Normally LookupEditor requires a lookup key to determine which set of
         * lookup data to show in editor. As our editor will only show category
         * data, we lock it to category lookup key.
         */
        protected getLookupKey(): string;
        /**
         * Here we are filtering by category name but you could filter by any field.
         * Just make sure the fields you filter on has [LookupInclude] attribute on them,
         * otherwise their value will be null in client side as they are not sent back
         * from server in lookup script.
         */
        protected getItems(lookup: Q.Lookup<Northwind.CategoryRow>): Northwind.CategoryRow[];
    }
}
declare namespace Serene3.BasicSamples {
    class HardcodedValuesDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey(): string;
        protected form: HardcodedValuesForm;
        constructor();
    }
}
declare namespace Serene3.BasicSamples {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class HardcodedValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class StaticTextBlockDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey(): string;
        protected form: StaticTextBlockForm;
        constructor();
        /**
         * Here we override loadInitialEntity method to set value for "DisplayFieldValue" field.
         * If this was an EntityDialog, your field value would be originating from server side entity.
         */
        protected loadInitialEntity(): void;
        protected getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace Serene3.BasicSamples {
    class OrderBulkAction extends Common.BulkServiceAction {
        /**
         * This controls how many service requests will be used in parallel.
         * Determine this number based on how many requests your server
         * might be able to handle, and amount of wait on external resources.
         */
        protected getParallelRequests(): number;
        /**
         * These number of records IDs will be sent to your service in one
         * service call. If your service is designed to handle one record only,
         * set it to 1. But note that, if you have 5000 records, this will
         * result in 5000 service calls / requests.
         */
        protected getBatchSize(): number;
        /**
         * This is where you should call your service.
         * Batch parameter contains the selected order IDs
         * that should be processed in this service call.
         */
        protected executeForBatch(batch: any): void;
    }
}
declare namespace Serene3.BasicSamples {
    class CancellableBulkActionGrid extends Northwind.OrderGrid {
        private rowSelection;
        constructor(container: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
        protected getColumns(): Slick.Column[];
        protected getViewOptions(): Slick.RemoteViewOptions;
    }
}
declare namespace Serene3.BasicSamples {
    class ConditionalFormattingGrid extends Serenity.EntityGrid<Northwind.ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        /**
         * We override getColumns() to be able to add a custom CSS class to UnitPrice
         * We could also add this class in ProductColumns.cs but didn't want to modify
         * it solely for this sample.
         */
        protected getColumns(): Slick.Column[];
        /**
         * This method is called for all rows
         * @param item Data item for current row
         * @param index Index of the row in grid
         */
        protected getItemCssClass(item: Northwind.ProductRow, index: number): string;
    }
}
declare namespace Serene3.BasicSamples {
    class CustomLinksInGrid extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * We override getColumns() to change format functions for some columns.
         * You could also write them as formatter classes, and use them at server side
         */
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        /**
         * This method is called for columns with [EditLink] attribute,
         * but only for edit links of this grid's own item type.
         * It is also called by Add Product button with a NULL entityOrId
         * parameter so we should check that entityOrId is a string
         * to be sure it is originating from a link.
         *
         * As we changed format for other columns, this will only be called
         * for links in remaining OrderID column
         */
        protected editItem(entityOrId: any): void;
    }
}
declare namespace Serene3.BasicSamples {
    class DragDropSampleDialog extends Serenity.EntityDialog<DragDropSampleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: DragDropSampleForm;
    }
}
declare namespace Serene3.BasicSamples {
    class DragDropSampleGrid extends Serenity.EntityGrid<DragDropSampleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DragDropSampleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private dragging;
        constructor(container: JQuery);
        /**
         * This method will determine if item can be moved under a given target
         * An item can't be moved under itself, under one of its children
         */
        private canMoveUnder(item, target);
        /**
         * Gets children list of an item
         */
        private getChildren(item);
        /**
         * Gets all parents of an item
         */
        private getParents(item);
        protected getButtons(): any[];
        protected usePager(): boolean;
    }
}
declare namespace Serene3 {
    class SelectableEntityGrid<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        protected getSlickOptions(): Slick.GridOptions;
        protected createSlickGrid(): Slick.Grid;
    }
}
declare namespace Serene3.BasicSamples {
    class RowSelectionGrid extends SelectableEntityGrid<Northwind.SupplierRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.BasicSamples {
    class GridFilteredByCriteria extends Northwind.ProductGrid {
        constructor(container: JQuery);
        protected onViewSubmit(): boolean;
    }
}
declare namespace Serene3.BasicSamples {
    class GroupingAndSummariesInGrid extends Northwind.ProductGrid {
        constructor(container: JQuery);
        protected createSlickGrid(): Slick.Grid;
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): {
            title: string;
            cssClass: string;
            onClick: () => void;
        }[];
    }
}
declare namespace Serene3.BasicSamples {
    class InitialValuesForQuickFilters extends Northwind.OrderGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of quick filters to be created for this grid.
         * By default, it returns quick filter objects corresponding to properties that
         * have a [QuickFilter] attribute at server side OrderColumns.cs
         */
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        /**
         * This method is another possible place to modify quick filter widgets.
         * It is where the quick filter widgets are actually created.
         *
         * By default, it calls getQuickFilters() then renders UI for these
         * quick filters.
         *
         * We could use getQuickFilters() method for ShipVia too,
         * but this is for demonstration purposes
         */
        protected createQuickFilters(): void;
    }
}
declare namespace Serene3.BasicSamples {
    class InlineActionGrid extends Northwind.CustomerGrid {
        constructor(container: JQuery);
        protected getColumns(): Slick.Column[];
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
    }
}
declare namespace Serene3.BasicSamples {
    class InlineImageFormatter implements Slick.Formatter, Serenity.IInitializeColumn {
        format(ctx: Slick.FormatterContext): string;
        initializeColumn(column: Slick.Column): void;
        fileProperty: string;
        thumb: boolean;
    }
}
declare namespace Serene3.BasicSamples {
    class InlineImageInGrid extends Serenity.EntityGrid<Northwind.ProductRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): any;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
    }
}
declare namespace Serene3.BasicSamples {
    class ProductExcelImportDialog extends Serenity.PropertyDialog<any, any> {
        private form;
        constructor();
        protected getDialogTitle(): string;
        protected getDialogButtons(): Serenity.DialogButton[];
    }
}
declare namespace Serene3.BasicSamples {
    class ProductExcelImportGrid extends Northwind.ProductGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.BasicSamples {
    class QuickFilterCustomization extends Serenity.EntityGrid<Northwind.OrderRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof Northwind.OrderDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        /**
         * This method is called to get list of quick filters to be created for this grid.
         * By default, it returns quick filter objects corresponding to properties that
         * have a [QuickFilter] attribute at server side OrderColumns.cs
         */
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.BasicSamples {
    class RemovingAddButton extends Northwind.SupplierGrid {
        constructor(container: JQuery);
        /**
         * This method is called to get list of buttons to be created.
         */
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace Serene3.BasicSamples {
    class CustomerGrossSalesGrid extends Serenity.EntityGrid<Northwind.CustomerGrossSalesRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getNameProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private nextId;
        constructor(container: JQuery);
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<Northwind.SalesByCategoryRow>): Serenity.ListResponse<Northwind.SalesByCategoryRow>;
        protected getButtons(): any[];
        protected createSlickGrid(): Slick.Grid;
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
    }
}
declare namespace Serene3.BasicSamples {
    class TreeGrid extends Northwind.OrderGrid {
        private treeMixin;
        constructor(container: JQuery);
        protected usePager(): boolean;
    }
}
declare namespace Serene3.BasicSamples {
    class ViewWithoutIDGrid extends Serenity.EntityGrid<Northwind.SalesByCategoryRow, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getNameProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private nextId;
        constructor(container: JQuery);
        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<Northwind.SalesByCategoryRow>): Serenity.ListResponse<Northwind.SalesByCategoryRow>;
        protected getButtons(): any[];
    }
}
declare namespace Serene3.BasicSamples {
    class VSGalleryQAGrid extends Serenity.EntityGrid<BasicSamples.VSGalleryQAThread, any> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): any[];
        protected getSlickOptions(): Slick.GridOptions;
        protected getColumns(): Slick.Column[];
        protected getInitialTitle(): any;
    }
}
declare namespace Serene3.BasicSamples {
    class WrappedHeadersGrid extends Northwind.OrderGrid {
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Membership {
    class ForgotPasswordPanel extends Serenity.PropertyPanel<ForgotPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Membership {
    class ResetPasswordPanel extends Serenity.PropertyPanel<ResetPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Serene3.Membership {
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
