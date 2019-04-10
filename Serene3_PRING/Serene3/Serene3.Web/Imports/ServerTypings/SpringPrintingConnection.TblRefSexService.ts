namespace Serene3.SpringPrintingConnection {
    export namespace TblRefSexService {
        export const baseUrl = 'SpringPrintingConnection/TblRefSex';

        export declare function Create(request: Serenity.SaveRequest<TblRefSexRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblRefSexRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefSexRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefSexRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblRefSex/Create",
            Update = "SpringPrintingConnection/TblRefSex/Update",
            Delete = "SpringPrintingConnection/TblRefSex/Delete",
            Retrieve = "SpringPrintingConnection/TblRefSex/Retrieve",
            List = "SpringPrintingConnection/TblRefSex/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblRefSexService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

