namespace Serene3.SpringPrintingConnection {
    export interface TblRefStyleRow {
        KeyId?: number;
        MaStyle?: string;
        TenStyle?: string;
    }

    export namespace TblRefStyleRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'TenStyle';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefStyle';
        export const lookupKey = 'SpringPrintingConnection.TblRefStyle';

        export function getLookup(): Q.Lookup<TblRefStyleRow> {
            return Q.getLookup<TblRefStyleRow>('SpringPrintingConnection.TblRefStyle');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaStyle = "MaStyle",
            TenStyle = "TenStyle"
        }
    }
}

