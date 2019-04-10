namespace Serene3.SpringPrintingConnection {
    export interface TblBo_BTPForm {
        MaLo: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaStyle: Serenity.LookupEditor;
        MaHd: Serenity.LookupEditor;
        TypeID: Serenity.LookupEditor;
    }

    export class TblBo_BTPForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblBo_BTP';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblBo_BTPForm.init)  {
                TblBo_BTPForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(TblBo_BTPForm, [
                    'MaLo', w0,
                    'MaBtp', w1,
                    'SlThuc', w0,
                    'SlLoiKh', w0,
                    'SlLoiIn', w0,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaStyle', w1,
                    'MaHd', w1,
                    'TypeID', w1
                ]);
            }
        }
    }
}

