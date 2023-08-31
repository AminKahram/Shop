namespace ShopUI.Controllers; 

public class BasketController : Controller
{
    private readonly IProductRepository productRepository;
    private readonly Basket sessionBasket;

    public BasketController(IProductRepository productRepository, Basket sessionBasket)
    {
        this.productRepository = productRepository;
        this.sessionBasket = sessionBasket;
    }
    public IActionResult Index(string returnUrl)
    {
        BasketViewModel viewModel = new BasketViewModel
        { 
            Basket = sessionBasket,
            ReturnUrl = returnUrl
        };
        return View(viewModel);
    }
    public IActionResult AddToBasket(int productId, string returnUrl)
    {
        var product = productRepository.GetProductById(productId);
        sessionBasket.Add(product, 1);

        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }
    public IActionResult RemoveFromBasket(int productId)
    {
        var product = productRepository.GetProductById(productId).Id;
        sessionBasket.Remove(product);

        return RedirectToAction("Index");
    }
    
}
