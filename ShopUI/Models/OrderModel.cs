namespace ShopUI.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}
public class OrderDetail
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public ushort Quantity { get; set; }
}
