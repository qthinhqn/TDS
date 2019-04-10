namespace Serene3.SpringPrintingConnection {
    export namespace VHopDongChiTietService {
        export const baseUrl = 'SpringPrintingConnection/VHopDongChiTiet';

        export declare function Create(request: Serenity.SaveRequest<VHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VHopDongChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VHopDongChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VHopDongChiTiet/Create",
            Update = "SpringPrintingConnection/VHopDongChiTiet/Update",
            Delete = "SpringPrintingConnection/VHopDongChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/VHopDongChiTiet/Retrieve",
            List = "SpringPrintingConnection/VHopDongChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VHopDongChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

