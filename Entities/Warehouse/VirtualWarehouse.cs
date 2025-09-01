using onlizas.Entities;
using onlizas.Entities.Users;

namespace onlizas.Entities.Warehouse
{
    public class VirtualWarehouse : Warehouse
    {
        public int? VirtualTypeId { get; set; }
        public VirtualWarehouseType? VirtualType { get; set; }
        public string? Rules { get; set; }

        // Virtual warehouse is associated to a supplier (Business)
        public int? SupplierId { get; set; }
        public User? Supplier { get; set; }
    }
}