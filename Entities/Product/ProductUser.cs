using onlizas.Entities.Users;

namespace onlizas.Entities.Product;

public class ProductUser
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
