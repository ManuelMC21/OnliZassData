
using System.ComponentModel.DataAnnotations;
using onlizas.Entities.ProductVariant;
using onlizas.Entities.Transfer;
using onlizas.Entities.Warehouse;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Movement
{
    public class Movement : BaseEntity
    {
        [Required]
        public int ProductVariantId { get; set; }
        public ProductVariant.ProductVariant ProductVariant { get; set; } = null!;

        public int? FromWarehouseId { get; set; }
        public Warehouse.Warehouse? FromWarehouse { get; set; }

        public int ToWarehouseId { get; set; }
        public Warehouse.Warehouse ToWarehouse { get; set; } = null!;

        public int TransferOrderId { get; set; }
        public Transfer.Transfer TransferOrder { get; set; } = null!;
        public decimal Quantity { get; set; }
        public MovementType MovementType { get; set; }

        public decimal StockBefore { get; set; }
        public decimal StockAfter { get; set; }
    }
}