namespace Serene3.SpringPrintingConnection {
    export interface VChiTietBtp_SizeRow {
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

    export namespace VChiTietBtp_SizeRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'MaSize';
        export const localTextPrefix = 'SpringPrintingConnection.VChiTietBtp_Size';
        export const lookupKey = 'SpringPrintingConnection.VChiTietBtp_Size';

        export function getLookup(): Q.Lookup<VChiTietBtp_SizeRow> {
            return Q.getLookup<VChiTietBtp_SizeRow>('SpringPrintingConnection.VChiTietBtp_Size');
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

