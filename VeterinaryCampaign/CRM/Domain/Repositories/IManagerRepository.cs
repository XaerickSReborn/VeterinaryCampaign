using VeterinaryCampaign.CRM.Domain.Model.Aggregates;
using VeterinaryCampaign.Shared.Domain.Repositories;

namespace VeterinaryCampaign.CRM.Domain.Repositories;

/// <summary>
/// Repository interface for manager-related data operations.
/// </summary>
public interface IManagerRepository : IBaseRepository<Manager>
{
    
    /// <summary>
    /// Checks if a manager with the same first and last name combination already exists.
    /// </summary>
    /// <param name="firstName">The first name to check.</param>
    /// <param name="lastName">The last name to check.</param>
    /// <returns>True if the combination exists, false otherwise.</returns>
    Task<bool> ExistsByFirstNameAndLastNameAsync(string firstName, string lastName);
    
}