
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefReason4AdjustGrid extends _Ext.GridBase<TbRefReason4AdjustRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefReason4Adjust'; }
        protected getDialogType() { return TbRefReason4AdjustDialog; }
        protected getIdProperty() { return TbRefReason4AdjustRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefReason4AdjustRow.localTextPrefix; }
        protected getService() { return TbRefReason4AdjustService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}