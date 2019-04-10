namespace Serene3.SpringPrintingConnection {
    export interface VLenChuyenChiTietForm {
        Ngay: Serenity.DateEditor;
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

    export class VLenChuyenChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VLenChuyenChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VLenChuyenChiTietForm.init)  {
                VLenChuyenChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.StringEditor;

                Q.initFormType(VLenChuyenChiTietForm, [
                    'Ngay', w0,
                    'SlLoiKh', w1,
                    'SlLoiIn', w1,
                    'CardId', w2,
                    'Code', w2,
                    'MaBtp', w2,
                    'SlThuc', w1,
                    'MaMau', w2,
                    'MaSize', w2,
                    'MaStyle', w2
                ]);
            }
        }
    }
}

