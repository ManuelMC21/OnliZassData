using Microsoft.EntityFrameworkCore;
using onlizas.Data;
using onlizas.Entities.StoreCategory;
using System.Text;

namespace onlizas.Services.StoreCategories;

public class CategoryStoreFillerServices : ICategoryStoreFillerServices
{
    private readonly OnlizasDb _db;

    public CategoryStoreFillerServices(OnlizasDb db)
    {
        _db = db;
    }

    public async Task FillerCategoriesStore(int storeId)
    {
        var log = new StringBuilder();
        

        var store = await _db.Stores
            .Include(s => s.Inventories)
            .Where(s => s.Id == storeId)
            .FirstOrDefaultAsync();

        if (store == null)
            throw new InvalidOperationException("La tienda no existe.");


        var productsId = store.Inventories.Select(i => i.ProductId).ToList();
 
        var categoryIds = await _db.Products
            .Where(p => productsId.Contains(p.Id))
            .Include(p => p.Categories)
            .SelectMany(p => p.Categories)
            .Select(pc => pc.CategoryId)
            .Distinct()
            .ToListAsync();


        var existingStoreCategories = await _db.StoreCategories
            .Where(sc => sc.StoreId == storeId)
            .ToListAsync();
      
        _db.StoreCategories.RemoveRange(existingStoreCategories);

        int order = 1;
        foreach (var categoryId in categoryIds)
        {
            var storeCategory = new StoreCategory
            {
                StoreId = store.Id,
                CategoryId = categoryId,
                IsActive = true,
                Order = order++
            };
            _db.StoreCategories.Add(storeCategory);
        }

        await _db.SaveChangesAsync();
    }
}
