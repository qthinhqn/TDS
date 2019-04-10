namespace Serene3.SpringPrintingConnection {
    export interface VLoSpKhRow {
        KeyId1?: number;
        MaKh?: number;
        TenKh?: string;
    }

    export namespace VLoSpKhRow {
        export const idProperty = 'KeyId1';
        export const nameProperty = 'TenKh';
        export const localTextPrefix = 'SpringPrintingConnection.VLoSpKh';

        export declare const enum Fields {
            KeyId1 = "KeyId1",
            MaKh = "MaKh",
            TenKh = "TenKh"
        }
    }
}

