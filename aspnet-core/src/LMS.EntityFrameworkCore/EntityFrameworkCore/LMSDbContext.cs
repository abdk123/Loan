using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.MultiTenancy;
using LMS.Loan.Indexes;
using LMS.Loan.Customers;
using LMS.Loan.Employees;

namespace LMS.EntityFrameworkCore
{
    public class LMSDbContext : AbpZeroDbContext<Tenant, Role, User, LMSDbContext>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public LMSDbContext(DbContextOptions<LMSDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
             .HasOne(x => x.User);
            builder.Entity<Customer>()
             .HasOne(x => x.Nationality);
            builder.Entity<Customer>()
             .HasOne(x => x.Country);

        }
    }
}
