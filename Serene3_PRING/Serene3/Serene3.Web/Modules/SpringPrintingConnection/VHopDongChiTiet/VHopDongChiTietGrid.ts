
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VHopDongChiTietGrid extends Serenity.EntityGrid<VHopDongChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VHopDongChiTiet'; }
        protected getDialogType() { return VHopDongChiTietDialog; }
        protected getIdProperty() { return VHopDongChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return VHopDongChiTietRow.localTextPrefix; }
        protected getService() { return VHopDongChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getSlickOptions() {
            var opt = super.getSlickOptions();
            opt.showFooterRow = true;
            return opt;
        }

        protected usePager() {
            return false;
        }

        protected getButtons() {
            return [{
                title: 'Group By HD',
                cssClass: 'expand-all-button',
                onClick: () => this.view.setGrouping(
                    [{
                        getter: 'MaHd'
                    }])
            },
                {
                    title: 'No Grouping',
                    cssClass: 'collapse-all-button',
                    onClick: () => this.view.setGrouping([])
                }];
        }
    }
}