namespace Serene3.SpringPrintingConnection {
    export interface TblXuatKho_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaPhieuXuat: Serenity.IntegerEditor;
    }

    export class TblXuatKho_ChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuatKho_ChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuatKho_ChiTietForm.init)  {
                TblXuatKho_ChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(TblXuatKho_ChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'Status', w2,
                    'MaPhieuXuat', w3
                ]);
            }
        }
    }
}

