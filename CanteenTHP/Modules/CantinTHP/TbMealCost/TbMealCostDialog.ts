
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbMealCostDialog extends _Ext.DialogBase<TbMealCostRow, any> {
        protected getFormKey() { return TbMealCostForm.formKey; }
        protected getIdProperty() { return TbMealCostRow.idProperty; }
        protected getLocalTextPrefix() { return TbMealCostRow.localTextPrefix; }
        protected getNameProperty() { return TbMealCostRow.nameProperty; }
        protected getService() { return TbMealCostService.baseUrl; }

        protected form = new TbMealCostForm(this.idPrefix);

    }
}