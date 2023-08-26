using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ShopUI.Models;

namespace ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private ushort PageSize = 4;
        public HomeController(IProductRepository productRepository)
        {
                this._productRepository = productRepository;
        }
        public IActionResult Index(ushort PageNumber = 1)
        {
            return View(_productRepository.GetAll(PageNumber, PageSize));
        }
    }
}
