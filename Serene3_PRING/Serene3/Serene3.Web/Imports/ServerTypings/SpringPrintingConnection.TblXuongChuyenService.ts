namespace Serene3.SpringPrintingConnection {
    export namespace TblXuongChuyenService {
        export const baseUrl = 'SpringPrintingConnection/TblXuongChuyen';

        export declare function Create(request: Serenity.SaveRequest<TblXuongChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuongChuyenRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyen/Create",
            Update = "SpringPrintingConnection/TblXuongChuyen/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyen/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyen/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyen/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblXuongChuyenService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

