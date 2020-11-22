using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.MultiTenancy;
using LMS.Loan.Indexes;

namespace LMS.EntityFrameworkCore
{
    public class LMSDbContext : AbpZeroDbContext<Tenant, Role, User, LMSDbContext>
    {
        public DbSet<Country> Countries { get; set; }
        
        public LMSDbContext(DbContextOptions<LMSDbContext> options)
            : base(options)
        {
        }
    }
}
