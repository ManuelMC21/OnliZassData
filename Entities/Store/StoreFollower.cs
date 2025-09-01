using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Store;

public class StoreFollower : BaseEntity
{
    public int StoreId { get; set; }
    public int UserId { get; set; }

    // Navegaciones
    public Store Store { get; set; }
    public User User { get; set; }
}
