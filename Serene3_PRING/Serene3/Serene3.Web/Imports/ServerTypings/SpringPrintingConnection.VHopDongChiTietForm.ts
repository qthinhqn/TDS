namespace Serene3.SpringPrintingConnection {
    export interface VHopDongChiTietForm {
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        MaKh: Serenity.StringEditor;
        MaBtp: Serenity.IntegerEditor;
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        MaMau: Serenity.StringEditor;
        TenMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        TenSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        TenStyle: Serenity.StringEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
    }

    export class VHopDongChiTietForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VHopDongChiTiet';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VHopDongChiTietForm.init)  {
                VHopDongChiTietForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(VHopDongChiTietForm, [
                    'NgayHd', w0,
                    'NoiDung', w1,
                    'GiaTri', w2,
                    'SoHd', w1,
                    'TenKh', w1,
                    'MaKh', w1,
                    'MaBtp', w3,
                    'MotaBtp', w1,
                    'DonViTinh', w1,
                    'MaMau', w1,
                    'TenMau', w1,
                    'MaSize', w1,
                    'TenSize', w1,
                    'MaStyle', w1,
                    'TenStyle', w1,
                    'SoLuong', w3,
                    'DonGia', w2,
                    'ThanhTien', w2
                ]);
            }
        }
    }
}

