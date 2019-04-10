namespace Serene3.SpringPrintingConnection {
    export namespace TblRefMauService {
        export const baseUrl = 'SpringPrintingConnection/TblRefMau';

        export declare function Create(request: Serenity.SaveRequest<TblRefMauRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblRefMauRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefMauRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefMauRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblRefMau/Create",
            Update = "SpringPrintingConnection/TblRefMau/Update",
            Delete = "SpringPrintingConnection/TblRefMau/Delete",
            Retrieve = "SpringPrintingConnection/TblRefMau/Retrieve",
            List = "SpringPrintingConnection/TblRefMau/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblRefMauService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

