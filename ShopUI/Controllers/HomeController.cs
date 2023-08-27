using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ShopUI.Models;

namespace ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private ushort PageSize = 2;
        public HomeController(IProductRepository productRepository)
        {
                this._productRepository = productRepository;
        }
        public IActionResult Index(string Category = "", ushort PageNumber = 1)
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel
            {
                ProductPageData = _productRepository.GetAll(PageNumber, PageSize, Category),
                Category = Category
            };
            return View(viewModel);
        }
    }
}
