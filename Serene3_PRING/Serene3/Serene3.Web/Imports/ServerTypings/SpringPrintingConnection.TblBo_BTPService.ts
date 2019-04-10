namespace Serene3.SpringPrintingConnection {
    export namespace TblBo_BTPService {
        export const baseUrl = 'SpringPrintingConnection/TblBo_BTP';

        export declare function Create(request: Serenity.SaveRequest<TblBo_BTPRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblBo_BTPRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBo_BTPRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBo_BTPRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblBo_BTP/Create",
            Update = "SpringPrintingConnection/TblBo_BTP/Update",
            Delete = "SpringPrintingConnection/TblBo_BTP/Delete",
            Retrieve = "SpringPrintingConnection/TblBo_BTP/Retrieve",
            List = "SpringPrintingConnection/TblBo_BTP/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblBo_BTPService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

