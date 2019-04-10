namespace Serene3.SpringPrintingConnection {
    export interface VLenChuyenChiTietRow {
        KeyId1?: number;
        Ngay?: string;
        SlLoiKh?: number;
        SlLoiIn?: number;
        CardId?: number;
        Code?: string;
        MaBtp?: string;
        SlThuc?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
    }

    export namespace VLenChuyenChiTietRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'Code';
        export const localTextPrefix = 'SpringPrintingConnection.VLenChuyenChiTiet';

        export declare const enum Fields {
            KeyId1 = "KeyId1",
            Ngay = "Ngay",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            CardId = "CardId",
            Code = "Code",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle"
        }
    }
}

