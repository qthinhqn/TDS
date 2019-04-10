
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblLenChuyenInChiTietGrid extends Serenity.EntityGrid<TblLenChuyenInChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblLenChuyenInChiTiet'; }
        protected getDialogType() { return TblLenChuyenInChiTietDialog; }
        protected getIdProperty() { return TblLenChuyenInChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenInChiTietRow.localTextPrefix; }
        protected getService() { return TblLenChuyenInChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
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
                    if (!(Authorization.hasPermission("Serene3:TblLenChuyenInChiTiet:Modify"))) {
                        alert(Q.text("Controls.NotPermission"));
                        return;
                    }
                    if (this.sMaLo111 != "" && this.sMaLo111 != undefined) {
                        TblLenChuyenInChiTietService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaLenChuyen: this.sMaLo111
                            },
                            
                            response => {
                               // alert(response.KeyID); alert(response.ErrorCode);
                                this.sMaLo = response.KeyID.toString();
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                this.refresh();
                            });
                    }
                    else
                    {
                        TblLenChuyenInChiTietService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaLenChuyen: this.sMaLo
                            },
                            response => {
                                //alert(response.KeyID); alert(response.ErrorCode);
                                this.sMaLo = response.KeyID.toString();
                                this.sMaLo111 = this.sMaLo;
                                //alert(response.toString());
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
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
            let fld = Serene3.SpringPrintingConnection.TblLenChuyenInChiTietRow.Fields;
            //alert(this.sMaLo);
            //if (this.sMaLo111 != undefined)
            //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
            //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;

            // alert(this.sMaLo);

            var MaloFilter = Q.first(filters, x => x.field == fld.MaLenChuyen);
            MaloFilter.handler = h => {
                if ((h.value == "" || h.value == null) && this.sMaLo != undefined) {
                    h.request.EqualityFilter[fld.MaLenChuyen] = this.sMaLo;// h.value;
                }
                else {
                    h.request.EqualityFilter[fld.MaLenChuyen] = h.value;// h.value;
                }
                if (h.active) {
                    this.sMaLo = undefined;
                    h.request.EqualityFilter[fld.MaLenChuyen] = h.value;// h.value;
                    this.sMaLo111 = h.value;
                }
                else {

                    if (this.sMaLo == undefined) {
                        h.request.EqualityFilter[fld.MaLenChuyen] = null
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