namespace Serene3.SpringPrintingConnection {
    export interface TblRefSizeRow {
        KeyId?: number;
        MaSize?: string;
        TenSize?: string;
    }

    export namespace TblRefSizeRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'TenSize';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefSize';
        export const lookupKey = 'SpringPrintingConnection.TblRefSize';

        export function getLookup(): Q.Lookup<TblRefSizeRow> {
            return Q.getLookup<TblRefSizeRow>('SpringPrintingConnection.TblRefSize');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MaSize = "MaSize",
            TenSize = "TenSize"
        }
    }
}

