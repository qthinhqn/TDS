namespace Serene3.SpringPrintingConnection {
    export interface VTrangThaiBoBtpForm {
        CardId: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        MaBtp: Serenity.IntegerEditor;
        TenBtp: Serenity.StringEditor;
        SlThuc: Serenity.IntegerEditor;
        SlLoiKh: Serenity.IntegerEditor;
        SlLoiIn: Serenity.IntegerEditor;
        MaMau: Serenity.StringEditor;
        MaSize: Serenity.StringEditor;
        MaStyle: Serenity.StringEditor;
        Ngay1: Serenity.DateEditor;
        NhanVien1: Serenity.IntegerEditor;
        Ngay2: Serenity.DateEditor;
        NhanVien2: Serenity.IntegerEditor;
        Ngay3: Serenity.DateEditor;
        NhanVien3: Serenity.IntegerEditor;
        Ngay4: Serenity.DateEditor;
        NhanVien4: Serenity.IntegerEditor;
        HangMau: Serenity.BooleanEditor;
        HangBu: Serenity.BooleanEditor;
        MaHd: Serenity.IntegerEditor;
    }

    export class VTrangThaiBoBtpForm extends Serenity.PrefixedContext {
        static formKey = 'SpringPrintingConnection.VTrangThaiBoBtp';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VTrangThaiBoBtpForm.init)  {
                VTrangThaiBoBtpForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.DateEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(VTrangThaiBoBtpForm, [
                    'CardId', w0,
                    'Code', w0,
                    'MaBtp', w1,
                    'TenBtp', w0,
                    'SlThuc', w1,
                    'SlLoiKh', w1,
                    'SlLoiIn', w1,
                    'MaMau', w0,
                    'MaSize', w0,
                    'MaStyle', w0,
                    'Ngay1', w2,
                    'NhanVien1', w1,
                    'Ngay2', w2,
                    'NhanVien2', w1,
                    'Ngay3', w2,
                    'NhanVien3', w1,
                    'Ngay4', w2,
                    'NhanVien4', w1,
                    'HangMau', w3,
                    'HangBu', w3,
                    'MaHd', w1
                ]);
            }
        }
    }
}

