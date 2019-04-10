namespace Serene3.SpringPrintingConnection {
    export namespace VChiTietBtp_StyleService {
        export const baseUrl = 'SpringPrintingConnection/VChiTietBtp_Style';

        export declare function Create(request: Serenity.SaveRequest<VChiTietBtp_StyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VChiTietBtp_StyleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_StyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_StyleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Style/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Style/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Style/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Style/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Style/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VChiTietBtp_StyleService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

