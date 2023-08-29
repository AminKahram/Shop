namespace ShopUI.Controllers; 

public class BasketController : Controller
{
    private readonly IProductRepository productRepository;
     
    public BasketController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public IActionResult Index(string returnUrl)
    {
        var basket = GetBasket();
        BasketViewModel viewModel = new BasketViewModel
        { 
            Basket = basket,
            ReturnUrl = returnUrl
        };
        return View(viewModel);
    }
    public IActionResult AddToBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetProductById(productId);
        var basket = GetBasket();
        basket.Add(product, 1);
        SaveBasket(basket);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }

    

    public IActionResult RemoveFromBasket(int productId)
    {
        var product = productRepository.GetProductById(productId).Id;
        var basket = GetBasket();
        basket.Remove(product);
        SaveBasket(basket); 
        return RedirectToAction("Index");
    }
    private Basket GetBasket()
    {
       return HttpContext.Session.GetJson<Basket>("Basket");
    }
    private void SaveBasket(Basket basket)
    {
        HttpContext.Session.SetJson("Basket", basket);
    }
}
