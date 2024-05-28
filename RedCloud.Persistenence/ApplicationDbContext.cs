using Microsoft.EntityFrameworkCore;
using RedCloud.Application.Contract;
using RedCloud.Domain.Entities;

using System.Data;

namespace RedCloud.Persistenence
{
    public class ApplicationDbContext: DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<ResellerAdmin> ReSellerAdmins { get; set; }

        public DbSet<OrganizationAdmin> OrganizationAdmins { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AdminUser>().Property(a => a.CreatedDate).IsRequired();
            modelBuilder.Entity<AdminUser>().Property(a => a.CreatedBy).IsRequired(false);
            modelBuilder.Entity<AdminUser>().Property(a => a.ModifiedDate).IsRequired(false);
            modelBuilder.Entity<AdminUser>().Property(a => a.LastModifiedBy).IsRequired(false);
            modelBuilder.Entity<AdminUser>().Property(a => a.IsDeleted).HasDefaultValue(false);
        }
    }
}
