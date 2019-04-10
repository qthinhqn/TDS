namespace Serene3.SpringPrintingConnection {
    export interface VHopDongTrangThaiRow {
        MaHd?: number;
        MaCT?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        TenKh?: string;
        MaKh?: string;
        MotaBtp?: string;
        DonViTinh?: string;
        MaMau?: number;
        TenMau?: string;
        MaSize?: number;
        TenSize?: string;
        MaStyle?: number;
        TenStyle?: string;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
        SlNhap?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        SlThucXuat?: number;
        SlThieu?: number;
    }

    export namespace VHopDongTrangThaiRow {
        export const idProperty = 'MaCT';
        export const nameProperty = 'NoiDung';
        export const localTextPrefix = 'SpringPrintingConnection.VHopDongTrangThai';

        export declare const enum Fields {
            MaHd = "MaHd",
            MaCT = "MaCT",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            TenKh = "TenKh",
            MaKh = "MaKh",
            MotaBtp = "MotaBtp",
            DonViTinh = "DonViTinh",
            MaMau = "MaMau",
            TenMau = "TenMau",
            MaSize = "MaSize",
            TenSize = "TenSize",
            MaStyle = "MaStyle",
            TenStyle = "TenStyle",
            SoLuong = "SoLuong",
            DonGia = "DonGia",
            ThanhTien = "ThanhTien",
            SlNhap = "SlNhap",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            SlThucXuat = "SlThucXuat",
            SlThieu = "SlThieu"
        }
    }
}

