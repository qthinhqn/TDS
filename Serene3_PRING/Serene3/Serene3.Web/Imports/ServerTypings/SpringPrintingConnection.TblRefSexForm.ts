namespace Serene3.SpringPrintingConnection {
    export interface TblRefSexForm {
        SexName: Serenity.StringEditor;
    }

    export class TblRefSexForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefSex';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefSexForm.init)  {
                TblRefSexForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TblRefSexForm, [
                    'SexName', w0
                ]);
            }
        }
    }
}

