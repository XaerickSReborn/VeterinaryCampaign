using VeterinaryCampaign.CRM.Domain.Model.Aggregates;
using VeterinaryCampaign.CRM.Domain.Repositories;
using VeterinaryCampaign.Shared.Infrastructure.Persistence.EFC.Configuration;
using VeterinaryCampaign.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VeterinaryCampaign.CRM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework Core implementation of the manager repository.
/// </summary>
public class ManagerRepository(AppDbContext context) : BaseRepository<Manager>(context), IManagerRepository
{
    
    /// <summary>
    /// Checks if a manager with the same first and last name combination already exists using Entity Framework Core.
    /// </summary>
    /// <param name="firstName">The first name to check.</param>
    /// <param name="lastName">The last name to check.</param>
    /// <returns>True if the combination exists, false otherwise.</returns>
    public async Task<bool> ExistsByFirstNameAndLastNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Manager>()
            .AnyAsync(m => m.FirstName == firstName && m.LastName == lastName);
    }
    
}