
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCostTempDialog extends Serenity.EntityDialog<TbEmpCostTempRow, any> {
        protected getFormKey() { return TbEmpCostTempForm.formKey; }
        protected getIdProperty() { return TbEmpCostTempRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCostTempRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpCostTempRow.nameProperty; }
        protected getService() { return TbEmpCostTempService.baseUrl; }

        protected form = new TbEmpCostTempForm(this.idPrefix);

    }
}