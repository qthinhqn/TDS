/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDong_DieuChinhEditor extends Common.GridEditorBase<TblHopDong_DieuChinhRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblHopDong_DieuChinh"; }
        protected getDialogType() { return TblHopDong_DieuChinhDialog; }
        protected getLocalTextPrefix() { return TblHopDong_DieuChinhRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
            //this.form = new TblHopDong_DieuChinhForm(this.idPrefix);
           //alert( this.view.getLength());
        }
       
      //  protected getAddButtonCaption() { return "Add";}

        protected getButtons(): Serenity.ToolButton[] {

            // call base method to get list of buttons
            // by default, base entity grid adds a few buttons, 
            // add, refresh, column selection in order.
            var buttons = super.getButtons();

            // here is several methods to remove add button
            // only one is enabled, others are commented

            // METHOD 1
            // we would be able to simply return an empty button list,
            // but this would also remove all other buttons
            // return [];

            // METHOD 2
            // remove by splicing (something like delete by index)
            // here we hard code add button index (not nice!)
            // buttons.splice(0, 1);

            // METHOD 3 - recommended
            // remove by splicing, but this time find button index
            // by its css class. it is the best and safer method
            //buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            //alert('Test');
            return buttons;
        }

        validateEntity(row, id) {
         //  alert("Haaaaaa");
            //row.KeyId = Q.toId(row.KeyId);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaHd = row.MaHd);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This Contract is already in order details!');
            //    return false;
            //}
           // row.MaNvHoTen = TblNguoiDungRow.getLookup().itemById[row.MaNv].HoTen;
            var MaNv = Q.toId(row.MaNv);
            if (MaNv != null) {
                row.MaNvHoTen = TblNguoiDungRow.getLookup().itemById[row.MaNv].HoTen;
            }
            else {
                row.MaNvHoTen = null;
            }
            return true;
        }
    }
}