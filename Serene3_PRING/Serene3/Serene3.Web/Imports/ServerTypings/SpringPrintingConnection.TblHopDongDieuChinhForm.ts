namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongDieuChinhForm {
        MaChiTietHd: Serenity.LookupEditor;
        SlNhan: Serenity.IntegerEditor;
        SlNhanHu: Serenity.IntegerEditor;
        SlInHu: Serenity.IntegerEditor;
        SlXuat: Serenity.IntegerEditor;
        MaNv: Serenity.LookupEditor;
        NgayDc: Serenity.DateEditor;
    }

    export class TblHopDongDieuChinhForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblHopDongDieuChinh';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblHopDongDieuChinhForm.init)  {
                TblHopDongDieuChinhForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.DateEditor;

                Q.initFormType(TblHopDongDieuChinhForm, [
                    'MaChiTietHd', w0,
                    'SlNhan', w1,
                    'SlNhanHu', w1,
                    'SlInHu', w1,
                    'SlXuat', w1,
                    'MaNv', w0,
                    'NgayDc', w2
                ]);
            }
        }
    }
}

