using onlizas.Entities.Warehouse;

namespace onlizas.Entities.Warehouse
{
    public class PhysicalWarehouse : Warehouse
    {
        public decimal? Capacity { get; set; }
        public string? CapacityUnit { get; set; }
    }
}