
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpRegistMealDialog extends _Ext.DialogBase<TbEmpRegistMealRow, any> {
        protected getFormKey() { return TbEmpRegistMealForm.formKey; }
        protected getIdProperty() { return TbEmpRegistMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpRegistMealRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpRegistMealRow.nameProperty; }
        protected getService() { return TbEmpRegistMealService.baseUrl; }

        protected form = new TbEmpRegistMealForm(this.idPrefix);

    }
}