﻿namespace ShopUI.Models;

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
                TotalCount = _dbContext.products.Where(p => p.Category.Name == Category || string.IsNullOrWhiteSpace(Category)).Count()
            },
            Data = _dbContext.products.Where(p => p.Category.Name == Category || string.IsNullOrWhiteSpace(Category)).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList()
        };
        return result;
        
    }

    public Product GetProductById(int ProductId)
        => _dbContext.products.FirstOrDefault(prod => prod.Id == ProductId);

    
}
