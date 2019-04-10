namespace Serene3.SpringPrintingConnection {
    export namespace TblLenChuyenService {
        export const baseUrl = 'SpringPrintingConnection/TblLenChuyen';

        export declare function Create(request: Serenity.SaveRequest<TblLenChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblLenChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyen/Create",
            Update = "SpringPrintingConnection/TblLenChuyen/Update",
            Delete = "SpringPrintingConnection/TblLenChuyen/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyen/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyen/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblLenChuyenService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

