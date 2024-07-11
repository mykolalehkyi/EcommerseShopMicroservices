namespace Ordering.Infrastructure.Data.Extensions
{
    public static class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>()
        {
            Customer.Create(CustomerId.Of(new Guid("813d9866-350c-4bdc-8e42-237dbebef061")),"mehmet", "mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("16ce6923-c5c7-4f0b-8bed-1849090e3e72")),"john", "john@gmail.com")
        };

        public static IEnumerable<Product> Products => new List<Product>()
        {
            Product.Create(ProductId.Of(new Guid("febee94c-34ac-4fdd-83dd-a4c5a805cb36")),"Iphone X", 500),
            Product.Create(ProductId.Of(new Guid("64e9a6c0-257c-4fb6-b17e-cf5830bc71f1")),"Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("ddfa0937-65eb-44af-bf6f-9dd9e004b185")),"Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("68e5500c-1e04-44e9-9731-746536077b6f")),"Xiaomi Mi", 450),
        };

        public static IEnumerable<Order> OrdersWithItems { get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Batcheliver No:4", "Turkey", "Istanbul", "38050");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingam", "08050");

                var payment1 = Payment.Of("mehmet", "1111222233334444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "5555666677778888", "06/30", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("813d9866-350c-4bdc-8e42-237dbebef061")),
                    OrderName.Of("Order 1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1
                    );

                order1.Add(ProductId.Of(new Guid("febee94c-34ac-4fdd-83dd-a4c5a805cb36")), 2, 500);
                order1.Add(ProductId.Of(new Guid("64e9a6c0-257c-4fb6-b17e-cf5830bc71f1")), 1, 400);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("16ce6923-c5c7-4f0b-8bed-1849090e3e72")),
                    OrderName.Of("Order 2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2
                    );

                order2.Add(ProductId.Of(new Guid("ddfa0937-65eb-44af-bf6f-9dd9e004b185")), 1, 650);
                order2.Add(ProductId.Of(new Guid("68e5500c-1e04-44e9-9731-746536077b6f")), 2, 450);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
