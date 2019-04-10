
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefSizeDialog extends Serenity.EntityDialog<TblRefSizeRow, any> {
        protected getFormKey() { return TblRefSizeForm.formKey; }
        protected getIdProperty() { return TblRefSizeRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefSizeRow.localTextPrefix; }
        protected getNameProperty() { return TblRefSizeRow.nameProperty; }
        protected getService() { return TblRefSizeService.baseUrl; }

        protected form = new TblRefSizeForm(this.idPrefix);

    }
}