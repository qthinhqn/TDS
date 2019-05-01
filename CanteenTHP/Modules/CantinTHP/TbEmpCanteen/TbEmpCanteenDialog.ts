
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCanteenDialog extends Serenity.EntityDialog<TbEmpCanteenRow, any> {
        protected getFormKey() { return TbEmpCanteenForm.formKey; }
        protected getIdProperty() { return TbEmpCanteenRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCanteenRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpCanteenRow.nameProperty; }
        protected getService() { return TbEmpCanteenService.baseUrl; }

        protected form = new TbEmpCanteenForm(this.idPrefix);

    }
}