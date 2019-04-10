namespace Serene3.SpringPrintingConnection {
    export interface TblXuongChuyenInChiTietForm {
        MaBo: Serenity.IntegerEditor;
        Ngay: Serenity.DateEditor;
        MaXuongChuyen: Serenity.IntegerEditor;
        Status: Serenity.BooleanEditor;
        CT_SL_Thuc: Serenity.IntegerEditor;
        CT_SL_Loi_KH: Serenity.IntegerEditor;
        LoiIn: Serenity.IntegerEditor;
    }

    export class TblXuongChuyenInChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuongChuyenInChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuongChuyenInChiTietForm.init)  {
                TblXuongChuyenInChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(TblXuongChuyenInChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'MaXuongChuyen', w0,
                    'Status', w2,
                    'CT_SL_Thuc', w0,
                    'CT_SL_Loi_KH', w0,
                    'LoiIn', w0
                ]);
            }
        }
    }
}

