using Microsoft.EntityFrameworkCore;
using onlizas.Entities;
using onlizas.Entities.Trace;
using onlizas.Entities.Users;
using onlizas.Entities.Permissions;
using onlizas.Entities.MfaMethods;
using onlizas.Entities.Store;
using onlizas.Entities.Banner;
using onlizas.Entities.Warehouse;
using onlizas.Entities.ProductVariant;
using onlizas.Entities.Product;
using onlizas.Entities.Transfer;
using onlizas.Entities.Movement;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using onlizas.Entities.Review;
using onlizas.Utils.Converters;
using onlizas.Entities.StoreCategory;
using onlizas.Entities.Promotion;
using BCrypt.Net;

namespace onlizas.Data;

public class AppDbContext : DbContext
{

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CategoryFeature> CategoryFeatures => Set<CategoryFeature>();
    public DbSet<Feature> Features => Set<Feature>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Email> Emails => Set<Email>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<UserDocument> UserDocuments => Set<UserDocument>();
    public DbSet<User> Users { get; set; }
    public DbSet<ApprovalProcess> ApprovalProcesses { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewImage> ReviewImages { get; set; }
    public DbSet<StoreFollower> StoreFollowers { get; set; }
    public DbSet<StoreCategory> StoreCategories { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionProduct> PromotionProducts { get; set; }
    public DbSet<PromotionCategory> PromotionCategories { get; set; }
    public DbSet<ApprovalProcessApprovedCategory> ApprovalProcessApprovedCategories { get; set; } = null!;
    public DbSet<ApprovalProcessRequestedCategory> ApprovalProcessRequestedCategories { get; set; } = null!;

    #region Productos
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<ProductUser> ProductUsers { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    #endregion

    #region Logs
    public DbSet<CurrencyLog> CurrencyLogs { get; set; }
    public DbSet<CategoryLog> CategoryLogs { get; set; }
    public DbSet<DocumentLog> DocumentLogs { get; set; }
    public DbSet<BusinessLog> BusinessLogs { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }
    public DbSet<RoleLog> RoleLogs { get; set; }
    public DbSet<DepartmentLog> DepartmentLogs { get; set; }
    public DbSet<PermissionLog> PermissionLogs { get; set; }
    #endregion

    public DbSet<PhoneNumber> PhoneNumbers => Set<PhoneNumber>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<VerificationCode> VerificationCodes => Set<VerificationCode>();
    public DbSet<ResetCode> ResetCodes => Set<ResetCode>();
    public DbSet<UserAttributeLog> UserAttributeLogs => Set<UserAttributeLog>();
    public DbSet<MfaMethod> MfaMethods => Set<MfaMethod>();
    public DbSet<MfaBackupCode> MfaBackupCodes => Set<MfaBackupCode>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<PhysicalWarehouse> PhysicalWarehouses => Set<PhysicalWarehouse>();
    public DbSet<VirtualWarehouse> VirtualWarehouses => Set<VirtualWarehouse>();
    public DbSet<VirtualWarehouseType> VirtualWarehouseTypes => Set<VirtualWarehouseType>();
    public DbSet<Transfer> Transfers => Set<Transfer>();
    public DbSet<TransferItem> TransferItems => Set<TransferItem>();
    public DbSet<TransferItemAllocation> TransferItemAllocations => Set<TransferItemAllocation>();
    public DbSet<Movement> Movements => Set<Movement>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property<string>("Discriminator")
            .HasMaxLength(50)
            .HasDefaultValue("User")
            .IsRequired();

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Permissions)
            .WithOne(p => p.Role)
            .HasForeignKey(p => p.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubSystem>()
            .HasMany(ss => ss.Roles)
            .WithOne(r => r.SubSystem)
            .HasForeignKey(r => r.SubSystemId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasOne(s => s.Business)
                  .WithMany(b => b.Stores)
                  .HasForeignKey(s => s.BusinessId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(s => s.Banners)
                  .WithOne(b => b.Store)
                  .HasForeignKey(b => b.StoreId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(s => s.Followers)
                  .WithOne(sf => sf.Store)
                  .HasForeignKey(sf => sf.StoreId);
        });

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Categories)
            .WithOne(c => c.ParentDepartment)
            .HasForeignKey(c => c.DepartmentId);

        modelBuilder.Entity<CategoryFeature>()
            .HasIndex(cf => new { cf.CategoryId, cf.FeatureId })
            .IsUnique();

        modelBuilder.Entity<CategoryFeature>()
            .HasOne(cf => cf.Category)
            .WithMany(c => c.CategoryFeatures)
            .HasForeignKey(cf => cf.CategoryId);

        modelBuilder.Entity<CategoryFeature>()
            .HasOne(cf => cf.Feature)
            .WithMany(f => f.CategoryFeatures)
            .HasForeignKey(cf => cf.FeatureId);

        modelBuilder.Entity<Feature>()
            .Property(f => f.Suggestions)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()));

        #region Promocion
        modelBuilder.Entity<Promotion>()
            .HasMany(p => p.PromotionProducts)
            .WithOne(pp => pp.Promotion)
            .HasForeignKey(pp => pp.PromotionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Promotion>()
            .HasMany(p => p.PromotionCategories)
            .WithOne(pc => pc.Promotion)
            .HasForeignKey(pc => pc.PromotionId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Categorias de la tienda
        // Una tienda tiene muchas StoreCategory
        modelBuilder.Entity<Store>()
            .HasMany(s => s.StoreCategories)
            .WithOne(sc => sc.Store)
            .HasForeignKey(sc => sc.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        // Una categoría puede estar en muchas StoreCategory
        modelBuilder.Entity<Category>()
             .HasMany(c => c.StoreCategories)
             .WithOne(sc => sc.Category)
             .HasForeignKey(sc => sc.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);


        // Índice único para evitar duplicados de categoría por tienda
        modelBuilder.Entity<StoreCategory>()
            .HasIndex(sc => new { sc.StoreId, sc.CategoryId })
            .IsUnique();

        #endregion

        #region Reseña

        // Configuración de la relación: Review → User (muchos a uno)
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)           // Una reseña tiene un usuario
            .WithMany(u => u.Reviews)      // Un usuario tiene muchas reseñas
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
             .HasMany(r => r.Media)
             .WithOne()
             .HasForeignKey(ri => ri.ReviewId)
             .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReviewImage>()
             .ToTable("ReviewImages");

        // Configuración de la relación: Review → Store (muchos a uno)
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Inventory)          // Una reseña tiene una tienda
            .WithMany(s => s.Reviews)      // Una tienda tiene muchas reseñas
            .HasForeignKey(r => r.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Producto

        // Relación: Product → ProductVariants (1:N)
        // Una variante pertenece a un producto mediante ParentProduct
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductVariants)
            .WithOne(v => v.ParentProduct)
            .HasForeignKey(v => v.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductVariant>()
            .HasMany(p => p.Images)
            .WithOne() // No tiene propiedad inversa fuerte en ProductImage
            .HasForeignKey("ProductId")
            .OnDelete(DeleteBehavior.Cascade);

        // Relación muchos-a-muchos: Product ↔ User (proveedores)
        // Usando entidad intermedia ProductUser
        modelBuilder.Entity<ProductUser>()
            .HasKey(pu => new { pu.ProductId, pu.UserId });

        modelBuilder.Entity<ProductUser>()
            .HasOne(pu => pu.Product)
            .WithMany(p => p.SuppliersId) // Product tiene List<ProductUser> SuppliersId
            .HasForeignKey(pu => pu.ProductId);

        modelBuilder.Entity<ProductUser>()
            .HasOne(pu => pu.User)
            .WithMany(u => u.OwnerProducts) // User tiene List<ProductUser> OwnerProducts
            .HasForeignKey(pu => pu.UserId);

        // Relación muchos-a-muchos: Product ↔ Category
        // Usando entidad intermedia ProductCategory
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.Categories) // Product tiene List<ProductCategory> Categories
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.Products) // Category tiene List<ProductCategory> Products
            .HasForeignKey(pc => pc.CategoryId);

        // Propiedad: Product.Details → almacenado como JSON (jsonb en PostgreSQL)
        modelBuilder.Entity<Product>()
            .Property(p => p.Details)
            .HasConversion(
                v => v == null ? null : JsonSerializer.Serialize(v, GetSafeJsonOptions()),
                v => v == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(v, GetSafeJsonOptions())
            )
            .Metadata.SetValueComparer(new ValueComparer<Dictionary<string, string>?>(
                (d1, d2) =>
                    d1 == d2 ||
                    (d1 != null && d2 != null && d1.Count == d2.Count && !d1.Except(d2).Any()),
                d => d == null ? 0 : d.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
                d => d == null ? null : new Dictionary<string, string>(d)
            ));

        modelBuilder.Entity<ProductVariant>()
            .Property(p => p.Details)
            .HasConversion(
                v => v == null ? null : JsonSerializer.Serialize(v, GetSafeJsonOptions()),
                v => v == null ? null : JsonSerializer.Deserialize<Dictionary<string, string>>(v, GetSafeJsonOptions())
            )
            .Metadata.SetValueComparer(new ValueComparer<Dictionary<string, string>?>(
                (d1, d2) =>
                    d1 == d2 ||
                    (d1 != null && d2 != null && d1.Count == d2.Count && !d1.Except(d2).Any()),
                d => d == null ? 0 : d.Aggregate(0, (a, v) => HashCode.Combine(a, v.Key.GetHashCode(), v.Value.GetHashCode())),
                d => d == null ? null : new Dictionary<string, string>(d)
            ));

        // Conversión para AboutThis (List<string>) -> string almacenado; evita InvalidCastException
        modelBuilder.Entity<Product>()
            .Property(p => p.AboutThis)
            .HasConversion(
                v => v == null || v.Count == 0 ? string.Empty : string.Join("|", v),
                v => string.IsNullOrWhiteSpace(v) ? new List<string>() : v.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList()
            )
            .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                (c1, c2) => (c1 ?? new List<string>()).SequenceEqual(c2 ?? new List<string>()),
                c => (c ?? new List<string>()).Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c == null ? new List<string>() : c.ToList()
            ));
        #endregion

        #region Inventario

        // Inventory → ProductVariant (1:N)
        modelBuilder.Entity<Inventory>()
            .HasMany(i => i.Products)
            .WithOne(pv => pv.Inventory)
            .HasForeignKey(pv => pv.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // ProductVariant → ProductImage (1:N)
        modelBuilder.Entity<ProductVariant>()
            .HasMany(pv => pv.Images)
            .WithOne(img => img.Product)
            .HasForeignKey(img => img.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // Store → Inventory (1:N)
        modelBuilder.Entity<Store>()
            .HasMany(s => s.Inventories)
            .WithOne(i => i.Store)
            .HasForeignKey(i => i.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        // Inventory → User (N:1)
        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Supplier)
            .WithMany()
            .HasForeignKey(i => i.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Warehouse
        modelBuilder.Entity<Warehouse>()
            .HasDiscriminator<WarehouseType>("Type")
            .HasValue<PhysicalWarehouse>(WarehouseType.Physical)
            .HasValue<VirtualWarehouse>(WarehouseType.Virtual);

        modelBuilder.Entity<PhysicalWarehouse>()
            .HasOne(pw => pw.Location)
            .WithMany()
            .HasForeignKey(pw => pw.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VirtualWarehouse>()
            .HasOne(vw => vw.VirtualType)
            .WithMany(vwt => vwt.VirtualWarehouses)
            .HasForeignKey(vw => vw.VirtualTypeId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.Inventories)
            .WithOne(i => i.Warehouse)
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Warehouses)
            .WithOne(w => w.Supplier)
            .HasForeignKey(w => w.SupplierId)
            .OnDelete(DeleteBehavior.SetNull);

        #endregion

        #region Transfer
        modelBuilder.Entity<Transfer>()
            .HasMany(t => t.Items)
            .WithOne(ti => ti.Transfer)
            .HasForeignKey(ti => ti.TransferId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transfer>()
            .HasMany(t => t.Movements)
            .WithOne(m => m.TransferOrder)
            .HasForeignKey(m => m.TransferOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transfer>()
            .HasOne(t => t.OriginWarehouse)
            .WithMany(w => w.TransfersOrigin)
            .HasForeignKey(t => t.OriginId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Transfer>()
            .HasOne(t => t.DestinationWarehouse)
            .WithMany(w => w.TransfersDestination)
            .HasForeignKey(t => t.DestinationId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TransferItem>()
            .HasOne(ti => ti.ProductVariant)
            .WithMany()
            .HasForeignKey(ti => ti.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransferItem>()
            .HasMany(ti => ti.Allocations)
            .WithOne(tia => tia.TransferItem)
            .HasForeignKey(tia => tia.TransferItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TransferItemAllocation>()
            .HasOne(tia => tia.ProductVariant)
            .WithMany()
            .HasForeignKey(tia => tia.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Movement
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.ProductVariant)
            .WithMany()
            .HasForeignKey(m => m.ProductVariantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Movement>()
            .HasOne(m => m.FromWarehouse)
            .WithMany()
            .HasForeignKey(m => m.FromWarehouseId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Movement>()
            .HasOne(m => m.ToWarehouse)
            .WithMany()
            .HasForeignKey(m => m.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Movement>()
            .Property(m => m.Quantity)
            .HasColumnType("decimal(18,4)");

        modelBuilder.Entity<Movement>()
            .Property(m => m.StockBefore)
            .HasColumnType("decimal(18,4)");

        modelBuilder.Entity<Movement>()
            .Property(m => m.StockAfter)
            .HasColumnType("decimal(18,4)");
        #endregion

        modelBuilder.Entity<User>()
            .HasOne(u => u.ApprovalProcess)
            .WithOne(ap => ap.User)
            .HasForeignKey<ApprovalProcess>(ap => ap.UserId);

        modelBuilder.Entity<ApprovalProcess>()
            .HasOne(ap => ap.Country)
            .WithOne(c => c.ApprovalProcess)
            .HasForeignKey<Country>(c => c.ApprovalProcessId);

        modelBuilder.Entity<UserLog>()
           .HasOne(l => l.ChangedByUser)
           .WithMany()
           .HasForeignKey(l => l.ChangedById)
           .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Email>()
            .HasOne(e => e.User)
            .WithMany(u => u.Emails)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.PhoneNumbers)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Businesses)
            .WithMany(b => b.Users);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Sessions)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.VerificationCodes)
            .WithOne(vc => vc.User)
            .HasForeignKey(vc => vc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Documents)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ResetCodes)
            .WithOne(rc => rc.User)
            .HasForeignKey(rc => rc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ChangedAttributeLogs)
            .WithOne(log => log.ChangedUser)
            .HasForeignKey(log => log.ChangedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ChangerAttributeLogs)
            .WithOne(log => log.ChangerUser)
            .HasForeignKey(log => log.ChangerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.MfaMethods)
            .WithOne(mfa => mfa.User)
            .HasForeignKey(mfa => mfa.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.MfaBackupCodes)
            .WithOne(bc => bc.User)
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.OwnedBusinesses)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Benefactor)
            .WithMany(u => u.Beneficiaries)
            .HasForeignKey(u => u.BenefactorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductImage>()
            .HasIndex(pi => new { pi.ProductId, pi.Order })
            .IsUnique();

        modelBuilder.Entity<Document>()
            .HasOne(d => d.ApprovalProcess)
            .WithMany(p => p.ApprovedDocuments!)
            .HasForeignKey(d => d.ApprovalProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.ExtensionApprovalProcess)
            .WithMany(p => p.ExtensionDocuments!)
            .HasForeignKey(d => d.ExtensionApprovalProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ApprovalProcessApprovedCategory>()
            .HasKey(x => new { x.ApprovalProcessId, x.CategoryId });

        modelBuilder.Entity<ApprovalProcessApprovedCategory>()
            .HasOne(x => x.ApprovalProcess)
            .WithMany(p => p.ApprovedCategories)
            .HasForeignKey(x => x.ApprovalProcessId);

        modelBuilder.Entity<ApprovalProcessApprovedCategory>()
            .HasOne(x => x.Category)
            .WithMany(c => c.ApprovedInProcesses)
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<ApprovalProcessRequestedCategory>()
            .HasKey(x => new { x.ApprovalProcessId, x.CategoryId });

        modelBuilder.Entity<ApprovalProcessRequestedCategory>()
            .HasOne(x => x.ApprovalProcess)
            .WithMany(p => p.RequestedCategories)
            .HasForeignKey(x => x.ApprovalProcessId);

        modelBuilder.Entity<ApprovalProcessRequestedCategory>()
            .HasOne(x => x.Category)
            .WithMany(c => c.RequestedInProcesses)
            .HasForeignKey(x => x.CategoryId);

        // Filtros globales (soft delete) descomentados si los necesitas
        /*
        modelBuilder.Entity<Role>()
            .HasQueryFilter(r => r.IsActive);

        modelBuilder.Entity<onlizas.Entities.Users.User>()
            .HasQueryFilter(u => u.IsActive);
        */
    }

    private static JsonSerializerOptions GetSafeJsonOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
        options.Converters.Add(new SafeDictionaryJsonConverter());
        return options;
    }
}
