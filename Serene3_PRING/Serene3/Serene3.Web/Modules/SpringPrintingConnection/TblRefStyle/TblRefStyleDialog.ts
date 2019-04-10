
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefStyleDialog extends Serenity.EntityDialog<TblRefStyleRow, any> {
        protected getFormKey() { return TblRefStyleForm.formKey; }
        protected getIdProperty() { return TblRefStyleRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefStyleRow.localTextPrefix; }
        protected getNameProperty() { return TblRefStyleRow.nameProperty; }
        protected getService() { return TblRefStyleService.baseUrl; }

        protected form = new TblRefStyleForm(this.idPrefix);

    }
}