using onlizas.Data;

namespace onlizas.Services.ProductVariant;

public class ProductVariantService : IProductVariantService
{
    private readonly OnlizasDb _db;

    public ProductVariantService(OnlizasDb db)
    {
        _db = db;
    }

    public async Task<Entities.ProductVariant.ProductVariant> CreateAsync(Entities.ProductVariant.ProductVariant variant)
    {
        _db.ProductVariants.Add(variant);
        await _db.SaveChangesAsync();
        return variant;
    }

    public async Task<Entities.ProductVariant.ProductVariant> UpdateAsync(Entities.ProductVariant.ProductVariant variant)
    {
        _db.ProductVariants.Update(variant);
        await _db.SaveChangesAsync();
        return variant;
    }

    public async Task<bool> DeactivateAsync(int variantId)
    {
        var variant = await _db.ProductVariants.FindAsync(variantId);
        if (variant == null) return false;

        variant.IsActive = false;
        _db.ProductVariants.Update(variant);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<List<Entities.ProductVariant.ProductVariant>> CreateManyAsync(List<Entities.ProductVariant.ProductVariant> variants)
    {
        await _db.ProductVariants.AddRangeAsync(variants);
        await _db.SaveChangesAsync();
        return variants;
    }
}
