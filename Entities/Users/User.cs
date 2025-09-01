using onlizas.Entities.MfaMethods;
using onlizas.Entities.Product;
using onlizas.Entities.Review;
using onlizas.Entities.Warehouse;
using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities.Users;

public class User : BaseEntity
{
    public Guid GlobalId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Password { get; set; }


    public ICollection<Email> Emails { get; set; } = new List<Email>();
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    public required bool IsBlocked { get; set; }
    public required bool IsVerified { get; set; }

    public ICollection<VirtualWarehouse>? Warehouses {get;set;}

    public required string? PhotoObjectCode { get; set; }
    public required UserApiRole ApiRole { get; set; }
    public JsonDocument? Attributes { get; set; }
    public ICollection<Business> Businesses { get; set; } = new List<Business>();

    public int? BenefactorId { get; set; }
    public User? Benefactor { get; set; }
    public int? ApprovalProcessId { get; set; }
    public ApprovalProcess? ApprovalProcess { get; set; }
    public ICollection<User> Beneficiaries { get; set; } = new List<User>();
    public ICollection<UserDocument> Documents { get; set; } = new List<UserDocument>();
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    public ICollection<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();
    public ICollection<ResetCode> ResetCodes { get; set; } = new List<ResetCode>();
    public ICollection<UserAttributeLog> ChangedAttributeLogs { get; set; } = new List<UserAttributeLog>();
    public ICollection<UserAttributeLog> ChangerAttributeLogs { get; set; } = new List<UserAttributeLog>();
    public ICollection<MfaMethod> MfaMethods { get; set; } = new List<MfaMethod>();
    public ICollection<MfaBackupCode> MfaBackupCodes { get; set; } = new List<MfaBackupCode>();
    public ICollection<Business> OwnedBusinesses { get; set; } = new List<Business>();
    public ICollection<ProductUser>? OwnerProducts { get; set; } = new List<ProductUser>();
    public ICollection<Review.Review> Reviews { get; set; } = new List<Review.Review>();
    public bool? NeedChangePassword { get; set; } = false;

    public bool BenefactorSincronized { get; set; } = true;

    public ICollection<Guid>NotSyncRoles { get; set; }= new List<Guid>();

    public ICollection<Guid>NotSyncBeneficiaries { get; set; }= new List<Guid>();

    public ICollection<int>NotSyncBusiness { get; set; }= new List<int>();
    
    public Guid? BenefactorGuid { get; set; }

    public bool Inaccessible { get; set; } = false;
    
}