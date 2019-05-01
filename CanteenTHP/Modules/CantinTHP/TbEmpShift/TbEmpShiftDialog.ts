
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpShiftDialog extends Serenity.EntityDialog<TbEmpShiftRow, any> {
        protected getFormKey() { return TbEmpShiftForm.formKey; }
        protected getIdProperty() { return TbEmpShiftRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpShiftRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpShiftRow.nameProperty; }
        protected getService() { return TbEmpShiftService.baseUrl; }

        protected form = new TbEmpShiftForm(this.idPrefix);

    }
}