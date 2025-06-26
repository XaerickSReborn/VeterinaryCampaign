


using VeterinaryCampaign.CRM.Domain.Model.Aggregates;
using VeterinaryCampaign.CRM.Domain.Model.Commands;
using VeterinaryCampaign.CRM.Domain.Repositories;
using VeterinaryCampaign.CRM.Domain.Services;
using VeterinaryCampaign.Shared.Domain.Repositories;

namespace VeterinaryCampaign.CRM.Application.Internal.CommandServices;

/// <summary>
/// Implementation of the manager command service for handling manager operations.
/// </summary>
public class ManagerCommandServiceImpl(IManagerRepository managerRepository, IUnitOfWork unitOfWork) : IManagerCommandService
{
    /// <summary>
    /// Handles the creation of a new manager with business rule validation.
    /// </summary>
    /// <param name="command">The command containing the manager creation data.</param>
    /// <returns>The created manager if successful, null if an error occurs.</returns>
    public async Task<Manager?> Handle(CreateManagerCommand command)
    {
        try
        {
            ValidateNameField(command.FirstName, nameof(command.FirstName));
            ValidateNameField(command.LastName, nameof(command.LastName));
            
            var existingManager = await managerRepository.ExistsByFirstNameAndLastNameAsync(
                command.FirstName, command.LastName);
            
            if (existingManager)
            {
                throw new InvalidOperationException(
                    $"A manager with the name '{command.FirstName} {command.LastName}' already exists.");
            }
            
            var manager = new Manager(command);
            
            await managerRepository.AddAsync(manager);
            
            // Save changes
            await unitOfWork.CompleteAsync();
            
            return manager;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating manager: {ex.Message}");
            return null;
        }
    }
    
    /// <summary>
    /// Validates that a name field meets business requirements.
    /// </summary>
    /// <param name="value">The name value to validate</param>
    /// <param name="fieldName">The name of the field being validated</param>
    /// <exception cref="ArgumentException">Thrown when validation fails</exception>
    private static void ValidateNameField(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} cannot be null, empty, or whitespace.", fieldName);
            
        if (value.Length < 4 || value.Length > 40)
            throw new ArgumentException($"{fieldName} must be between 4 and 40 characters.", fieldName);
    }
    
}