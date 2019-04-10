namespace Serene3.SpringPrintingConnection {
    export interface VHopDongTrangThaiForm {
        NgayHd: Serenity.DateEditor;
        NoiDung: Serenity.StringEditor;
        GiaTri: Serenity.DecimalEditor;
        SoHd: Serenity.StringEditor;
        TenKh: Serenity.StringEditor;
        MaKh: Serenity.StringEditor;
        MotaBtp: Serenity.StringEditor;
        DonViTinh: Serenity.StringEditor;
        MaMau: Serenity.IntegerEditor;
        TenMau: Serenity.StringEditor;
        MaSize: Serenity.IntegerEditor;
        TenSize: Serenity.StringEditor;
        MaStyle: Serenity.IntegerEditor;
        TenStyle: Serenity.StringEditor;
        SoLuong: Serenity.IntegerEditor;
        DonGia: Serenity.DecimalEditor;
        ThanhTien: Serenity.DecimalEditor;
        SlNhap: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        SlThucXuat: Serenity.IntegerEditor;
        SlThieu: Serenity.IntegerEditor;
    }

    export class VHopDongTrangThaiForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VHopDongTrangThai';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VHopDongTrangThaiForm.init)  {
                VHopDongTrangThaiForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.IntegerEditor;

                Q.initFormType(VHopDongTrangThaiForm, [
                    'NgayHd', w0,
                    'NoiDung', w1,
                    'GiaTri', w2,
                    'SoHd', w1,
                    'TenKh', w1,
                    'MaKh', w1,
                    'MotaBtp', w1,
                    'DonViTinh', w1,
                    'MaMau', w3,
                    'TenMau', w1,
                    'MaSize', w3,
                    'TenSize', w1,
                    'MaStyle', w3,
                    'TenStyle', w1,
                    'SoLuong', w3,
                    'DonGia', w2,
                    'ThanhTien', w2,
                    'SlNhap', w3,
                    'SlLoiKh', w3,
                    'SlLoiIn', w3,
                    'SlThucXuat', w3,
                    'SlThieu', w3
                ]);
            }
        }
    }
}

