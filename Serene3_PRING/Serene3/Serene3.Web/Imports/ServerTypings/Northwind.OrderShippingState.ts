namespace Serene3.Northwind {
    export enum OrderShippingState {
        NotShipped = 0,
        Shipped = 1
    }
    Serenity.Decorators.registerEnumType(OrderShippingState, 'Serene3.Northwind.OrderShippingState', 'Northwind.OrderShippingState');
}

