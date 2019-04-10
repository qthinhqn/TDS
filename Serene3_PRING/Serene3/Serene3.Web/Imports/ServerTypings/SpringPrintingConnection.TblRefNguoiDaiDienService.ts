namespace Serene3.SpringPrintingConnection {
    export namespace TblRefNguoiDaiDienService {
        export const baseUrl = 'SpringPrintingConnection/TblRefNguoiDaiDien';

        export declare function Create(request: Serenity.SaveRequest<TblRefNguoiDaiDienRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblRefNguoiDaiDienRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblRefNguoiDaiDienRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblRefNguoiDaiDienRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblRefNguoiDaiDien/Create",
            Update = "SpringPrintingConnection/TblRefNguoiDaiDien/Update",
            Delete = "SpringPrintingConnection/TblRefNguoiDaiDien/Delete",
            Retrieve = "SpringPrintingConnection/TblRefNguoiDaiDien/Retrieve",
            List = "SpringPrintingConnection/TblRefNguoiDaiDien/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblRefNguoiDaiDienService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

