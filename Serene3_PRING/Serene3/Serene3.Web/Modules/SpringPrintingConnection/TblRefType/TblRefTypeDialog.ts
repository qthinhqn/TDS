
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefTypeDialog extends Serenity.EntityDialog<TblRefTypeRow, any> {
        protected getFormKey() { return TblRefTypeForm.formKey; }
        protected getIdProperty() { return TblRefTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefTypeRow.localTextPrefix; }
        protected getNameProperty() { return TblRefTypeRow.nameProperty; }
        protected getService() { return TblRefTypeService.baseUrl; }

        protected form = new TblRefTypeForm(this.idPrefix);

    }
}