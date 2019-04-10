namespace Serene3.SpringPrintingConnection {
    export interface TblLenChuyenIn_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
        MaLenChuyen: Serenity.IntegerEditor;
    }

    export class TblLenChuyenIn_ChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblLenChuyenIn_ChiTietForm.init)  {
                TblLenChuyenIn_ChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(TblLenChuyenIn_ChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'Status', w2,
                    'MaLenChuyen', w3
                ]);
            }
        }
    }
}

