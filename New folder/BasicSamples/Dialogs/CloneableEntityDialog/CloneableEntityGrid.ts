/// <reference path="../../../Northwind/Product/ProductGrid.ts" />

namespace COCOSIN_ERP.BasicSamples {

    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    @Serenity.Decorators.registerClass()
    export class CloneableEntityGrid extends Northwind.ProductGrid {

        protected getDialogType() { return CloneableEntityDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}