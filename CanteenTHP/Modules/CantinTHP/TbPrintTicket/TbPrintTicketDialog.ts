
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPrintTicketDialog extends _Ext.DialogBase<TbPrintTicketRow, any> {
        protected getFormKey() { return TbPrintTicketForm.formKey; }
        protected getIdProperty() { return TbPrintTicketRow.idProperty; }
        protected getLocalTextPrefix() { return TbPrintTicketRow.localTextPrefix; }
        protected getNameProperty() { return TbPrintTicketRow.nameProperty; }
        protected getService() { return TbPrintTicketService.baseUrl; }

        protected form = new TbPrintTicketForm(this.idPrefix);

    }
}