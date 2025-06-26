using VeterinaryCampaign.CRM.Domain.Model.Aggregates;
using VeterinaryCampaign.CRM.Interfaces.REST.Resources;

namespace VeterinaryCampaign.CRM.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting Manager entity to ManagerResource.
/// </summary>
public static class ManagerResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a Manager entity to a ManagerResource.
    /// Note: Excludes the internal Id as per business requirements.
    /// </summary>
    /// <param name="entity">The manager entity to convert</param>
    /// <returns>The corresponding resource</returns>
    public static ManagerResource ToResourceFromEntity(Manager entity)
    {
        return new ManagerResource(
            VeterinaryCampaignManagerId: entity.VeterinaryCampaignManagerId,
            FirstName: entity.FirstName,
            LastName: entity.LastName,
            Status: entity.Status,
            AssignedSalesAgentId: entity.AssignedSalesAgentId,
            ContactedAt: entity.ContactedAt,
            ApprovedAt: entity.ApprovedAt,
            ReportedAt: entity.ReportedAt
        );
    }
}
