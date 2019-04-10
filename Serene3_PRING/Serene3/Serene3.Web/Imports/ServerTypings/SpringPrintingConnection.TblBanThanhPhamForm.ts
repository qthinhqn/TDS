namespace Serene3.SpringPrintingConnection {
    export interface TblBanThanhPhamForm {
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        NgayTao: Serenity.DateEditor;
        Status: Serenity.BooleanEditor;
    }

    export class TblBanThanhPhamForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblBanThanhPham';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblBanThanhPhamForm.init)  {
                TblBanThanhPhamForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(TblBanThanhPhamForm, [
                    'MotaBtp', w0,
                    'DonViTinh', w0,
                    'NgayTao', w1,
                    'Status', w2
                ]);
            }
        }
    }
}

