namespace Serene3.SpringPrintingConnection {
    export interface TblLoSpRow {
        KeyId?: number;
        MaKh?: number;
        NgayNhap?: string;
        NguoiNhap?: number;
        SoLuong?: number;
        GhiChu?: string;
        TenKH?: string;
        NguoiNhapHoTen?: string;
        NguoiNhapGioiTinh?: string;
        NguoiNhapPhone?: string;
        NguoiNhapMobile?: string;
        NguoiNhapEmail?: string;
        NguoiNhapChucVu?: string;
        NguoiNhapStatus?: boolean;
        Note?: string;
        DetailList?: TblBo_BTPRow[];
    }

    export namespace TblLoSpRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'TenKH';
        export const localTextPrefix = 'SpringPrintingConnection.TblLoSp';
        export const lookupKey = 'SpringPrintingConnection.TblLoSp';

        export function getLookup(): Q.Lookup<TblLoSpRow> {
            return Q.getLookup<TblLoSpRow>('SpringPrintingConnection.TblLoSp');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaKh = "MaKh",
            NgayNhap = "NgayNhap",
            NguoiNhap = "NguoiNhap",
            SoLuong = "SoLuong",
            GhiChu = "GhiChu",
            TenKH = "TenKH",
            NguoiNhapHoTen = "NguoiNhapHoTen",
            NguoiNhapGioiTinh = "NguoiNhapGioiTinh",
            NguoiNhapPhone = "NguoiNhapPhone",
            NguoiNhapMobile = "NguoiNhapMobile",
            NguoiNhapEmail = "NguoiNhapEmail",
            NguoiNhapChucVu = "NguoiNhapChucVu",
            NguoiNhapStatus = "NguoiNhapStatus",
            Note = "Note",
            DetailList = "DetailList"
        }
    }
}

