
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VNhapKhoSpDialog extends Serenity.EntityDialog<VNhapKhoSpRow, any> {
        protected getFormKey() { return VNhapKhoSpForm.formKey; }
        protected getIdProperty() { return VNhapKhoSpRow.idProperty; }
        protected getLocalTextPrefix() { return VNhapKhoSpRow.localTextPrefix; }
        protected getNameProperty() { return VNhapKhoSpRow.nameProperty; }
        protected getService() { return VNhapKhoSpService.baseUrl; }

        protected form = new VNhapKhoSpForm(this.idPrefix);

    }
}