namespace Serene3.SpringPrintingConnection {
    export interface VHopDongChiTietRow {
        MaHd?: number;
        NgayHd?: string;
        NoiDung?: string;
        GiaTri?: number;
        SoHd?: string;
        TenKh?: string;
        MaKh?: string;
        MaBtp?: number;
        MotaBtp?: string;
        DonViTinh?: string;
        MaMau?: string;
        TenMau?: string;
        MaSize?: string;
        TenSize?: string;
        MaStyle?: string;
        TenStyle?: string;
        SoLuong?: number;
        DonGia?: number;
        ThanhTien?: number;
    }

    export namespace VHopDongChiTietRow {
        export const idProperty = 'MaHd';
        export const nameProperty = 'NoiDung';
        export const localTextPrefix = 'SpringPrintingConnection.VHopDongChiTiet';

        export declare const enum Fields {
            MaHd = "MaHd",
            NgayHd = "NgayHd",
            NoiDung = "NoiDung",
            GiaTri = "GiaTri",
            SoHd = "SoHd",
            TenKh = "TenKh",
            MaKh = "MaKh",
            MaBtp = "MaBtp",
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
            ThanhTien = "ThanhTien"
        }
    }
}

