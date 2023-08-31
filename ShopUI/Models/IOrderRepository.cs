namespace ShopUI.Models;

public interface IOrderRepository
{
    void Save(Order order);
}
