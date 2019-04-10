namespace Serene3.SpringPrintingConnection {
    export interface TblXuatKhoChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaPhieuXuat: Serenity.IntegerEditor;
    }

    export class TblXuatKhoChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuatKhoChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuatKhoChiTietForm.init)  {
                TblXuatKhoChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(TblXuatKhoChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'Status', w2,
                    'MaPhieuXuat', w0
                ]);
            }
        }
    }
}

