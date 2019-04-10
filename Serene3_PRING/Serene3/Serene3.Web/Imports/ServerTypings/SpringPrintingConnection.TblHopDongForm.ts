namespace Serene3.SpringPrintingConnection {
    export interface TblHopDongForm {
        MaKh: Serenity.LookupEditor;
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        NvTao: Serenity.LookupEditor;
        DetailList: TblHopDongChiTiet_Editor;
    }

    export class TblHopDongForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.TblHopDong';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TblHopDongForm.init)  {
                TblHopDongForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DateEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;
                var w4 = TblHopDongChiTiet_Editor;

                Q.initFormType(TblHopDongForm, [
                    'MaKh', w0,
                    'NgayHd', w1,
                    'NoiDung', w2,
                    'GiaTri', w3,
                    'SoHd', w2,
                    'NvTao', w0,
                    'DetailList', w4
                ]);
            }
        }
    }
}

