namespace Serene3.SpringPrintingConnection {
    export namespace VNhapKhoSpService {
        export const baseUrl = 'SpringPrintingConnection/VNhapKhoSp';

        export declare function Create(request: Serenity.SaveRequest<VNhapKhoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VNhapKhoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VNhapKhoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VNhapKhoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VNhapKhoSp/Create",
            Update = "SpringPrintingConnection/VNhapKhoSp/Update",
            Delete = "SpringPrintingConnection/VNhapKhoSp/Delete",
            Retrieve = "SpringPrintingConnection/VNhapKhoSp/Retrieve",
            List = "SpringPrintingConnection/VNhapKhoSp/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VNhapKhoSpService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

