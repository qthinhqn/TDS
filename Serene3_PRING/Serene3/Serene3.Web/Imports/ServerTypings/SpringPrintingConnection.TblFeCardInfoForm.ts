namespace Serene3.SpringPrintingConnection {
    export interface TblFeCardInfoForm {
        CardId: Serenity.StringEditor;
        RefBarCode: Serenity.StringEditor;
        CreateTime: Serenity.DateEditor;
        ImportTime: Serenity.DateEditor;
    }

    export class TblFeCardInfoForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblFeCardInfo';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblFeCardInfoForm.init)  {
                TblFeCardInfoForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;

                Q.initFormType(TblFeCardInfoForm, [
                    'CardId', w0,
                    'RefBarCode', w0,
                    'CreateTime', w1,
                    'ImportTime', w1
                ]);
            }
        }
    }
}

