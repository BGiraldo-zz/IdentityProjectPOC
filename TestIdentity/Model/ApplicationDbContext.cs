using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TestIdentity.Model
{
    public class ApplicationDbContext : IdentityDbContext<Contact, Role, int, ContactLogin, ContactRole, ContactClaim>
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext()
            : base("SQLConnString")
        {    
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Map Entities to their tables.
     /*       modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<ContactClaim>().ToTable("Contact_Claim");
            modelBuilder.Entity<ContactLogin>().ToTable("Contact_Login");
            modelBuilder.Entity<ContactRole>().ToTable("Role_Contact_Relation");
            // Set AutoIncrement-Properties
            modelBuilder.Entity<Contact>().Property(r => r.Id).HasColumnName("Contact_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ContactClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Role>().Property(r => r.Id).HasColumnName("Role_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Override some column mappings that do not match our default
            modelBuilder.Entity<Contact>().Property(r => r.UserName).HasColumnName("Login_ID");
            modelBuilder.Entity<Contact>().Property(r => r.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<Contact>().Property(r => r.PhoneNumber).HasColumnName("Telephone");
            modelBuilder.Entity<Role>().Property(r => r.Name).HasColumnName("Role_Name");
            modelBuilder.Entity<ContactClaim>().Property(r => r.UserId).HasColumnName("Contact_Id");
            modelBuilder.Entity<ContactLogin>().Property(r => r.UserId).HasColumnName("Contact_Id");
            modelBuilder.Entity<ContactRole>().Property(r => r.UserId).HasColumnName("Contact_Id");
            modelBuilder.Entity<ContactRole>().Property(r => r.RoleId).HasColumnName("Role_Id");*/
        }
    }
}
