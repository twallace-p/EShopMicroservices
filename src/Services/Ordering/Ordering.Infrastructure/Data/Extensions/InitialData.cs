namespace Ordering.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("ae097d36-7fd6-4993-8c40-ad5c71c1a41b")),"smith", "smith@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("55663cb7-7ce1-4480-b7ac-d07ff3328256")),"john", "john@gmail.com")
    };

    public static IEnumerable<Product> Products =>
    new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("3523b065-bbe5-436e-9986-463c03112ac6")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("f579d798-af9b-4ad7-8025-81a568d52d38")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("757a0766-7fef-493c-a94f-08d79ff8a7c4")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("502746bc-ede0-4347-ab92-bb57bef68a6e")), "Xiaomi Mi", 450)
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("john", "smith", "john@gmail.com", "55555 Street Ln", "USA", "Texas", "11111");
            var address2 = Address.Of("jane", "doe", "jane@gmail.com", "234 Number Ln", "USA", "Arizona", "22222");

            var payment1 = Payment.Of("John Smith", "33334444555566667777", "12/29", "234", 1);
            var payment2 = Payment.Of("Jane Doe", "1111222233334444", "01/30", "876", 2);


            var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("ae097d36-7fd6-4993-8c40-ad5c71c1a41b")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1
                );
            
            order1.Add(ProductId.Of(new Guid("3523b065-bbe5-436e-9986-463c03112ac6")), 2, 500);
            order1.Add(ProductId.Of(new Guid("f579d798-af9b-4ad7-8025-81a568d52d38")), 1, 400);

            var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("55663cb7-7ce1-4480-b7ac-d07ff3328256")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2
                );

            order2.Add(ProductId.Of(new Guid("757a0766-7fef-493c-a94f-08d79ff8a7c4")), 1, 650);
            order2.Add(ProductId.Of(new Guid("502746bc-ede0-4347-ab92-bb57bef68a6e")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}