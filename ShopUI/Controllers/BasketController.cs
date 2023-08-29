using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopUI.Models;

namespace ShopUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductRepository productRepository;

        BasketController(IProductRepository productRepository)
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
            return RedirectToAction("Index", new { returnUrl = returnUrl});
        }

        

        public IActionResult RemoveFromBasket(int productId)
        {
            return RedirectToAction("Index");
        }
        private Basket GetBasket()
        {
            var basketString = HttpContext.Session.GetString("Basket");
            if (string.IsNullOrEmpty(basketString))
            {
                return new Basket();
            }
            return JsonConvert.DeserializeObject<Basket>(basketString);
        }
        private void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
        }
    }
}
