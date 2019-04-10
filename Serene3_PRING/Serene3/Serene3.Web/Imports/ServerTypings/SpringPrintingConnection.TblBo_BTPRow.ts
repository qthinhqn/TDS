﻿namespace Serene3.SpringPrintingConnection {
    export interface TblBo_BTPRow {
        KeyId?: number;
        MaLo?: number;
        MaBtp?: number;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaIn?: number;
        MaOut?: number;
        MaLenChuyen?: number;
        MaXuongChuyen?: number;
        MaMau?: number;
        MaSize?: number;
        HangMau?: boolean;
        HangBu?: boolean;
        MaHd?: number;
        CardId?: number;
        Code?: string;
        MaFeStockOut?: string;
        MaStyle?: number;
        TypeID?: string;
        MaLoMaKh?: number;
        MaLoNgayNhap?: string;
        MaLoNguoiNhap?: number;
        MaLoSoLuong?: number;
        MaLoGhiChu?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        MaStyle1?: string;
        MaStyleTenStyle?: string;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        TypeID1?: string;
        MaTypeTenType?: string;
    }

    export namespace TblBo_BTPRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'MaBtpMotaBtp';
        export const localTextPrefix = 'SpringPrintingConnection.TblBo_BTP';
        export const lookupKey = 'SpringPrintingConnection.TblBo_BTP';

        export function getLookup(): Q.Lookup<TblBo_BTPRow> {
            return Q.getLookup<TblBo_BTPRow>('SpringPrintingConnection.TblBo_BTP');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaLo = "MaLo",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaIn = "MaIn",
            MaOut = "MaOut",
            MaLenChuyen = "MaLenChuyen",
            MaXuongChuyen = "MaXuongChuyen",
            MaMau = "MaMau",
            MaSize = "MaSize",
            HangMau = "HangMau",
            HangBu = "HangBu",
            MaHd = "MaHd",
            CardId = "CardId",
            Code = "Code",
            MaFeStockOut = "MaFeStockOut",
            MaStyle = "MaStyle",
            TypeID = "TypeID",
            MaLoMaKh = "MaLoMaKh",
            MaLoNgayNhap = "MaLoNgayNhap",
            MaLoNguoiNhap = "MaLoNguoiNhap",
            MaLoSoLuong = "MaLoSoLuong",
            MaLoGhiChu = "MaLoGhiChu",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            MaStyle1 = "MaStyle1",
            MaStyleTenStyle = "MaStyleTenStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            TypeID1 = "TypeID1",
            MaTypeTenType = "MaTypeTenType"
        }
    }
}

