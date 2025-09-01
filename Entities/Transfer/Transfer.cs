
using System.ComponentModel.DataAnnotations;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Transfer
{
    public class Transfer: BaseEntity
    {
        [Required, MaxLength(100)]
        public required string TransferNumber { get; set; }
        public int? OriginId { get; set; }
        public Warehouse.Warehouse? OriginWarehouse { get; set; }
        public int? DestinationId { get; set; }
        public Warehouse.Warehouse? DestinationWarehouse { get; set; }

        public TransferStatus Status { get; set; }

        public ICollection<TransferItem> Items { get; set; } = new List<TransferItem>();
        public ICollection<Movement.Movement> Movements { get; set; } = new List<Movement.Movement>();
    }
}
