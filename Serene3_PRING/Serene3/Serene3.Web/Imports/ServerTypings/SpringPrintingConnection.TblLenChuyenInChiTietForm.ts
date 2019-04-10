namespace Serene3.SpringPrintingConnection {
    export interface TblLenChuyenInChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        MaLenChuyen: Serenity.IntegerEditor;
        CT_SL_Thuc: Serenity.IntegerEditor;
        CT_SL_Loi_KH: Serenity.IntegerEditor;
    }

    export class TblLenChuyenInChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblLenChuyenInChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblLenChuyenInChiTietForm.init)  {
                TblLenChuyenInChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.DateEditor;

                Q.initFormType(TblLenChuyenInChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'MaLenChuyen', w0,
                    'CT_SL_Thuc', w0,
                    'CT_SL_Loi_KH', w0
                ]);
            }
        }
    }
}

