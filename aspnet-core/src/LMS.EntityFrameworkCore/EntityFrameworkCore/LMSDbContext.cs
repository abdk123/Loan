using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.MultiTenancy;

namespace LMS.EntityFrameworkCore
{
    public class LMSDbContext : AbpZeroDbContext<Tenant, Role, User, LMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LMSDbContext(DbContextOptions<LMSDbContext> options)
            : base(options)
        {
        }
    }
}
