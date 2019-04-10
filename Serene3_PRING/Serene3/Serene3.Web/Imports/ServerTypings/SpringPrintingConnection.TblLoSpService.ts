namespace Serene3.SpringPrintingConnection {
    export namespace TblLoSpService {
        export const baseUrl = 'SpringPrintingConnection/TblLoSp';

        export declare function Create(request: Serenity.SaveRequest<TblLoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblLoSpRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLoSpRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetData(request: SpringPrintingConnection.TblLoSp.TblLoSpRowListRequest, onSuccess?: (response: System.String) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblLoSp/Create",
            Update = "SpringPrintingConnection/TblLoSp/Update",
            Delete = "SpringPrintingConnection/TblLoSp/Delete",
            Retrieve = "SpringPrintingConnection/TblLoSp/Retrieve",
            List = "SpringPrintingConnection/TblLoSp/List",
            GetData = "SpringPrintingConnection/TblLoSp/GetData"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetData'
        ].forEach(x => {
            (<any>TblLoSpService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

