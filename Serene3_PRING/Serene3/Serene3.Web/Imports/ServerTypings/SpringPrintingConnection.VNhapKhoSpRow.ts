namespace Serene3.SpringPrintingConnection {
    export interface VNhapKhoSpRow {
        Expr1?: number;
        KeyId?: number;
        MaKh?: number;
        TenKh?: string;
        NgayNhap?: string;
        NguoiNhap?: number;
        GhiChu?: string;
        MaBtp?: string;
        SlThuc?: number;
        SlLoiKh?: number;
        SlLoiIn?: number;
        MaMau?: string;
        MaSize?: string;
        MaStyle?: string;
        HangMau?: boolean;
        HangBu?: boolean;
        CardId?: number;
        Code?: string;
        Po?: string;
        Fepo?: string;
        BulNo?: number;
        TableNum?: string;
        Buy?: string;
        Style04?: string;
        Col?: string;
        Size?: string;
        Part?: string;
        Quantity?: number;
    }

    export namespace VNhapKhoSpRow {
        export const idProperty = 'Expr1';
        export const nameProperty = 'TenKh';
        export const localTextPrefix = 'SpringPrintingConnection.VNhapKhoSp';

        export declare const enum Fields {
            Expr1 = "Expr1",
            KeyId = "KeyId",
            MaKh = "MaKh",
            TenKh = "TenKh",
            NgayNhap = "NgayNhap",
            NguoiNhap = "NguoiNhap",
            GhiChu = "GhiChu",
            MaBtp = "MaBtp",
            SlThuc = "SlThuc",
            SlLoiKh = "SlLoiKh",
            SlLoiIn = "SlLoiIn",
            MaMau = "MaMau",
            MaSize = "MaSize",
            MaStyle = "MaStyle",
            HangMau = "HangMau",
            HangBu = "HangBu",
            CardId = "CardId",
            Code = "Code",
            Po = "Po",
            Fepo = "Fepo",
            BulNo = "BulNo",
            TableNum = "TableNum",
            Buy = "Buy",
            Style04 = "Style04",
            Col = "Col",
            Size = "Size",
            Part = "Part",
            Quantity = "Quantity"
        }
    }
}

