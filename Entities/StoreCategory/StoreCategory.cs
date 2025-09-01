using onlizas.Shared.Entities;

namespace onlizas.Entities.StoreCategory;

public class StoreCategory : BaseEntity
{
    public int StoreId { get; set; }
    public Entities.Store.Store? Store { get; set;}
    public int CategoryId { get; set; }
    public Entities.Category? Category { get; set; }
    public bool IsActive { get; set; }
    public int Order { get; set; }
}
