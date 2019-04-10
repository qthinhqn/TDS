namespace Serene3.SpringPrintingConnection {
    export namespace TblXuongChuyenInChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblXuongChuyenInChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblXuongChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblXuongChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblXuongChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblXuongChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetData(request: SpringPrintingConnection.TblXuongChuyenInChiTiet.TblXuongChuyenInChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblXuongChuyenInChiTiet.TblXuongChuyenInChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Create",
            Update = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Update",
            Delete = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblXuongChuyenInChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblXuongChuyenInChiTiet/List",
            GetData = "SpringPrintingConnection/TblXuongChuyenInChiTiet/GetData"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetData'
        ].forEach(x => {
            (<any>TblXuongChuyenInChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

