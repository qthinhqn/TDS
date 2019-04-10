namespace Serene3.SpringPrintingConnection {
    export namespace TblBanThanhPhamService {
        export const baseUrl = 'SpringPrintingConnection/TblBanThanhPham';

        export declare function Create(request: Serenity.SaveRequest<TblBanThanhPhamRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblBanThanhPhamRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBanThanhPhamRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBanThanhPhamRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblBanThanhPham/Create",
            Update = "SpringPrintingConnection/TblBanThanhPham/Update",
            Delete = "SpringPrintingConnection/TblBanThanhPham/Delete",
            Retrieve = "SpringPrintingConnection/TblBanThanhPham/Retrieve",
            List = "SpringPrintingConnection/TblBanThanhPham/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblBanThanhPhamService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

