namespace Serene3.SpringPrintingConnection {
    export interface TblFeStockOutInfoRow {
        RecId?: string;
        RfidOutputId?: number;
        DDate?: string;
        Fty?: string;
        Po?: string;
        Fepo?: string;
        CardId?: number;
        Code?: string;
        BulNo?: number;
        TableNum?: string;
        Buy?: string;
        Style04?: string;
        Col?: string;
        Size?: string;
        Part?: string;
        OpNo?: string;
        OpName?: string;
        Quantity?: number;
        ImportTime?: string;
    }

    export namespace TblFeStockOutInfoRow {
        export const idProperty = 'RecId';
        export const nameProperty = 'Fty';
        export const localTextPrefix = 'SpringPrintingConnection.TblFeStockOutInfo';

        export declare const enum Fields {
            RecId = "RecId",
            RfidOutputId = "RfidOutputId",
            DDate = "DDate",
            Fty = "Fty",
            Po = "Po",
            Fepo = "Fepo",
            CardId = "CardId",
            Code = "Code",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Buy = "Buy",
            Style04 = "Style04",
            Col = "Col",
            Size = "Size",
            Part = "Part",
            OpNo = "OpNo",
            OpName = "OpName",
            Quantity = "Quantity",
            ImportTime = "ImportTime"
        }
    }
}

