namespace Serene3.SpringPrintingConnection {
    export namespace TblHopDongDieuChinhService {
        export const baseUrl = 'SpringPrintingConnection/TblHopDongDieuChinh';

        export declare function Create(request: Serenity.SaveRequest<TblHopDongDieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblHopDongDieuChinhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDongDieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDongDieuChinhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblHopDongDieuChinh/Create",
            Update = "SpringPrintingConnection/TblHopDongDieuChinh/Update",
            Delete = "SpringPrintingConnection/TblHopDongDieuChinh/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDongDieuChinh/Retrieve",
            List = "SpringPrintingConnection/TblHopDongDieuChinh/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblHopDongDieuChinhService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

