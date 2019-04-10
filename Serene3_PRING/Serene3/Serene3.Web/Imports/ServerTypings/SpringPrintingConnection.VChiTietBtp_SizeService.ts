namespace Serene3.SpringPrintingConnection {
    export namespace VChiTietBtp_SizeService {
        export const baseUrl = 'SpringPrintingConnection/VChiTietBtp_Size';

        export declare function Create(request: Serenity.SaveRequest<VChiTietBtp_SizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<VChiTietBtp_SizeRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VChiTietBtp_SizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VChiTietBtp_SizeRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "SpringPrintingConnection/VChiTietBtp_Size/Create",
            Update = "SpringPrintingConnection/VChiTietBtp_Size/Update",
            Delete = "SpringPrintingConnection/VChiTietBtp_Size/Delete",
            Retrieve = "SpringPrintingConnection/VChiTietBtp_Size/Retrieve",
            List = "SpringPrintingConnection/VChiTietBtp_Size/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>VChiTietBtp_SizeService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}

