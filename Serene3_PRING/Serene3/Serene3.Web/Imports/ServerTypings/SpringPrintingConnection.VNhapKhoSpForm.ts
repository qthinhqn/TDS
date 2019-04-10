namespace Serene3.SpringPrintingConnection {
    export interface VNhapKhoSpForm {
        KeyId: Serenity.IntegerEditor;
        MaKh: Serenity.IntegerEditor;
        TenKh: Serenity.StringEditor;
        NgayNhap: Serenity.DateEditor;
        NguoiNhap: Serenity.IntegerEditor;
        GhiChu: Serenity.StringEditor;
        MaBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        HangMau: Serenity.BooleanEditor;
        HangBu: Serenity.BooleanEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        Po: Serenity.StringEditor;
        Fepo: Serenity.StringEditor;
        BulNo: Serenity.IntegerEditor;
        TableNum: Serenity.StringEditor;
        Buy: Serenity.StringEditor;
        Style04: Serenity.StringEditor;
        Col: Serenity.StringEditor;
        Size: Serenity.StringEditor;
        Part: Serenity.StringEditor;
        Quantity: Serenity.IntegerEditor;
    }

    export class VNhapKhoSpForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VNhapKhoSp';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VNhapKhoSpForm.init)  {
                VNhapKhoSpForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DateEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(VNhapKhoSpForm, [
                    'KeyId', w0,
                    'MaKh', w0,
                    'TenKh', w1,
                    'NgayNhap', w2,
                    'NguoiNhap', w0,
                    'GhiChu', w1,
                    'MaBtp', w1,
                    'SlThuc', w0,
                    'SlLoiKh', w0,
                    'SlLoiIn', w0,
                    'MaMau', w1,
                    'MaSize', w1,
                    'MaStyle', w1,
                    'HangMau', w3,
                    'HangBu', w3,
                    'CardId', w1,
                    'Code', w1,
                    'Po', w1,
                    'Fepo', w1,
                    'BulNo', w0,
                    'TableNum', w1,
                    'Buy', w1,
                    'Style04', w1,
                    'Col', w1,
                    'Size', w1,
                    'Part', w1,
                    'Quantity', w0
                ]);
            }
        }
    }
}

