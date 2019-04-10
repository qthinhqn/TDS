
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblXuatKhoChiTietGrid extends Serenity.EntityGrid<TblXuatKhoChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblXuatKhoChiTiet'; }
        protected getDialogType() { return TblXuatKhoChiTietDialog; }
        protected getIdProperty() { return TblXuatKhoChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKhoChiTietRow.localTextPrefix; }
        protected getService() { return TblXuatKhoChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblXuatKhoChiTietService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
        private month: Serenity.StringEditor;
        private sMaLo: string;
        // private country: Serenity.StringEditor;
        private sMaLo111: string;

        protected createToolbarExtensions() {
            super.createToolbarExtensions();

            //this.country = Serenity.Widget.create({
            //    type: Serenity.StringEditor,
            //    element: el => el.appendTo(this.toolbar.element).attr('placeholder', '--- ' +
            //        Q.text('Ma Lo') + ' ---'
            //    ).css("width", "100px")
            //});

            this.month = Serenity.Widget.create({

                type: Serenity.StringEditor,
                options: {

                },
                element: e => e.insertAfter(this.toolbar.element).attr('placeholder', '-Scan Card-').css("width", "150px"),
                init: w => w.change(x => {
                    if (!(Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                        alert(Q.text("Permission.NotPermission"));
                        return;
                    }
                    if (this.sMaLo111 != "" && this.sMaLo111 != undefined) {
                        TblXuatKhoChiTietService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaBo: this.sMaLo111
                            },
                            response => {
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                this.sMaLo = response.KeyID.toString();
                                this.refresh();
                            });
                    }
                    else {
                        TblXuatKhoChiTietService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaBo: this.sMaLo
                            },
                            response => {
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                this.sMaLo = response.KeyID.toString();
                                this.sMaLo111 = this.sMaLo;
                                this.refresh();
                            });
                    }

                    // this.refresh();
                    w.value = null;
                    // this.city.get_items[0].va = this.country.cascadeValue[0];
                    return;
                })
            });


        }
        protected getQuickFilters() {
            var filters = super.getQuickFilters();
            let fld = Serene3.SpringPrintingConnection.TblXuatKhoChiTietRow.Fields;
            //alert(this.sMaLo);
            //if (this.sMaLo111 != undefined)
            //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
            //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;

            // alert(this.sMaLo);

            var MaloFilter = Q.first(filters, x => x.field == fld.MaPhieuXuat);
            MaloFilter.handler = h => {
                if ((h.value == "" || h.value == null) && this.sMaLo != undefined) {
                    h.request.EqualityFilter[fld.MaPhieuXuat] = this.sMaLo;// h.value;
                }
                else {
                    h.request.EqualityFilter[fld.MaPhieuXuat] = h.value;// h.value;
                }
                if (h.active) {
                    this.sMaLo = undefined;
                    h.request.EqualityFilter[fld.MaPhieuXuat] = h.value;// h.value;
                    this.sMaLo111 = h.value;
                }
                else {

                    if (this.sMaLo == undefined) {
                        h.request.EqualityFilter[fld.MaPhieuXuat] = null
                            ;
                        this.sMaLo111 = "";
                    }
                }
                this.sMaLo111 = h.value;
                // var values = (h.widget as Serenity.LookupEditor).values;

                //alert( h.value);
                if (this.sMaLo != undefined && (this.sMaLo111 == "" || this.sMaLo111 == null)) {
                    this.sMaLo111 = this.sMaLo;
                } 
                // alert(this.sMaLo111);
                //alert(this.sMaLo111);

            };
            return filters;

        }
    }
}