namespace Serene3.SpringPrintingConnection {
    export namespace TblHopDong_ChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblHopDong_ChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblHopDong_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblHopDong_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDong_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDong_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblHopDong_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblHopDong_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblHopDong_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDong_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblHopDong_ChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblHopDong_ChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

