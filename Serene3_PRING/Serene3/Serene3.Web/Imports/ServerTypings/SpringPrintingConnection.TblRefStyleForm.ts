namespace Serene3.SpringPrintingConnection {
    export interface TblRefStyleForm {
        MaStyle: Serenity.StringEditor;
        TenStyle: Serenity.StringEditor;
    }

    export class TblRefStyleForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefStyle';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefStyleForm.init)  {
                TblRefStyleForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TblRefStyleForm, [
                    'MaStyle', w0,
                    'TenStyle', w0
                ]);
            }
        }
    }
}

