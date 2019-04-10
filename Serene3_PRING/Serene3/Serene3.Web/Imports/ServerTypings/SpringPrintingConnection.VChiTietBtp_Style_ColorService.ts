namespace Serene3.SpringPrintingConnection {
    export namespace VChiTietBtp_Style_ColorService {
        export const baseUrl = 'SpringPrintingConnection/VChiTietBtp_Style_Color';

        export declare function Create(request: Serenity.SaveRequest<VChiTietBtp_Style_ColorRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VChiTietBtp_Style_ColorRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_Style_ColorRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_Style_ColorRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Style_Color/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Style_Color/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Style_Color/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Style_Color/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Style_Color/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VChiTietBtp_Style_ColorService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

