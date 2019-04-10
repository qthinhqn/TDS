namespace Serene3.SpringPrintingConnection {
    export namespace TblNguoiDungService {
        export const baseUrl = 'SpringPrintingConnection/TblNguoiDung';

        export declare function Create(request: Serenity.SaveRequest<TblNguoiDungRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblNguoiDungRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblNguoiDungRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblNguoiDungRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblNguoiDung/Create",
            Update = "SpringPrintingConnection/TblNguoiDung/Update",
            Delete = "SpringPrintingConnection/TblNguoiDung/Delete",
            Retrieve = "SpringPrintingConnection/TblNguoiDung/Retrieve",
            List = "SpringPrintingConnection/TblNguoiDung/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblNguoiDungService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

