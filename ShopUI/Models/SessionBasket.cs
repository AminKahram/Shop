namespace ShopUI.Models;

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
 
