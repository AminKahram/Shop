namespace ShopUI.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll(ushort PageNumber, ushort PageSize);
    }
    public class EFProductRepository : IProductRepository
    {
        private StoreDBContext _dbContext;
        public EFProductRepository(StoreDBContext storeDB) 
        {
            this._dbContext = storeDB;
        }
        public List<Product> GetAll(ushort PageNumber, ushort PageSize)
        {
            return _dbContext.products.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
