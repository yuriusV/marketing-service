using Campaign.Domain.Common;
using Campaign.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Campaign.Infrastructure.Persistence;

public class CampaignContext : DbContext
{
    public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Campaign> Campaigns { get; set; }

    public DbSet<Template> Templates { get; set; }

    public DbSet<CampaignActivity> Activities { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonConverter = new ValueConverter<CustomerQuery, string>(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<CustomerQuery>(v));

        modelBuilder.Entity<Domain.Entities.Campaign>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("gen_random_uuid()")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                  .IsRequired();

            entity.Property(e => e.Query)
                .HasConversion(jsonConverter)
                .HasColumnType("jsonb");

            entity.Property(e => e.Time)
                  .HasColumnType("time");

            entity.Property(e => e.Priority)
                  .IsRequired();

            entity.HasOne(e => e.Template)
                  .WithMany()
                  .HasForeignKey(e => e.TemplateId)
                  .IsRequired();
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("gen_random_uuid()")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                  .IsRequired();

            entity.Property(e => e.Contents)
                  .HasColumnType("bytea");
        });

        modelBuilder.Entity<CampaignActivity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("gen_random_uuid()")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.TargetId)
                  .IsRequired();

            entity.HasIndex(e => new { e.TargetId, e.CreatedDate });
        });

        base.OnModelCreating(modelBuilder);
    }
}
