namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongRow {
        KeyId?: number;
        MaKh?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        NvTao?: number;
        Ngay?: string;
        MaKh1?: string;
        MaKhTenKh?: string;
        MaKhDiaChi?: string;
        MaKhNguoiDaiDien?: number;
        MaKhPhone?: string;
        MaKhMst?: string;
        NvTaoHoTen?: string;
        NvTaoGioiTinh?: string;
        NvTaoPhone?: string;
        NvTaoMobile?: string;
        NvTaoEmail?: string;
        NvTaoChucVu?: string;
        NvTaoStatus?: boolean;
        DetailList?: TblHopDong_ChiTietRow[];
    }

    export namespace TblHopDongRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'SoHd';
        export const localTextPrefix = 'SpringPrintingConnection.TblHopDong';
        export const lookupKey = 'SpringPrintingConnection.TblHopDong';

        export function getLookup(): Q.Lookup<TblHopDongRow> {
            return Q.getLookup<TblHopDongRow>('SpringPrintingConnection.TblHopDong');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            NvTao = "NvTao",
            Ngay = "Ngay",
            MaKh1 = "MaKh1",
            MaKhTenKh = "MaKhTenKh",
            MaKhDiaChi = "MaKhDiaChi",
            MaKhNguoiDaiDien = "MaKhNguoiDaiDien",
            MaKhPhone = "MaKhPhone",
            MaKhMst = "MaKhMst",
            NvTaoHoTen = "NvTaoHoTen",
            NvTaoGioiTinh = "NvTaoGioiTinh",
            NvTaoPhone = "NvTaoPhone",
            NvTaoMobile = "NvTaoMobile",
            NvTaoEmail = "NvTaoEmail",
            NvTaoChucVu = "NvTaoChucVu",
            NvTaoStatus = "NvTaoStatus",
            DetailList = "DetailList"
        }
    }
}

