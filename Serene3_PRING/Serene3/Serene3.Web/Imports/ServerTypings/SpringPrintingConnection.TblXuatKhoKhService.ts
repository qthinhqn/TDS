namespace Serene3.SpringPrintingConnection {
    export namespace TblXuatKhoKhService {
        export const baseUrl = 'SpringPrintingConnection/TblXuatKhoKh';

        export declare function Create(request: Serenity.SaveRequest<TblXuatKhoKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuatKhoKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKhoKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKhoKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKhoKh/Create",
            Update = "SpringPrintingConnection/TblXuatKhoKh/Update",
            Delete = "SpringPrintingConnection/TblXuatKhoKh/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKhoKh/Retrieve",
            List = "SpringPrintingConnection/TblXuatKhoKh/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblXuatKhoKhService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

