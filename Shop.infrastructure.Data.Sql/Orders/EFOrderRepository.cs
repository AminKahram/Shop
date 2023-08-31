namespace ShopUI.Models;

public class EFOrderRepository : IOrderRepository
{
    private readonly StoreDBContext storeDB;

    public EFOrderRepository(StoreDBContext storeDB)
    {
        this.storeDB = storeDB;
    }

    public void Save(Order order)
    {
        storeDB.AttachRange(order.OrderDetails.Select(od => od.Product));
        storeDB.Orders.Add(order);
        storeDB.SaveChanges();
    }
}