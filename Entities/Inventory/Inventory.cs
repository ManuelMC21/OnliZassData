using onlizas.Entities.Product;
using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public enum InventoryState
{
    Active = 1,
    Inactive = 2,
    Pending = 3
}

public class Inventory : BaseEntity
{
    public int ProductId { get; set; }
    public Product.Product Product { get; set; }
    public List<ProductVariant.ProductVariant> Products { get; set; } = new();

    public int StoreId { get; set; }
    public Store.Store Store { get; set; }

    public int SupplierId { get; set; }
    public User Supplier { get; set; }

    public int? WarehouseId { get; set; }
    public Warehouse.Warehouse? Warehouse { get; set; }

    public decimal TotalPrice { get; set; }

    public InventoryState State { get; set; } = InventoryState.Active;

    //Propiedad Navegacion para rese�as
    public virtual ICollection<Review.Review> Reviews { get; set; } = new List<Review.Review>();
}