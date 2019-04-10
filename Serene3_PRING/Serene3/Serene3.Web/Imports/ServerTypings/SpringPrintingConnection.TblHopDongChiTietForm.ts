namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongChiTietForm {
        KeyId: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
    }

    export class TblHopDongChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblHopDongChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblHopDongChiTietForm.init)  {
                TblHopDongChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(TblHopDongChiTietForm, [
                    'KeyId', w0,
                    'MaBtp', w1,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaStyle', w1,
                    'SoLuong', w0,
                    'DonGia', w2,
                    'ThanhTien', w2
                ]);
            }
        }
    }
}

