namespace Serene3.SpringPrintingConnection {
    export interface TblKhachHangRow {
        KeyId?: number;
        MaKh?: string;
        TenKh?: string;
        DiaChi?: string;
        NguoiDaiDien?: number;
        Phone?: string;
        Mst?: string;
        NguoiDaiDienHoTen?: string;
        NguoiDaiDienGioiTinh?: string;
        NguoiDaiDienPhone?: string;
        NguoiDaiDienMobile?: string;
        NguoiDaiDienEmail?: string;
        NguoiDaiDienChucVu?: string;
        NguoiDaiDienMaKh?: number;
        NguoiDaiDienStatus?: boolean;
    }

    export namespace TblKhachHangRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'TenKh';
        export const localTextPrefix = 'SpringPrintingConnection.TblKhachHang';
        export const lookupKey = 'SpringPrintingConnection.TblKhachHang';

        export function getLookup(): Q.Lookup<TblKhachHangRow> {
            return Q.getLookup<TblKhachHangRow>('SpringPrintingConnection.TblKhachHang');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            TenKh = "TenKh",
            DiaChi = "DiaChi",
            NguoiDaiDien = "NguoiDaiDien",
            Phone = "Phone",
            Mst = "Mst",
            NguoiDaiDienHoTen = "NguoiDaiDienHoTen",
            NguoiDaiDienGioiTinh = "NguoiDaiDienGioiTinh",
            NguoiDaiDienPhone = "NguoiDaiDienPhone",
            NguoiDaiDienMobile = "NguoiDaiDienMobile",
            NguoiDaiDienEmail = "NguoiDaiDienEmail",
            NguoiDaiDienChucVu = "NguoiDaiDienChucVu",
            NguoiDaiDienMaKh = "NguoiDaiDienMaKh",
            NguoiDaiDienStatus = "NguoiDaiDienStatus"
        }
    }
}

