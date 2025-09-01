namespace onlizas.Services.ProductVariant;

public interface IProductVariantService
{
    Task<Entities.ProductVariant.ProductVariant> CreateAsync(Entities.ProductVariant.ProductVariant variant);
    Task<Entities.ProductVariant.ProductVariant> UpdateAsync(Entities.ProductVariant.ProductVariant variant);
    Task<bool> DeactivateAsync(int variantId);
    Task<List<Entities.ProductVariant.ProductVariant>> CreateManyAsync(List<Entities.ProductVariant.ProductVariant> variants);
}
