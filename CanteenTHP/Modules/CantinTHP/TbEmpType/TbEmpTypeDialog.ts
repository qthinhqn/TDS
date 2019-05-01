
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpTypeDialog extends Serenity.EntityDialog<TbEmpTypeRow, any> {
        protected getFormKey() { return TbEmpTypeForm.formKey; }
        protected getIdProperty() { return TbEmpTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpTypeRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpTypeRow.nameProperty; }
        protected getService() { return TbEmpTypeService.baseUrl; }

        protected form = new TbEmpTypeForm(this.idPrefix);

    }
}