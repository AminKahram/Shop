using Microsoft.AspNetCore.Mvc;
using ShopUI.Models;

namespace ShopUI.Components
{
    public class CategorySideBoxViewComponent: ViewComponent
    {
        private readonly IProductRepository productRepository;

        public CategorySideBoxViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(productRepository.GetCategories());
        }
    }
}
 