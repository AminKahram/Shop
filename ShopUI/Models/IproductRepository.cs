namespace ShopUI.Models
{
    public interface IProductRepository
    {
        PageData<Product> GetAll(ushort PageNumber, ushort PageSize);
    }
    public class EFProductRepository : IProductRepository
    {
        private StoreDBContext _dbContext;
        public EFProductRepository(StoreDBContext storeDB) 
        {
            this._dbContext = storeDB;
        }
        public PageData<Product> GetAll(ushort PageNumber, ushort PageSize)
        {
            var result = new PageData<Product>
            {
                pageInfo = new PageInfo
                {
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                    TotalCount = _dbContext.products.Count()
                },
                Data = _dbContext.products.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            };
            return result;
            
        }
    }
}
