namespace Serene3.SpringPrintingConnection {
    export interface TblNguoiDungRow {
        KeyId?: number;
        HoTen?: string;
        GioiTinh?: string;
        SexName?: string;
        Phone?: string;
        Mobile?: string;
        Email?: string;
        ChucVu?: string;
        Status?: boolean;
    }

    export namespace TblNguoiDungRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'HoTen';
        export const localTextPrefix = 'SpringPrintingConnection.TblNguoiDung';
        export const lookupKey = 'SpringPrintingConnection.TblNguoiDung';

        export function getLookup(): Q.Lookup<TblNguoiDungRow> {
            return Q.getLookup<TblNguoiDungRow>('SpringPrintingConnection.TblNguoiDung');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            HoTen = "HoTen",
            GioiTinh = "GioiTinh",
            SexName = "SexName",
            Phone = "Phone",
            Mobile = "Mobile",
            Email = "Email",
            ChucVu = "ChucVu",
            Status = "Status"
        }
    }
}

