namespace Serene3.SpringPrintingConnection {
    export interface TblHopDong_DieuChinhForm {
        MaNv: Serenity.LookupEditor;
        SlNhan: Serenity.IntegerEditor;
        SlNhanHu: Serenity.IntegerEditor;
        SlInHu: Serenity.IntegerEditor;
        SlXuat: Serenity.IntegerEditor;
        NgayDc: Serenity.DateEditor;
    }

    export class TblHopDong_DieuChinhForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblHopDong_DieuChinh';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblHopDong_DieuChinhForm.init)  {
                TblHopDong_DieuChinhForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.DateEditor;

                Q.initFormType(TblHopDong_DieuChinhForm, [
                    'MaNv', w0,
                    'SlNhan', w1,
                    'SlNhanHu', w1,
                    'SlInHu', w1,
                    'SlXuat', w1,
                    'NgayDc', w2
                ]);
            }
        }
    }
}

