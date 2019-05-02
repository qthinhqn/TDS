
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCardDialog extends _Ext.DialogBase<TbEmpCardRow, any> {
        protected getFormKey() { return TbEmpCardForm.formKey; }
        protected getIdProperty() { return TbEmpCardRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCardRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpCardRow.nameProperty; }
        protected getService() { return TbEmpCardService.baseUrl; }

        protected form = new TbEmpCardForm(this.idPrefix);

    }
}