namespace ShopUI.Components
{
    public class BasketSummeryViewComponent : ViewComponent
    {
        private readonly Basket basket;

        public BasketSummeryViewComponent(Basket basket)
        {
            this.basket = basket;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
