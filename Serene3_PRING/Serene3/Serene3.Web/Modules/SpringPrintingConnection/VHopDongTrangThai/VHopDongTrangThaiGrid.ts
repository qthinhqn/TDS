
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VHopDongTrangThaiGrid extends Serenity.EntityGrid<VHopDongTrangThaiRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VHopDongTrangThai'; }
        protected getDialogType() { return VHopDongTrangThaiDialog; }
        protected getIdProperty() { return VHopDongTrangThaiRow.idProperty; }
        protected getLocalTextPrefix() { return VHopDongTrangThaiRow.localTextPrefix; }
        protected getService() { return VHopDongTrangThaiService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected createSlickGrid() {
            var grid = super.createSlickGrid();

            // need to register this plugin for grouping or you'll have errors
            grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());

            this.view.setSummaryOptions({
                aggregators: [
                    //new Slick.Aggregators.Avg('UnitPrice'),
                    //new Slick.Aggregators.Sum('UnitsInStock'),
                    //new Slick.Aggregators.Max('UnitsOnOrder'),
                    //new Slick.Aggregators.Avg('ReorderLevel')
                ]
            });

            return grid;
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
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: VHopDongTrangThaiService.baseUrl + '/ListExcel',
                separator: true
            }));

            buttons.push({
                title: 'Group By SoHd',
                cssClass: 'expand-all-button',
                onClick: () => this.view.setGrouping(
                    [{
                        getter: 'SoHd'
                    }]),
                separator: true
            });

            buttons.push({
                title: 'Group By SoHd and product',
                cssClass: 'expand-all-button',
                onClick: () => this.view.setGrouping(
                    [{
                        formatter: x => 'Contract: ' + x.value + ' (' + x.count + ' items)',
                        getter: 'SoHd'
                    }, {
                            formatter: x => ': ' + x.value + ' (' + x.count + ' items)',
                            getter: 'MotaBtp'
                        }])
            });

            buttons.push({
                title: 'No Grouping',
                cssClass: 'collapse-all-button',
                onClick: () => this.view.setGrouping([])
            });

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            return buttons;
            /*
            return [

                {
                    title: 'Excel',
                    onViewSubmit: () => this.onViewSubmit(), service: VHopDongTrangThaiService.baseUrl + '/ListExcel',
                    separator: true
                },
                {
                    title: 'Group By SoHd',
                    cssClass: 'expand-all-button',
                    onClick: () => this.view.setGrouping(
                        [{
                            getter: 'SoHd'
                        }])
                },
                {
                    title: 'Group By SoHd and product',
                    cssClass: 'expand-all-button',
                    onClick: () => this.view.setGrouping(
                        [{
                            formatter: x => 'Contract: ' + x.value + ' (' + x.count + ' items)',
                            getter: 'SoHd'
                        }, {
                                formatter: x => ': ' + x.value + ' (' + x.count + ' items)',
                                getter: 'MotaBtp'
                            }])
                },
                {
                    title: 'No Grouping',
                    cssClass: 'collapse-all-button',
                    onClick: () => this.view.setGrouping([])
                }];
            */
        }
    }
}