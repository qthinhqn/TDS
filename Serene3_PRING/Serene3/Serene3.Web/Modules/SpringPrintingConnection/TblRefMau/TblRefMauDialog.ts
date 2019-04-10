
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefMauDialog extends Serenity.EntityDialog<TblRefMauRow, any> {
        protected getFormKey() { return TblRefMauForm.formKey; }
        protected getIdProperty() { return TblRefMauRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefMauRow.localTextPrefix; }
        protected getNameProperty() { return TblRefMauRow.nameProperty; }
        protected getService() { return TblRefMauService.baseUrl; }

        protected form = new TblRefMauForm(this.idPrefix);

    }
}