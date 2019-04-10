namespace Serene3.SpringPrintingConnection {
    export interface TblRefSexRow {
        SexId?: string;
        SexName?: string;
    }

    export namespace TblRefSexRow {
        export const idProperty = 'SexId';
        export const nameProperty = 'SexId';
        export const localTextPrefix = 'SpringPrintingConnection.TblRefSex';
        export const lookupKey = 'SpringPrintingConnection.TblRefSex';

        export function getLookup(): Q.Lookup<TblRefSexRow> {
            return Q.getLookup<TblRefSexRow>('SpringPrintingConnection.TblRefSex');
        }

        export declare const enum Fields {
            SexId = "SexId",
            SexName = "SexName"
        }
    }
}

