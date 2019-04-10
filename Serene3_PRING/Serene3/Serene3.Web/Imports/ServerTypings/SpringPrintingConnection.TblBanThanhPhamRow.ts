namespace Serene3.SpringPrintingConnection {
    export interface TblBanThanhPhamRow {
        KeyId?: number;
        MotaBtp?: string;
        DonViTinh?: string;
        NgayTao?: string;
        Status?: boolean;
    }

    export namespace TblBanThanhPhamRow {
        export const idProperty = 'KeyId';
        export const nameProperty = 'MotaBtp';
        export const localTextPrefix = 'SpringPrintingConnection.TblBanThanhPham';
        export const lookupKey = 'SpringPrintingConnection.TblBanThanhPham';

        export function getLookup(): Q.Lookup<TblBanThanhPhamRow> {
            return Q.getLookup<TblBanThanhPhamRow>('SpringPrintingConnection.TblBanThanhPham');
        }

        export declare const enum Fields {
            KeyId = "KeyId",
            MotaBtp = "MotaBtp",
            DonViTinh = "DonViTinh",
            NgayTao = "NgayTao",
            Status = "Status"
        }
    }
}

