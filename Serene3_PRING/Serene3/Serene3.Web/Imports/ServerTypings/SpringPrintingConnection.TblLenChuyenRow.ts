namespace Serene3.SpringPrintingConnection {
    export interface TblLenChuyenRow {
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
        DetailList?: TblLenChuyenIn_ChiTietRow[];
    }

    export namespace TblLenChuyenRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblLenChuyen';

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

