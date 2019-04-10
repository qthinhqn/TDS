namespace Serene3.SpringPrintingConnection {
    export interface TblRefTypeForm {
        TypeName: Serenity.StringEditor;
    }

    export class TblRefTypeForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefTypeForm.init)  {
                TblRefTypeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TblRefTypeForm, [
                    'TypeName', w0
                ]);
            }
        }
    }
}

