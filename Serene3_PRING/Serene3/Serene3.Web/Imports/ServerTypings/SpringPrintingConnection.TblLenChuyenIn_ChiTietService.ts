namespace Serene3.SpringPrintingConnection {
    export namespace TblLenChuyenIn_ChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblLenChuyenIn_ChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblLenChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblLenChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyenIn_ChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblLenChuyenIn_ChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

