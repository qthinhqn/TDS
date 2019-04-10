namespace Serene3.SpringPrintingConnection {
    export namespace VTrangThaiBoBtpService {
        export const baseUrl = 'SpringPrintingConnection/VTrangThaiBoBtp';

        export declare function Create(request: Serenity.SaveRequest<VTrangThaiBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VTrangThaiBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VTrangThaiBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VTrangThaiBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VTrangThaiBoBtp/Create",
            Update = "SpringPrintingConnection/VTrangThaiBoBtp/Update",
            Delete = "SpringPrintingConnection/VTrangThaiBoBtp/Delete",
            Retrieve = "SpringPrintingConnection/VTrangThaiBoBtp/Retrieve",
            List = "SpringPrintingConnection/VTrangThaiBoBtp/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VTrangThaiBoBtpService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

