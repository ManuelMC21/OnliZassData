using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlizas.Entities.Transfer
{
    public class TransferItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransferId { get; set; }
        public Transfer? Transfer { get; set; }

        [Required]
        public int ProductVariantId { get; set; }
        public ProductVariant.ProductVariant? ProductVariant { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal QuantityRequested { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal QuantityTransferred { get; set; } = 0m;

        public string? Unit { get; set; }
        
        /// <summary>
        /// Si es true, permite completar la cantidad solicitada usando otras variantes del mismo producto (FIFO).
        /// Si es false, solo usa la variante específica solicitada.
        /// </summary>
        public bool AllowPartialFulfillment { get; set; } = true;

        public ICollection<TransferItemAllocation> Allocations { get; set; }
    }
}
