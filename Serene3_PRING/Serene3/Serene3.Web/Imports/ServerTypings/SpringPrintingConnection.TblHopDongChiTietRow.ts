namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongChiTietRow {
        KeyId?: number;
        MaHd?: number;
        MaBtp?: number;
        MaMau?: number;
        MaSize?: number;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        MaStyle?: number;
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
        MaStyle1?: string;
        MaStyleTenStyle?: string;
    }

    export namespace TblHopDongChiTietRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblHopDongChiTiet';
        export const lookupKey = 'SpringPrintingConnection.TblHopDongChiTiet';

        export function getLookup(): Q.Lookup<TblHopDongChiTietRow> {
            return Q.getLookup<TblHopDongChiTietRow>('SpringPrintingConnection.TblHopDongChiTiet');
        }

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
            MaStyle1 = "MaStyle1",
            MaStyleTenStyle = "MaStyleTenStyle"
        }
    }
}

