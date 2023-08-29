namespace ShopUI.Models
{
    public interface IProductRepository
    {
        PageData<Product> GetAll(ushort PageNumber, ushort PageSize, string Category);
        List<string> GetCategories();
        Product GetProductById(int ProductId);
    }
    public class EFProductRepository : IProductRepository
    {
        private StoreDBContext _dbContext;
        public EFProductRepository(StoreDBContext storeDB) 
        {
            this._dbContext = storeDB;
        }
        public PageData<Product> GetAll(ushort PageNumber, ushort PageSize, string Category)
        {
            var result = new PageData<Product>
            {
                pageInfo = new PageInfo
                {
                    PageNumber = PageNumber,
                    PageSize = PageSize,
                    TotalCount = _dbContext.products.Where(p => p.Category == Category || string.IsNullOrWhiteSpace(Category)).Count()
                },
                Data = _dbContext.products.Where(p => p.Category==Category || string.IsNullOrWhiteSpace(Category)).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
            };
            return result;
            
        }
        public List<string> GetCategories() =>
            _dbContext.products.Select(p => p.Category).Distinct().ToList();

        public Product GetProductById(int ProductId)
            => _dbContext.products.FirstOrDefault(prod => prod.Id == ProductId);

        
    }
}
