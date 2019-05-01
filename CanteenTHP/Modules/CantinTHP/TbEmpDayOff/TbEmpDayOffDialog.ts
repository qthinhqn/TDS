
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpDayOffDialog extends Serenity.EntityDialog<TbEmpDayOffRow, any> {
        protected getFormKey() { return TbEmpDayOffForm.formKey; }
        protected getIdProperty() { return TbEmpDayOffRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpDayOffRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpDayOffRow.nameProperty; }
        protected getService() { return TbEmpDayOffService.baseUrl; }

        protected form = new TbEmpDayOffForm(this.idPrefix);

    }
}