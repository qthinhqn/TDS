namespace Serene3.SpringPrintingConnection {
    export namespace TblRefSizeService {
        export const baseUrl = 'SpringPrintingConnection/TblRefSize';

        export declare function Create(request: Serenity.SaveRequest<TblRefSizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblRefSizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefSizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefSizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblRefSize/Create",
            Update = "SpringPrintingConnection/TblRefSize/Update",
            Delete = "SpringPrintingConnection/TblRefSize/Delete",
            Retrieve = "SpringPrintingConnection/TblRefSize/Retrieve",
            List = "SpringPrintingConnection/TblRefSize/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblRefSizeService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

