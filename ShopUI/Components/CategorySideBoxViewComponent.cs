namespace ShopUI.Components;

public class CategorySideBoxViewComponent: ViewComponent
{
    private readonly IProductRepository productRepository;

    public CategorySideBoxViewComponent(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public IViewComponentResult Invoke()  
    {
        var CurrentCategory = RouteData?.Values["Category"];
        ViewBag.Category = CurrentCategory;
        return View(productRepository.GetCategories());
    }
}
