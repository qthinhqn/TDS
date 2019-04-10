﻿namespace Serene3.SpringPrintingConnection {
    export interface TblLenChuyenIn_ChiTietRow {
        KeyId?: number;
        MaBo?: number;
        MotaBTP?: string;
        Ngay?: string;
        Status?: boolean;
        MaLenChuyen?: number;
        MaBoMaLo?: number;
        MaBoMaBtp?: number;
        MaBoSlThuc?: number;
        MaBoSlLoiKh?: number;
        MaBoSlLoiIn?: number;
        MaBoMaIn?: number;
        MaBoMaOut?: number;
        MaBoMaLenChuyen?: number;
        MaBoMaXuongChuyen?: number;
        MaBoMaMau?: number;
        MaBoMaSize?: number;
        MaBoHangMau?: boolean;
        MaBoHangBu?: boolean;
        MaBoMaHd?: number;
        MaBoCardId?: number;
        MaBoCode?: string;
        MaBoMaFeStockOut?: string;
        MaBoMaStyle?: number;
        MaLenChuyenMaNvQuet?: number;
        MaLenChuyenNgay?: string;
        CT_MaBTP?: string;
        CT_MaMau?: string;
        CT_MaSize?: string;
        CT_MaStyle?: string;
        CT_SL_Thuc?: number;
        CT_SL_Loi_KH?: number;
        CT_SL_Loi_In?: number;
    }

    export namespace TblLenChuyenIn_ChiTietRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet';

        export declare const enum Fields {
            KeyId = "KeyId",
            MaBo = "MaBo",
            MotaBTP = "MotaBTP",
            Ngay = "Ngay",
            Status = "Status",
            MaLenChuyen = "MaLenChuyen",
            MaBoMaLo = "MaBoMaLo",
            MaBoMaBtp = "MaBoMaBtp",
            MaBoSlThuc = "MaBoSlThuc",
            MaBoSlLoiKh = "MaBoSlLoiKh",
            MaBoSlLoiIn = "MaBoSlLoiIn",
            MaBoMaIn = "MaBoMaIn",
            MaBoMaOut = "MaBoMaOut",
            MaBoMaLenChuyen = "MaBoMaLenChuyen",
            MaBoMaXuongChuyen = "MaBoMaXuongChuyen",
            MaBoMaMau = "MaBoMaMau",
            MaBoMaSize = "MaBoMaSize",
            MaBoHangMau = "MaBoHangMau",
            MaBoHangBu = "MaBoHangBu",
            MaBoMaHd = "MaBoMaHd",
            MaBoCardId = "MaBoCardId",
            MaBoCode = "MaBoCode",
            MaBoMaFeStockOut = "MaBoMaFeStockOut",
            MaBoMaStyle = "MaBoMaStyle",
            MaLenChuyenMaNvQuet = "MaLenChuyenMaNvQuet",
            MaLenChuyenNgay = "MaLenChuyenNgay",
            CT_MaBTP = "CT_MaBTP",
            CT_MaMau = "CT_MaMau",
            CT_MaSize = "CT_MaSize",
            CT_MaStyle = "CT_MaStyle",
            CT_SL_Thuc = "CT_SL_Thuc",
            CT_SL_Loi_KH = "CT_SL_Loi_KH",
            CT_SL_Loi_In = "CT_SL_Loi_In"
        }
    }
}
