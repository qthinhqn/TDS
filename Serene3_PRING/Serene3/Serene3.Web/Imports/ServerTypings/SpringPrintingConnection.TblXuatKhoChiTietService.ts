namespace Serene3.SpringPrintingConnection {
    export namespace TblXuatKhoChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblXuatKhoChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblXuatKhoChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuatKhoChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuatKhoChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuatKhoChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetData(request: SpringPrintingConnection.TblXuatKhoChiTiet.TblXuatKhoChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblXuatKhoChiTiet.TblXuatKhoChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuatKhoChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuatKhoChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuatKhoChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuatKhoChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuatKhoChiTiet/List",
            GetData = "SpringPrintingConnection/TblXuatKhoChiTiet/GetData"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetData'
        ].forEach(x => {
            (<any>TblXuatKhoChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

