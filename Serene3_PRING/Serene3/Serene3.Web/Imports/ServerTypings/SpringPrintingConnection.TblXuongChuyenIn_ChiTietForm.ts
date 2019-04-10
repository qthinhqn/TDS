namespace Serene3.SpringPrintingConnection {
    export interface TblXuongChuyenIn_ChiTietForm {
        MaBo: Serenity.LookupEditor;
        Ngay: Serenity.DateEditor;
        MaXuongChuyen: Serenity.IntegerEditor;
        Status: Serenity.BooleanEditor;
    }

    export class TblXuongChuyenIn_ChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuongChuyenIn_ChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuongChuyenIn_ChiTietForm.init)  {
                TblXuongChuyenIn_ChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(TblXuongChuyenIn_ChiTietForm, [
                    'MaBo', w0,
                    'Ngay', w1,
                    'MaXuongChuyen', w2,
                    'Status', w3
                ]);
            }
        }
    }
}

