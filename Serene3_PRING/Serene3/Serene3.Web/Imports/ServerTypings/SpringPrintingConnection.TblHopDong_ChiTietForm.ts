namespace Serene3.SpringPrintingConnection {
    export interface TblHopDong_ChiTietForm {
        KeyId: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
        AdjDetailList: TblHopDong_DieuChinhEditor;
    }

    export class TblHopDong_ChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblHopDong_ChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblHopDong_ChiTietForm.init)  {
                TblHopDong_ChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DecimalEditor;
                var w3 = TblHopDong_DieuChinhEditor;

                Q.initFormType(TblHopDong_ChiTietForm, [
                    'KeyId', w0,
                    'MaBtp', w1,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaStyle', w1,
                    'SoLuong', w0,
                    'DonGia', w2,
                    'ThanhTien', w2,
                    'AdjDetailList', w3
                ]);
            }
        }
    }
}

