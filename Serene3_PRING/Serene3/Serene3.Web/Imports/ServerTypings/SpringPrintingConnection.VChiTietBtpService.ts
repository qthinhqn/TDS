namespace Serene3.SpringPrintingConnection {
    export namespace VChiTietBtpService {
        export const baseUrl = 'SpringPrintingConnection/VChiTietBtp';

        export declare function Create(request: Serenity.SaveRequest<VChiTietBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VChiTietBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp/Create",
            Update = "SpringPrintingConnection/VChiTietBtp/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VChiTietBtpService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

