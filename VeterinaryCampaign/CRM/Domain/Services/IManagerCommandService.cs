using VeterinaryCampaign.CRM.Domain.Model.Aggregates;
using VeterinaryCampaign.CRM.Domain.Model.Commands;

namespace VeterinaryCampaign.CRM.Domain.Services;
/// <summary>
/// Service interface for handling manager command operations.
/// </summary>
public interface IManagerCommandService
{
    /// <summary>
    /// Handles the creation of a new manager.
    /// </summary>
    /// <param name="command">The command containing the manager creation data.</param>
    /// <returns>The created manager if successful, null if an error occurs.</returns>
    Task<Manager?> Handle(CreateManagerCommand command);
    
}
