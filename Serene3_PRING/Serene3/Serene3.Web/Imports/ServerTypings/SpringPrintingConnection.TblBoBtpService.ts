namespace Serene3.SpringPrintingConnection {
    export namespace TblBoBtpService {
        export const baseUrl = 'SpringPrintingConnection/TblBoBtp';

        export declare function Create(request: Serenity.SaveRequest<TblBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblBoBtpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblBoBtpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetData(request: SpringPrintingConnection.TTblBoBtpRow.TblBoBtpRowListRequest, onSuccess?: (response: System.String) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblBoBtp/Create",
            Update = "SpringPrintingConnection/TblBoBtp/Update",
            Delete = "SpringPrintingConnection/TblBoBtp/Delete",
            Retrieve = "SpringPrintingConnection/TblBoBtp/Retrieve",
            List = "SpringPrintingConnection/TblBoBtp/List",
            GetData = "SpringPrintingConnection/TblBoBtp/GetData"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetData'
        ].forEach(x => {
            (<any>TblBoBtpService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

