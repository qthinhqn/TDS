namespace Serene3.SpringPrintingConnection {
    export interface TblNguoiDungForm {
        HoTen: Serenity.StringEditor;
        GioiTinh: Serenity.LookupEditor;
        Phone: Serenity.StringEditor;
        Mobile: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ChucVu: Serenity.StringEditor;
        Status: Serenity.BooleanEditor;
    }

    export class TblNguoiDungForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblNguoiDung';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblNguoiDungForm.init)  {
                TblNguoiDungForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.EmailEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(TblNguoiDungForm, [
                    'HoTen', w0,
                    'GioiTinh', w1,
                    'Phone', w0,
                    'Mobile', w0,
                    'Email', w2,
                    'ChucVu', w0,
                    'Status', w3
                ]);
            }
        }
    }
}

