namespace Serene3.SpringPrintingConnection {
    export interface TblRefTypeRow {
        TypeId?: string;
        TypeName?: string;
    }

    export namespace TblRefTypeRow {
        export const idProperty = 'TypeId';
        export const nameProperty = 'TypeName';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefType';
        export const lookupKey = 'SpringPrintingConnection.TblRefType';

        export function getLookup(): Q.Lookup<TblRefTypeRow> {
            return Q.getLookup<TblRefTypeRow>('SpringPrintingConnection.TblRefType');
        }

        export declare const enum Fields {
            TypeId = "TypeId",
            TypeName = "TypeName"
        }
    }
}

