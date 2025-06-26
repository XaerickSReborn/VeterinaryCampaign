
using VeterinaryCampaign.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using VeterinaryCampaign.CRM.Domain.Model.Aggregates;

namespace VeterinaryCampaign.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application database context for the Certi Web Platform API.
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // CRM Bounded Context
    public DbSet<Manager> Managers { get; set; }
    
   /// <summary>
   ///     On configuring the database context
   /// </summary>
   /// <remarks>
   ///     This method is used to configure the database context.
   ///     It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   ///     The option builder for the database context
   /// </param>
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

   /// <summary>
   ///     On creating the database model
   /// </summary>
   /// <remarks>
   ///     This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   ///     The model builder for the database context
   /// </param>
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Manager Context
        builder.Entity<Manager>().HasKey(d => d.Id);
        builder.Entity<Manager>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Manager>().Property(d => d.VeterinaryCampaignManagerId).IsRequired();
        builder.Entity<Manager>().Property(d => d.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<Manager>().Property(d => d.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Manager>().Property(d => d.Status).IsRequired();
        builder.Entity<Manager>().Property(d => d.AssignedSalesAgentId);
        builder.Entity<Manager>().Property(d => d.ContactedAt);
        builder.Entity<Manager>().Property(d => d.ApprovedAt);
        builder.Entity<Manager>().Property(d => d.ReportedAt);
        
        // Unique constraint for VeterinaryCampaignManagerId
        builder.Entity<Manager>().HasIndex(d => d.VeterinaryCampaignManagerId).IsUnique();
        
        // Unique constraint for FirstName and LastName combination
        builder.Entity<Manager>().HasIndex(d => new { d.FirstName, d.LastName }).IsUnique();
        
        // Audit columns for User Context
        builder.Entity<Manager>().Property(d => d.CreatedDate).HasColumnName("created_at");
        builder.Entity<Manager>().Property(d => d.UpdatedDate).HasColumnName("updated_at");

        builder.UseSnakeCaseNamingConvention();
    }
}