using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LMS.Authorization.Roles;
using LMS.Authorization.Users;
using LMS.MultiTenancy;
using LMS.Loan.Indexes;
using LMS.Loan.Customers;
using LMS.Loan.Employees;
using LMS.Loan.Agents;
using LMS.Loan.Banks;
using LMS.Loan.Cases;
using LMS.Loan.Workflows;

namespace LMS.EntityFrameworkCore
{
    public class LMSDbContext : AbpZeroDbContext<Tenant, Role, User, LMSDbContext>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CaseStatus> CaseStatuses { get; set; }
        public DbSet<BankCode> BankCodes { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<WorkflowSetting> WorkflowSettings { get; set; }
        public DbSet<WorkflowItem> WorkflowItems { get; set; }
        public DbSet<WorkflowApproval> WorkflowApprovals { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
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
            builder.Entity<Agent>()
             .HasOne(x => x.Country);
            builder.Entity<Bank>()
             .HasOne(x => x.Country);
            builder.Entity<BankCode>()
             .HasOne(x => x.Bank)
             .WithMany(x=> x.Codes);
            builder.Entity<BankCode>()
             .HasOne(x => x.CaseStatus);
            builder.Entity<WorkflowApproval>()
            .HasOne(x => x.WorkflowSetting)
            .WithMany(x => x.WorkflowApprovals);
            builder.Entity<WorkflowApproval>()
            .HasOne(x => x.User);
            builder.Entity<WorkflowSetting>()
             .HasOne(x => x.CaseStatus);
            builder.Entity<WorkflowStep>()
            .HasOne(x => x.WorkflowItem)
            .WithMany(x => x.WorkflowSteps);
            builder.Entity<WorkflowStep>()
            .HasOne(x => x.Employee);
            builder.Entity<WorkflowItem>()
             .HasOne(x => x.WorkflowSetting);

        }
    }
}
