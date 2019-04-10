namespace Serene3.SpringPrintingConnection {
    export interface VLoSpKhForm {
        MaKh: Serenity.IntegerEditor;
        TenKh: Serenity.StringEditor;
    }

    export class VLoSpKhForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VLoSpKh';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VLoSpKhForm.init)  {
                VLoSpKhForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;

                Q.initFormType(VLoSpKhForm, [
                    'MaKh', w0,
                    'TenKh', w1
                ]);
            }
        }
    }
}

