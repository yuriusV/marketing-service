using Customer.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Persistence;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Customer> Customers { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("gen_random_uuid()")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.IsMale).IsRequired();
            entity.Property(e => e.City)
                  .HasMaxLength(100)
                  .IsRequired();
            entity.Property(e => e.Birthdate).IsRequired();
            entity.Property(e => e.Deposit)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();
            entity.Property(e => e.IsNewCustomer).IsRequired();

            
            entity.HasIndex(e => e.IsMale);
            entity.HasIndex(e => e.City);
            entity.HasIndex(e => e.Birthdate);
            entity.HasIndex(e => e.Deposit);
            entity.HasIndex(e => e.IsNewCustomer);
        });
    }
}
