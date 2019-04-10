namespace Serene3.SpringPrintingConnection {
    export namespace VHopDongTrangThaiService {
        export const baseUrl = 'SpringPrintingConnection/VHopDongTrangThai';

        export declare function Create(request: Serenity.SaveRequest<VHopDongTrangThaiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VHopDongTrangThaiRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VHopDongTrangThaiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VHopDongTrangThaiRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VHopDongTrangThai/Create",
            Update = "SpringPrintingConnection/VHopDongTrangThai/Update",
            Delete = "SpringPrintingConnection/VHopDongTrangThai/Delete",
            Retrieve = "SpringPrintingConnection/VHopDongTrangThai/Retrieve",
            List = "SpringPrintingConnection/VHopDongTrangThai/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VHopDongTrangThaiService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

