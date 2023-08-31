namespace ShopUI.Components;

public class CategorySideBoxViewComponent: ViewComponent
{
    private readonly ICategoryRepository categoryRepository;

    public CategorySideBoxViewComponent(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }
    public IViewComponentResult Invoke()  
    {
        var CurrentCategory = RouteData?.Values["Category"];
        ViewBag.Category = CurrentCategory;
        return View(categoryRepository.GetCategories());
    }
}
