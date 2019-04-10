namespace Serene3.SpringPrintingConnection {
    export interface TblRefSizeForm {
        MaSize: Serenity.StringEditor;
        TenSize: Serenity.StringEditor;
    }

    export class TblRefSizeForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefSize';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefSizeForm.init)  {
                TblRefSizeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TblRefSizeForm, [
                    'MaSize', w0,
                    'TenSize', w0
                ]);
            }
        }
    }
}

