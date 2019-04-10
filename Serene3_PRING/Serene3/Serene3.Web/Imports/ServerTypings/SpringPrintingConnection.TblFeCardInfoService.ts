namespace Serene3.SpringPrintingConnection {
    export namespace TblFeCardInfoService {
        export const baseUrl = 'SpringPrintingConnection/TblFeCardInfo';

        export declare function Create(request: Serenity.SaveRequest<TblFeCardInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblFeCardInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblFeCardInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblFeCardInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblFeCardInfo/Create",
            Update = "SpringPrintingConnection/TblFeCardInfo/Update",
            Delete = "SpringPrintingConnection/TblFeCardInfo/Delete",
            Retrieve = "SpringPrintingConnection/TblFeCardInfo/Retrieve",
            List = "SpringPrintingConnection/TblFeCardInfo/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblFeCardInfoService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

