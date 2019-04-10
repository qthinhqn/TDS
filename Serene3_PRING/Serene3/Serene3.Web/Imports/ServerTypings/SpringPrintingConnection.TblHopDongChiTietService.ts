namespace Serene3.SpringPrintingConnection {
    export namespace TblHopDongChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblHopDongChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblHopDongChiTiet/Create",
            Update = "SpringPrintingConnection/TblHopDongChiTiet/Update",
            Delete = "SpringPrintingConnection/TblHopDongChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblHopDongChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblHopDongChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblHopDongChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

