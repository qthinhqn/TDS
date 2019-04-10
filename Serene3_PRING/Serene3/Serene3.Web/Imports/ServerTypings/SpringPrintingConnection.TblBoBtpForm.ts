namespace Serene3.SpringPrintingConnection {
    export interface TblBoBtpForm {
        MaLo: Serenity.IntegerEditor;
        MaBtp: Serenity.LookupEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.LookupEditor;
        MaSize: Serenity.LookupEditor;
        MaHd: Serenity.LookupEditor;
        TypeID: Serenity.LookupEditor;
    }

    export class TblBoBtpForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblBoBtp';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblBoBtpForm.init)  {
                TblBoBtpForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(TblBoBtpForm, [
                    'MaLo', w0,
                    'MaBtp', w1,
                    'SlThuc', w0,
                    'SlLoiKh', w0,
                    'SlLoiIn', w0,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaHd', w1,
                    'TypeID', w1
                ]);
            }
        }
    }
}

