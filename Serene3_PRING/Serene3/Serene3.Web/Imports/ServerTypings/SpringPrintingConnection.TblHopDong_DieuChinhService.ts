namespace Serene3.SpringPrintingConnection {
    export namespace TblHopDong_DieuChinhService {
        export const baseUrl = 'SpringPrintingConnection/TblHopDong_DieuChinh';

        export declare function Create(request: Serenity.SaveRequest<TblHopDong_DieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblHopDong_DieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDong_DieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDong_DieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblHopDong_DieuChinh/Create",
            Update = "SpringPrintingConnection/TblHopDong_DieuChinh/Update",
            Delete = "SpringPrintingConnection/TblHopDong_DieuChinh/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDong_DieuChinh/Retrieve",
            List = "SpringPrintingConnection/TblHopDong_DieuChinh/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblHopDong_DieuChinhService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

