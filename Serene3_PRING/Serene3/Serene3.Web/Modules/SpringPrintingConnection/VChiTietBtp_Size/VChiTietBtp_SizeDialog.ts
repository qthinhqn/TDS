
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_SizeDialog extends Serenity.EntityDialog<VChiTietBtp_SizeRow, any> {
        protected getFormKey() { return VChiTietBtp_SizeForm.formKey; }
        protected getIdProperty() { return VChiTietBtp_SizeRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_SizeRow.localTextPrefix; }
        protected getNameProperty() { return VChiTietBtp_SizeRow.nameProperty; }
        protected getService() { return VChiTietBtp_SizeService.baseUrl; }

        protected form = new VChiTietBtp_SizeForm(this.idPrefix);

    }
}