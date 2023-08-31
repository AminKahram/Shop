namespace ShopUI.Models;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly StoreDBContext storeDB;

    public EFCategoryRepository(StoreDBContext storeDB)
    {
        this.storeDB = storeDB;
    }
    public List<string> GetCategories()
        => storeDB.Categories.Select(c => c.Name).ToList();
}