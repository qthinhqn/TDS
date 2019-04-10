namespace Serene3.SpringPrintingConnection {
    export interface TblRefNguoiDaiDienRow {
        KeyId?: number;
        HoTen?: string;
        GioiTinh?: string;
        SexName?: string;
        Phone?: string;
        Mobile?: string;
        Email?: string;
        ChucVu?: string;
        MaKh?: number;
        Status?: boolean;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
    }

    export namespace TblRefNguoiDaiDienRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'HoTen';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefNguoiDaiDien';
        export const lookupKey = 'SpringPrintingConnection.TblRefNguoiDaiDien';

        export function getLookup(): Q.Lookup<TblRefNguoiDaiDienRow> {
            return Q.getLookup<TblRefNguoiDaiDienRow>('SpringPrintingConnection.TblRefNguoiDaiDien');
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
            MaKh = "MaKh",
            Status = "Status",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst"
        }
    }
}

