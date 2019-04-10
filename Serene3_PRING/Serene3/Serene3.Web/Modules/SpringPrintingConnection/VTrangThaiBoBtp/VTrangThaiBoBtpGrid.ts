
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VTrangThaiBoBtpGrid extends Serenity.EntityGrid<VTrangThaiBoBtpRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VTrangThaiBoBtp'; }
        protected getDialogType() { return VTrangThaiBoBtpDialog; }
        protected getIdProperty() { return VTrangThaiBoBtpRow.idProperty; }
        protected getLocalTextPrefix() { return VTrangThaiBoBtpRow.localTextPrefix; }
        protected getService() { return VTrangThaiBoBtpService.baseUrl; }

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
                title: 'Group By Category',
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