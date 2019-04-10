namespace Serene3.SpringPrintingConnection {
    export namespace TblXuatKho_ChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblXuatKho_ChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblXuatKho_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuatKho_ChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKho_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKho_ChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKho_ChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuatKho_ChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuatKho_ChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKho_ChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuatKho_ChiTiet/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblXuatKho_ChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

