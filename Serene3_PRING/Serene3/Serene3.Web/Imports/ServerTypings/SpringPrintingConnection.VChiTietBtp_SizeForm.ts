namespace Serene3.SpringPrintingConnection {
    export interface VChiTietBtp_SizeForm {
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
    }

    export class VChiTietBtp_SizeForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VChiTietBtp_Size';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VChiTietBtp_SizeForm.init)  {
                VChiTietBtp_SizeForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;

                Q.initFormType(VChiTietBtp_SizeForm, [
                    'SlLoiKh', w0,
                    'SlLoiIn', w0,
                    'CardId', w1,
                    'Code', w1,
                    'MaBtp', w1,
                    'SlThuc', w0,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaStyle', w1
                ]);
            }
        }
    }
}

