namespace Serene3.SpringPrintingConnection {
    export interface TblXuongChuyenRow {
        KeyId?: number;
        MaNvQuet?: number;
        Ngay?: string;
        MaNvQuetHoTen?: string;
        MaNvQuetGioiTinh?: string;
        MaNvQuetPhone?: string;
        MaNvQuetMobile?: string;
        MaNvQuetEmail?: string;
        MaNvQuetChucVu?: string;
        MaNvQuetStatus?: boolean;
        DetailList?: TblXuongChuyenIn_ChiTietRow[];
    }

    export namespace TblXuongChuyenRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblXuongChuyen';

        export declare const enum Fields {
            KeyId = "KeyId",
            MaNvQuet = "MaNvQuet",
            Ngay = "Ngay",
            MaNvQuetHoTen = "MaNvQuetHoTen",
            MaNvQuetGioiTinh = "MaNvQuetGioiTinh",
            MaNvQuetPhone = "MaNvQuetPhone",
            MaNvQuetMobile = "MaNvQuetMobile",
            MaNvQuetEmail = "MaNvQuetEmail",
            MaNvQuetChucVu = "MaNvQuetChucVu",
            MaNvQuetStatus = "MaNvQuetStatus",
            DetailList = "DetailList"
        }
    }
}

