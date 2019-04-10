namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongDieuChinhRow {
        KeyId?: number;
        MaHd?: number;
        SlNhan?: number;
        SlNhanHu?: number;
        SlInHu?: number;
        SlXuat?: number;
        MaNv?: number;
        NgayDc?: string;
        MaChiTietHd?: number;
        MaHd1?: number;
        MaHdMaBtp?: number;
        MaHdMaMau?: number;
        MaHdMaSize?: number;
        MaHdSoLuong?: number;
        MaHdDonGia?: number;
        MaHdThanhTien?: number;
        MaHdMaStyle?: number;
        MaNvHoTen?: string;
        MaNvGioiTinh?: string;
        MaNvPhone?: string;
        MaNvMobile?: string;
        MaNvEmail?: string;
        MaNvChucVu?: string;
        MaNvStatus?: boolean;
        MaChiTietHdMaHd?: number;
        MaChiTietHdMaBtp?: number;
        MaChiTietHdMaMau?: number;
        MaChiTietHdMaSize?: number;
        MaChiTietHdSoLuong?: number;
        MaChiTietHdDonGia?: number;
        MaChiTietHdThanhTien?: number;
        MaChiTietHdMaStyle?: number;
    }

    export namespace TblHopDongDieuChinhRow {
        export const idProperty = 'KeyId';
        export const localTextPrefix = 'SpringPrintingConnection.TblHopDongDieuChinh';

        export declare const enum Fields {
            KeyId = "KeyId",
            MaHd = "MaHd",
            SlNhan = "SlNhan",
            SlNhanHu = "SlNhanHu",
            SlInHu = "SlInHu",
            SlXuat = "SlXuat",
            MaNv = "MaNv",
            NgayDc = "NgayDc",
            MaChiTietHd = "MaChiTietHd",
            MaHd1 = "MaHd1",
            MaHdMaBtp = "MaHdMaBtp",
            MaHdMaMau = "MaHdMaMau",
            MaHdMaSize = "MaHdMaSize",
            MaHdSoLuong = "MaHdSoLuong",
            MaHdDonGia = "MaHdDonGia",
            MaHdThanhTien = "MaHdThanhTien",
            MaHdMaStyle = "MaHdMaStyle",
            MaNvHoTen = "MaNvHoTen",
            MaNvGioiTinh = "MaNvGioiTinh",
            MaNvPhone = "MaNvPhone",
            MaNvMobile = "MaNvMobile",
            MaNvEmail = "MaNvEmail",
            MaNvChucVu = "MaNvChucVu",
            MaNvStatus = "MaNvStatus",
            MaChiTietHdMaHd = "MaChiTietHdMaHd",
            MaChiTietHdMaBtp = "MaChiTietHdMaBtp",
            MaChiTietHdMaMau = "MaChiTietHdMaMau",
            MaChiTietHdMaSize = "MaChiTietHdMaSize",
            MaChiTietHdSoLuong = "MaChiTietHdSoLuong",
            MaChiTietHdDonGia = "MaChiTietHdDonGia",
            MaChiTietHdThanhTien = "MaChiTietHdThanhTien",
            MaChiTietHdMaStyle = "MaChiTietHdMaStyle"
        }
    }
}

