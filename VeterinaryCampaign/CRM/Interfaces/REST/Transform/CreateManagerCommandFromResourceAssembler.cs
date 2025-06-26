using VeterinaryCampaign.CRM.Domain.Model.Commands;
using VeterinaryCampaign.CRM.Domain.Model.ValueObjects;
using VeterinaryCampaign.CRM.Interfaces.REST.Resources;

namespace VeterinaryCampaign.CRM.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting CreateManagerResource to CreateManagerCommand.
/// </summary>
public static class CreateManagerCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a CreateManagerResource to a CreateManagerCommand.
    /// </summary>
    /// <param name="resource">The resource to convert</param>
    /// <returns>The corresponding command</returns>
    public static CreateManagerCommand ToCommandFromResource(CreateManagerResource resource)
    {
        return new CreateManagerCommand(
            FirstName: resource.FirstName,
            LastName: resource.LastName,
            Status: resource.Status ?? EManagerStatus.Open,
            AssignedSalesAgentId: resource.AssignedSalesAgentId,
            ContactedAt: resource.ContactedAt,
            ApprovedAt: resource.ApprovedAt,
            ReportedAt: resource.ReportedAt
        );
    }
}