
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class ZkTblRecordGrid extends Serenity.EntityGrid<ZkTblRecordRow, any> {
        protected getColumnsKey() { return 'CantinTHP.ZkTblRecord'; }
        protected getDialogType() { return ZkTblRecordDialog; }
        protected getIdProperty() { return ZkTblRecordRow.idProperty; }
        protected getLocalTextPrefix() { return ZkTblRecordRow.localTextPrefix; }
        protected getService() { return ZkTblRecordService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}