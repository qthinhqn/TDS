namespace Serene3.SpringPrintingConnection {
    export interface TblRefMauForm {
        MaMau: Serenity.StringEditor;
        TenMau: Serenity.StringEditor;
    }

    export class TblRefMauForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblRefMau';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblRefMauForm.init)  {
                TblRefMauForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(TblRefMauForm, [
                    'MaMau', w0,
                    'TenMau', w0
                ]);
            }
        }
    }
}

