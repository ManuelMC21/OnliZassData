using onlizas.Shared.Entities;
using onlizas.Entities;
using System.ComponentModel.DataAnnotations;

namespace onlizas.Entities.Warehouse
{
    public abstract class Warehouse : BaseEntity
    {
        [Required, MaxLength(200)]
        public required string Name { get; set; }
        [Required]
        public WarehouseType Type { get; set; }
        public bool IsDeleted { get; set; } = false;
        // All warehouses (physical or virtual) have a Location
        public required int LocationId { get; set; }
        // keep navigation optional to simplify creation from endpoints (LocationId is authoritative)
        public Location? Location { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Transfer.Transfer>? TransfersOrigin { get; set; }
        public ICollection<Transfer.Transfer>? TransfersDestination { get; set; }
    }
}
