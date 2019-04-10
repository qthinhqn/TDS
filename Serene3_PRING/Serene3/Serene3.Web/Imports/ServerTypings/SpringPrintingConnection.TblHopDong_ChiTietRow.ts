namespace Serene3.SpringPrintingConnection {
    export interface TblHopDong_ChiTietRow {
        KeyId?: number;
        MaHd?: number;
        MaBtp?: number;
        MaMau?: number;
        MaSize?: number;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        MaStyle?: number;
        MaStyleTenStyle?: string;
        MaHdMaKh?: number;
        MaHdNgayHd?: string;
        MaHdNoiDung?: string;
        MaHdGiaTri?: number;
        MaHdSoHd?: string;
        MaHdNvTao?: number;
        MaHdNgay?: string;
        MaBtpMotaBtp?: string;
        MaBtpDonViTinh?: string;
        MaBtpNgayTao?: string;
        MaBtpStatus?: boolean;
        MaMau1?: string;
        MaMauTenMau?: string;
        MaSize1?: string;
        MaSizeTenSize?: string;
        AdjDetailList?: TblHopDong_DieuChinhRow[];
    }

    export namespace TblHopDong_ChiTietRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblHopDong_ChiTiet';

        export declare const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            MaBtp = "MaBtp",
            MaMau = "MaMau",
            MaSize = "MaSize",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
            MaStyle = "MaStyle",
            MaStyleTenStyle = "MaStyleTenStyle",
            MaHdMaKh = "MaHdMaKh",
            MaHdNgayHd = "MaHdNgayHd",
            MaHdNoiDung = "MaHdNoiDung",
            MaHdGiaTri = "MaHdGiaTri",
            MaHdSoHd = "MaHdSoHd",
            MaHdNvTao = "MaHdNvTao",
            MaHdNgay = "MaHdNgay",
            MaBtpMotaBtp = "MaBtpMotaBtp",
            MaBtpDonViTinh = "MaBtpDonViTinh",
            MaBtpNgayTao = "MaBtpNgayTao",
            MaBtpStatus = "MaBtpStatus",
            MaMau1 = "MaMau1",
            MaMauTenMau = "MaMauTenMau",
            MaSize1 = "MaSize1",
            MaSizeTenSize = "MaSizeTenSize",
            AdjDetailList = "AdjDetailList"
        }
    }
}

