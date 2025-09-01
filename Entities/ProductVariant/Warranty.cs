namespace onlizas.Entities.ProductVariant;

public class Warranty
{
    public int? Id { get; set; }
    public bool IsWarranty { get; set; }
    public decimal WarrantyPrice { get; set; } 
    public int WarrantyTime { get; set; } //Tiempo en dias
}
