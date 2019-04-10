namespace Serene3.SpringPrintingConnection {
    export interface TblFeStockOutInfoForm {
        RfidOutputId: Serenity.IntegerEditor;
        DDate: Serenity.DateEditor;
        Fty: Serenity.StringEditor;
        Po: Serenity.StringEditor;
        Fepo: Serenity.StringEditor;
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        BulNo: Serenity.IntegerEditor;
        TableNum: Serenity.StringEditor;
        Buy: Serenity.StringEditor;
        Style04: Serenity.StringEditor;
        Col: Serenity.StringEditor;
        Size: Serenity.StringEditor;
        Part: Serenity.StringEditor;
        OpNo: Serenity.StringEditor;
        OpName: Serenity.StringEditor;
        Quantity: Serenity.IntegerEditor;
        ImportTime: Serenity.DateEditor;
    }

    export class TblFeStockOutInfoForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblFeStockOutInfo';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblFeStockOutInfoForm.init)  {
                TblFeStockOutInfoForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.DateEditor;
                var w2 = s.StringEditor;

                Q.initFormType(TblFeStockOutInfoForm, [
                    'RfidOutputId', w0,
                    'DDate', w1,
                    'Fty', w2,
                    'Po', w2,
                    'Fepo', w2,
                    'CardId', w2,
                    'Code', w2,
                    'BulNo', w0,
                    'TableNum', w2,
                    'Buy', w2,
                    'Style04', w2,
                    'Col', w2,
                    'Size', w2,
                    'Part', w2,
                    'OpNo', w2,
                    'OpName', w2,
                    'Quantity', w0,
                    'ImportTime', w1
                ]);
            }
        }
    }
}

