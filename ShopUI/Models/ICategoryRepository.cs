namespace ShopUI.Models;

public interface ICategoryRepository
{
    List<string> GetCategories();
}