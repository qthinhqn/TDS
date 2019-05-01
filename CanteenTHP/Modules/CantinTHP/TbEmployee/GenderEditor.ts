namespace Canteen {

    @Serenity.Decorators.registerEditor()
    export class GenderEditor extends Serenity.Select2Editor<any, any> {
        constructor(hidden: JQuery) {
            super(hidden, null);
            this.addItem({ id: 'F', text: 'Nữ' });
            this.addItem({ id: 'M', text: 'Nam' });
        }
    }
}