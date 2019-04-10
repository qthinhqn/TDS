namespace Serene3.SpringPrintingConnection {
    export namespace TblXuongChuyenIn_ChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblXuongChuyenIn_ChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblXuongChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuongChuyenIn_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenIn_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblXuongChuyenIn_ChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

