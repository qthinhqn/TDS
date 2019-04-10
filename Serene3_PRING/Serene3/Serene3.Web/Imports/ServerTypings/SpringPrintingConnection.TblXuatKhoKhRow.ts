namespace Serene3.SpringPrintingConnection {
    export interface TblXuatKhoKhRow {
        KeyId?: number;
        MaKh?: number;
        NgayXuat?: string;
        MaNvXuat?: number;
        SoPhieu?: string;
        Ghichu?: string;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
        MaNvXuatHoTen?: string;
        MaNvXuatGioiTinh?: string;
        MaNvXuatPhone?: string;
        MaNvXuatMobile?: string;
        MaNvXuatEmail?: string;
        MaNvXuatChucVu?: string;
        MaNvXuatStatus?: boolean;
        DetailList?: TblXuatKho_ChiTietRow[];
    }

    export namespace TblXuatKhoKhRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'SoPhieu';
        export const localTextPrefix = 'SpringPrintingConnection.TblXuatKhoKh';

        export declare const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayXuat = "NgayXuat",
            MaNvXuat = "MaNvXuat",
            SoPhieu = "SoPhieu",
            Ghichu = "Ghichu",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst",
            MaNvXuatHoTen = "MaNvXuatHoTen",
            MaNvXuatGioiTinh = "MaNvXuatGioiTinh",
            MaNvXuatPhone = "MaNvXuatPhone",
            MaNvXuatMobile = "MaNvXuatMobile",
            MaNvXuatEmail = "MaNvXuatEmail",
            MaNvXuatChucVu = "MaNvXuatChucVu",
            MaNvXuatStatus = "MaNvXuatStatus",
            DetailList = "DetailList"
        }
    }
}

