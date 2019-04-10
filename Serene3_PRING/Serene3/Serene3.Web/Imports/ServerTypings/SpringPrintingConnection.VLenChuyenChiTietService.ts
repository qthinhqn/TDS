namespace Serene3.SpringPrintingConnection {
    export namespace VLenChuyenChiTietService {
        export const baseUrl = 'SpringPrintingConnection/VLenChuyenChiTiet';

        export declare function Create(request: Serenity.SaveRequest<VLenChuyenChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VLenChuyenChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VLenChuyenChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VLenChuyenChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VLenChuyenChiTiet/Create",
            Update = "SpringPrintingConnection/VLenChuyenChiTiet/Update",
            Delete = "SpringPrintingConnection/VLenChuyenChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/VLenChuyenChiTiet/Retrieve",
            List = "SpringPrintingConnection/VLenChuyenChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VLenChuyenChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

