﻿namespace Serene3.SpringPrintingConnection {
    export namespace TblKhachHangService {
        export const baseUrl = 'SpringPrintingConnection/TblKhachHang';

        export declare function Create(request: Serenity.SaveRequest<TblKhachHangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<TblKhachHangRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TblKhachHangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TblKhachHangRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/TblKhachHang/Create",
            Update = "SpringPrintingConnection/TblKhachHang/Update",
            Delete = "SpringPrintingConnection/TblKhachHang/Delete",
            Retrieve = "SpringPrintingConnection/TblKhachHang/Retrieve",
            List = "SpringPrintingConnection/TblKhachHang/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>TblKhachHangService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

