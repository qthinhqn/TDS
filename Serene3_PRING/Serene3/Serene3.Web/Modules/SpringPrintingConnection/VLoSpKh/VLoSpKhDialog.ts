
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VLoSpKhDialog extends Serenity.EntityDialog<VLoSpKhRow, any> {
        protected getFormKey() { return VLoSpKhForm.formKey; }
        protected getIdProperty() { return VLoSpKhRow.idProperty; }
        protected getLocalTextPrefix() { return VLoSpKhRow.localTextPrefix; }
        protected getNameProperty() { return VLoSpKhRow.nameProperty; }
        protected getService() { return VLoSpKhService.baseUrl; }

        protected form = new VLoSpKhForm(this.idPrefix);

    }
}