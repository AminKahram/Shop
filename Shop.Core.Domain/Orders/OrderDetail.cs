namespace ShopUI.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public ushort Quantity { get; set; }
}
