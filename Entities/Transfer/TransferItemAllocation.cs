using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlizas.Entities.Transfer
{
    public class TransferItemAllocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransferItemId { get; set; }
        public TransferItem? TransferItem { get; set; }

        [Required]
        public int ProductVariantId { get; set; }
        public ProductVariant.ProductVariant? ProductVariant { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }
    }
}