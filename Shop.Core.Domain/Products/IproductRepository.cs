namespace ShopUI.Models;

public interface IProductRepository
{
    PageData<Product> GetAll(ushort PageNumber, ushort PageSize, string Category);
    Product GetProductById(int ProductId);
}
