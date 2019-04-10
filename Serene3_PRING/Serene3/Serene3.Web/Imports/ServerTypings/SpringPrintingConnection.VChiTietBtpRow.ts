namespace Serene3.SpringPrintingConnection {
    export interface VChiTietBtpRow {
        KeyId1?: number;
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

    export namespace VChiTietBtpRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'MaBtp';
        export const localTextPrefix = 'SpringPrintingConnection.VChiTietBtp';
        export const lookupKey = 'SpringPrintingConnection.VChiTietBtp';

        export function getLookup(): Q.Lookup<VChiTietBtpRow> {
            return Q.getLookup<VChiTietBtpRow>('SpringPrintingConnection.VChiTietBtp');
        }

        export declare const enum Fields {
            KeyId1 = "KeyId1",
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

