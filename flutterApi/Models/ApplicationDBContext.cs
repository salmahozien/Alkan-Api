using flutterApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace login.Models
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
       // public DbSet<User> Users { get; set; }
        public DbSet<Car> cars{ get; set; }
        public DbSet<Accident> Accidents { get; set; }  
        
        public DbSet<Company> Companys { get; set; }    
        public DbSet<CompanyInfo> CompanyInfo { get; set; } 
        public DbSet<Policy> policies { get; set; }
        public DbSet<CompanyBenfits> companyBenfits { get; set; }   
        public DbSet<CarModel> carModels { get; set; }  
       public DbSet<CarInfo> carInfo { get; set; }
       // public DbSet<InsurancePrice> insurancePrices { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<PersonalImage> PersonalImages { get; set; }
        public DbSet<ImageAccidentDB> ImageDB { get; set; }
        public DbSet<personalImagesUrl>personalImagesUrls { get; set; } 
        public DbSet<PersonalImagesDB> personalImagesDB { get; set; }
        public DbSet<PreviewerReport> previewerReports { get; set; }
        public DbSet<ReportImageDb> reportImageDb { get; set; }
        public DbSet<InsuranceRequest> insuranceRequests { get; set; }
       public DbSet<MedicalCompany>medicalCompanies { get; set; }  
       public DbSet<CompanyHealthInsuranceTypes>compsnyHealthInsuranceTypes { get; set; }  
        public DbSet<PlaceOfTreatment>placeOfTreatments { get; set; }
       public DbSet<PlaceOfTreatmentDetails> PlaceOfTreatmentDetails { get; set; }
        public DbSet<typesMedicalDetails> typesMedicalDetails { get; set; }
        public DbSet<AgeLimits> ageLimits { get; set; } 
        public DbSet<MedicalInsurancePrice> medicalInsurancePrices { get; set; }
        public DbSet<MedicalPricingData>medicalPricingsData { get; set; }
        public DbSet<HomePrice> homePrices { get; set; }
        public DbSet<HomeCompany> HomeCompany { get; set; }
        public DbSet<HomeLimits> homeLimits { get; set; }
        public DbSet<PersonalAccidentCompany> PersonalAccidentCompanies { get; set; }
        public DbSet<PersonalAccidentLimit> PersonalAccidentLimit { get; set; }
        public DbSet<PersonalAccidentPrice> PersonalAccidentPrice { get; set; }



       //public DbSet<AuthModel> AuthModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");



            //    .Ignore(e => e.NormalizedUserName)
            //    .Ignore(e => e.NormalizedEmail)
            //    .Ignore(e => e.PasswordHash)
            //    .Ignore(e => e.UserName);
            //builder.Entity<User>().Ignore(e=>e.UserName);
            //builder.Entity<User>().Ignore(e => e.NormalizedUserName);



            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<typesMedicalDetails>()
.HasKey(relation => new
{
   relation.CompanyHealthInsuranceTypesId,
   relation.PlaceOfTreatmentDetailsId

});
        }
    }
}
