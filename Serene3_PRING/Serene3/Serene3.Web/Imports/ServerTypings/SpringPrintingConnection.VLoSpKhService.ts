namespace Serene3.SpringPrintingConnection {
    export namespace VLoSpKhService {
        export const baseUrl = 'SpringPrintingConnection/VLoSpKh';

        export declare function Create(request: Serenity.SaveRequest<VLoSpKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VLoSpKhRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VLoSpKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VLoSpKhRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VLoSpKh/Create",
            Update = "SpringPrintingConnection/VLoSpKh/Update",
            Delete = "SpringPrintingConnection/VLoSpKh/Delete",
            Retrieve = "SpringPrintingConnection/VLoSpKh/Retrieve",
            List = "SpringPrintingConnection/VLoSpKh/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VLoSpKhService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

