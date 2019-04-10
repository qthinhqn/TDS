namespace Serene3.SpringPrintingConnection {
    export interface VChiTietBtp_StyleRow {
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

    export namespace VChiTietBtp_StyleRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'MaStyle';
        export const localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Style';
        export const lookupKey = 'SpringPrintingConnection.VChiTietBtp_Style';

        export function getLookup(): Q.Lookup<VChiTietBtp_StyleRow> {
            return Q.getLookup<VChiTietBtp_StyleRow>('SpringPrintingConnection.VChiTietBtp_Style');
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

