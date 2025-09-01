using System.ComponentModel.DataAnnotations;
using onlizas.Shared.Entities;
namespace onlizas.Entities.Warehouse
{
    public class VirtualWarehouseType : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public required string Name { get; set; }
        public string? DefaultRules { get; set; }
        public ICollection<VirtualWarehouse>? VirtualWarehouses { get; set; }
    }
}