namespace Serene3.SpringPrintingConnection {
    export interface TblXuatKhoKhForm {
        MaKh: Serenity.LookupEditor;
        NgayXuat: Serenity.DateEditor;
        MaNvXuat: Serenity.LookupEditor;
        SoPhieu: Serenity.StringEditor;
        Ghichu: Serenity.StringEditor;
        DetailList: TblXuatKho_ChiTietEditor;
    }

    export class TblXuatKhoKhForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblXuatKhoKh';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblXuatKhoKhForm.init)  {
                TblXuatKhoKhForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = s.StringEditor;
                var w3 = TblXuatKho_ChiTietEditor;

                Q.initFormType(TblXuatKhoKhForm, [
                    'MaKh', w0,
                    'NgayXuat', w1,
                    'MaNvXuat', w0,
                    'SoPhieu', w2,
                    'Ghichu', w2,
                    'DetailList', w3
                ]);
            }
        }
    }
}

