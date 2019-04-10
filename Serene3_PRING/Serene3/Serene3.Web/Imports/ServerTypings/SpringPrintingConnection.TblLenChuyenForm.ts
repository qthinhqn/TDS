namespace Serene3.SpringPrintingConnection {
    export interface TblLenChuyenForm {
        MaNvQuet: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        DetailList: TblLenChuyenIn_ChiTietEditor;
    }

    export class TblLenChuyenForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblLenChuyen';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblLenChuyenForm.init)  {
                TblLenChuyenForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = TblLenChuyenIn_ChiTietEditor;

                Q.initFormType(TblLenChuyenForm, [
                    'MaNvQuet', w0,
                    'Ngay', w1,
                    'DetailList', w2
                ]);
            }
        }
    }
}

