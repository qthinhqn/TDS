namespace Serene3.SpringPrintingConnection {
    export interface VTrangThaiBoBtpRow {
        KeyId1?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: number;
        TenBtp?: string;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
        Ngay1?: string;
        NhanVien1?: number;
        Ngay2?: string;
        NhanVien2?: number;
        Ngay3?: string;
        NhanVien3?: number;
        Ngay4?: string;
        NhanVien4?: number;
        HangMau?: boolean;
        HangBu?: boolean;
        MaHd?: number;
    }

    export namespace VTrangThaiBoBtpRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'Code';
        export const localTextPrefix = 'SpringPrintingConnection.VTrangThaiBoBtp';

        export declare const enum Fields {
            KeyId1 = "KeyId1",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            TenBtp = "TenBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
            Ngay1 = "Ngay1",
            NhanVien1 = "NhanVien1",
            Ngay2 = "Ngay2",
            NhanVien2 = "NhanVien2",
            Ngay3 = "Ngay3",
            NhanVien3 = "NhanVien3",
            Ngay4 = "Ngay4",
            NhanVien4 = "NhanVien4",
            HangMau = "HangMau",
            HangBu = "HangBu",
            MaHd = "MaHd"
        }
    }
}

