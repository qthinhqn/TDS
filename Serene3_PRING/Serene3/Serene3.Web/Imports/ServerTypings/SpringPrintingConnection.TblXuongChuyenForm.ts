namespace Serene3.SpringPrintingConnection {
    export interface TblXuongChuyenForm {
        MaNvQuet: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        DetailList: TblXuongChuyenIn_ChiTietEditor;
    }

    export class TblXuongChuyenForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuongChuyen';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuongChuyenForm.init)  {
                TblXuongChuyenForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = TblXuongChuyenIn_ChiTietEditor;

                Q.initFormType(TblXuongChuyenForm, [
                    'MaNvQuet', w0,
                    'Ngay', w1,
                    'DetailList', w2
                ]);
            }
        }
    }
}

