namespace Serene3.SpringPrintingConnection {
    export interface TblRefMauRow {
        KeyId?: number;
        MaMau?: string;
        TenMau?: string;
    }

    export namespace TblRefMauRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'TenMau';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefMau';
        export const lookupKey = 'SpringPrintingConnection.TblRefMau';

        export function getLookup(): Q.Lookup<TblRefMauRow> {
            return Q.getLookup<TblRefMauRow>('SpringPrintingConnection.TblRefMau');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaMau = "MaMau",
            TenMau = "TenMau"
        }
    }
}

