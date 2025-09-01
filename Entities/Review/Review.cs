using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Review;

public class Review : BaseEntity
{
    public int Score { get; set; }
    public int UserId { get; set; }
    public int InventoryId { get; set; }
    public string Message { get; set; } = string.Empty;

    public ICollection<ReviewImage> Media { get; set; } = new List<ReviewImage>();

    // Propiedades de navegación
    public virtual User? User { get; set; }
    public virtual Inventory? Inventory { get; set; }
}
