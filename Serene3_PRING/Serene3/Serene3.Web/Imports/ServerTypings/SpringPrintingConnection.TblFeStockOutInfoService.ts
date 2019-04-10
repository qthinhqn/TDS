namespace Serene3.SpringPrintingConnection {
    export namespace TblFeStockOutInfoService {
        export const baseUrl = 'SpringPrintingConnection/TblFeStockOutInfo';

        export declare function Create(request: Serenity.SaveRequest<TblFeStockOutInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblFeStockOutInfoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblFeStockOutInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblFeStockOutInfoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblFeStockOutInfo/Create",
            Update = "SpringPrintingConnection/TblFeStockOutInfo/Update",
            Delete = "SpringPrintingConnection/TblFeStockOutInfo/Delete",
            Retrieve = "SpringPrintingConnection/TblFeStockOutInfo/Retrieve",
            List = "SpringPrintingConnection/TblFeStockOutInfo/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblFeStockOutInfoService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

