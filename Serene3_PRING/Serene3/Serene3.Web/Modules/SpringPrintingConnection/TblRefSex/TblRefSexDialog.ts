
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefSexDialog extends Serenity.EntityDialog<TblRefSexRow, any> {
        protected getFormKey() { return TblRefSexForm.formKey; }
        protected getIdProperty() { return TblRefSexRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefSexRow.localTextPrefix; }
        protected getNameProperty() { return TblRefSexRow.nameProperty; }
        protected getService() { return TblRefSexService.baseUrl; }

        protected form = new TblRefSexForm(this.idPrefix);

    }
}