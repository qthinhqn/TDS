
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblBoBtpGrid extends Serenity.EntityGrid<TblBoBtpRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblBoBtp'; }
        protected getDialogType() { return TblBoBtpDialog; }
        protected getIdProperty() { return TblBoBtpRow.idProperty; }
        protected getLocalTextPrefix() { return TblBoBtpRow.localTextPrefix; }
        protected getService() { return TblBoBtpService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblBoBtpService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblBoBtp:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
        private month: Serenity.StringEditor;
        // private country: Serenity.StringEditor;
        private sMaLo: string;
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
                    if (!(Authorization.hasPermission("Serene3:TblBoBtp:Modify")))
                    {
                        alert(Q.text("Controls.NotPermission"));
                        return;
                    }
                    //alert(this.sMaLo111);
                    if (this.sMaLo111 != "" && this.sMaLo111 != undefined) {
                      //  alert("kkkkk");
                        TblBoBtpService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaLo: this.sMaLo111 //this.country.value.toString()
                            },
                            response => {
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                this.sMaLo = response.toString();
                                
                                this.refresh();
                            });
                    }
                    else
                    {
                        //alert("kkkkk");
                        TblBoBtpService.GetData(
                            {
                                Note: w.value.toString(),//.toString()
                                MaLo: this.sMaLo //this.country.value.toString()
                            },
                            response => {
                                //this.form.Days.value = parseFloat(response.toString());
                                //this.country.value = response.toString();
                                this.sMaLo = response.toString();
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
            let fld = Serene3.SpringPrintingConnection.TblBoBtpRow.Fields;
            //alert(this.sMaLo);
            //if (this.sMaLo111 != undefined)
            //    Q.first(filters, x => x.field == fld.MaLo).init = w => {
            //        (w as Serenity.IntegerEditor).value = parseInt(this.sMaLo111);// this.sMaLo;
          

           
                var MaloFilter = Q.first(filters, x => x.field == fld.MaLo);
                MaloFilter.handler = h => {
               
                    if ((h.value == "" || h.value == null) && this.sMaLo != undefined) {
                  
                        h.request.EqualityFilter[fld.MaLo] = this.sMaLo;// h.value;
                    }
                    else {
                        h.request.EqualityFilter[fld.MaLo] = h.value;// h.value;
                    }
                    if (h.active) {
                        this.sMaLo = undefined;
                        h.request.EqualityFilter[fld.MaLo] = h.value;// h.value;
                        this.sMaLo111 = h.value;
                    }
                    else {
           
                        if (this.sMaLo == undefined) {
                            h.request.EqualityFilter[fld.MaLo] = null
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