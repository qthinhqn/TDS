namespace Serene3.SpringPrintingConnection {
    export namespace TblLenChuyenInChiTietService {
        export const baseUrl = 'SpringPrintingConnection/TblLenChuyenInChiTiet';

        export declare function Create(request: Serenity.SaveRequest<TblLenChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblLenChuyenInChiTietRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblLenChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblLenChuyenInChiTietRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetData(request: SpringPrintingConnection.TblLenChuyenInChiTiet.TblLenChuyenInChiTietListRequest, onSuccess?: (response: SpringPrintingConnection.TblLenChuyenInChiTiet.TblLenChuyenInChiTietListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblLenChuyenInChiTiet/Create",
            Update = "SpringPrintingConnection/TblLenChuyenInChiTiet/Update",
            Delete = "SpringPrintingConnection/TblLenChuyenInChiTiet/Delete",
            Retrieve = "SpringPrintingConnection/TblLenChuyenInChiTiet/Retrieve",
            List = "SpringPrintingConnection/TblLenChuyenInChiTiet/List",
            GetData = "SpringPrintingConnection/TblLenChuyenInChiTiet/GetData"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetData'
        ].forEach(x => {
            (<any>TblLenChuyenInChiTietService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

