
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class ZkTblRecordDialog extends Serenity.EntityDialog<ZkTblRecordRow, any> {
        protected getFormKey() { return ZkTblRecordForm.formKey; }
        protected getIdProperty() { return ZkTblRecordRow.idProperty; }
        protected getLocalTextPrefix() { return ZkTblRecordRow.localTextPrefix; }
        protected getNameProperty() { return ZkTblRecordRow.nameProperty; }
        protected getService() { return ZkTblRecordService.baseUrl; }

        protected form = new ZkTblRecordForm(this.idPrefix);

    }
}