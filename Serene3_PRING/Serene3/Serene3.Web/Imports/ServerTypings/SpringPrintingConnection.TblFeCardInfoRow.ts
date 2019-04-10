namespace Serene3.SpringPrintingConnection {
    export interface TblFeCardInfoRow {
        RecId?: string;
        CardId?: number;
        RefBarCode?: string;
        CreateTime?: string;
        ImportTime?: string;
    }

    export namespace TblFeCardInfoRow {
        export const idProperty = 'RecId';
        export const nameProperty = 'RefBarCode';
        export const localTextPrefix = 'SpringPrintingConnection.TblFeCardInfo';

        export declare const enum Fields {
            RecId = "RecId",
            CardId = "CardId",
            RefBarCode = "RefBarCode",
            CreateTime = "CreateTime",
            ImportTime = "ImportTime"
        }
    }
}

