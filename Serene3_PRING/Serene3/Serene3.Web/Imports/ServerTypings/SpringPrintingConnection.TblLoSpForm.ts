namespace Serene3.SpringPrintingConnection {
    export interface TblLoSpForm {
        KeyId: Serenity.IntegerEditor;
        MaKh: Serenity.LookupEditor;
        NgayNhap: Serenity.DateEditor;
        NguoiNhap: Serenity.LookupEditor;
        SoLuong: Serenity.IntegerEditor;
        GhiChu: Serenity.StringEditor;
        DetailList: TblBo_BTPEditor;
    }

    export class TblLoSpForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblLoSp';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblLoSpForm.init)  {
                TblLoSpForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DateEditor;
                var w3 = s.StringEditor;
                var w4 = TblBo_BTPEditor;

                Q.initFormType(TblLoSpForm, [
                    'KeyId', w0,
                    'MaKh', w1,
                    'NgayNhap', w2,
                    'NguoiNhap', w1,
                    'SoLuong', w0,
                    'GhiChu', w3,
                    'DetailList', w4
                ]);
            }
        }
    }
}

