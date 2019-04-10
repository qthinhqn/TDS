namespace Serene3.SpringPrintingConnection {
    export interface TblKhachHangForm {
        MaKh: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        DiaChi: Serenity.StringEditor;
        NguoiDaiDien: Serenity.IntegerEditor;
        Phone: Serenity.StringEditor;
        Mst: Serenity.StringEditor;
    }

    export class TblKhachHangForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblKhachHang';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblKhachHangForm.init)  {
                TblKhachHangForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.IntegerEditor;

                Q.initFormType(TblKhachHangForm, [
                    'MaKh', w0,
                    'TenKh', w0,
                    'DiaChi', w0,
                    'NguoiDaiDien', w1,
                    'Phone', w0,
                    'Mst', w0
                ]);
            }
        }
    }
}

