namespace ShopUI.Models;
public class Basket
{
    private List<BasketItem> _items = new();
    public virtual void Add (Product product,ushort quantity)
    {
        var item = _items.Where(prod=>prod.Id == product.Id).FirstOrDefault();
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            _items.Add
                (
                    new BasketItem
                    {
                        Id = product.Id,
                        Quantity = quantity,
                        Product = product,
                    }
                );
        }
    }
    
    public virtual void Remove(int Productid)
        => _items.RemoveAll(prod => prod.Id == Productid);

    public int TotalPrice()
        => _items.Sum(pr => pr.Quantity * pr.Product.Price);

    public virtual void Clear()
        => _items.Clear();
    
    public IEnumerable<BasketItem> BasketItems => _items;
}
 
