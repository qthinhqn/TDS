namespace Serene3.SpringPrintingConnection {
    export interface VChiTietBtp_Style_ColorRow {
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

    export namespace VChiTietBtp_Style_ColorRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'MaMau';
        export const localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Style_Color';
        export const lookupKey = 'SpringPrintingConnection.VChiTietBtp_Style_Color';

        export function getLookup(): Q.Lookup<VChiTietBtp_Style_ColorRow> {
            return Q.getLookup<VChiTietBtp_Style_ColorRow>('SpringPrintingConnection.VChiTietBtp_Style_Color');
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

