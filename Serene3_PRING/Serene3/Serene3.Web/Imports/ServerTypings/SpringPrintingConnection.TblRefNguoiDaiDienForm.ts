namespace Serene3.SpringPrintingConnection {
    export interface TblRefNguoiDaiDienForm {
        HoTen: Serenity.StringEditor;
        GioiTinh: Serenity.LookupEditor;
        Phone: Serenity.StringEditor;
        Mobile: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ChucVu: Serenity.StringEditor;
        MaKh: Serenity.LookupEditor;
        Status: Serenity.BooleanEditor;
    }

    export class TblRefNguoiDaiDienForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefNguoiDaiDien';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefNguoiDaiDienForm.init)  {
                TblRefNguoiDaiDienForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.EmailEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(TblRefNguoiDaiDienForm, [
                    'HoTen', w0,
                    'GioiTinh', w1,
                    'Phone', w0,
                    'Mobile', w0,
                    'Email', w2,
                    'ChucVu', w0,
                    'MaKh', w1,
                    'Status', w3
                ]);
            }
        }
    }
}

