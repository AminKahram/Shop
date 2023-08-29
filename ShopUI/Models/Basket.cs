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
public class SessionBasket:Basket
{
    private ISession _session;
    public static SessionBasket GetBasket(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
        SessionBasket sessionBasket = session.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
        sessionBasket._session = session;
        return sessionBasket; 
    }
    public override void Add(Product product, ushort quantity)
    {
        base.Add(product, quantity);
        _session.SetJson("Basket", this);
    }
    public override void Remove(int Productid)
    {
        base.Remove(Productid);
        _session.SetJson("Basket", this);
    }
    public override void Clear()
    {
        base.Clear();
        _session.Remove("Basket");
    }
}
public class BasketItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public ushort Quantity { get; set; }
}
 
