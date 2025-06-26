using VeterinaryCampaign.CRM.Domain.Model.ValueObjects;

namespace VeterinaryCampaign.CRM.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a manager in REST API responses.
/// Note: Does not include the internal Id as per business requirements.
/// </summary>
/// <param name="VeterinaryCampaignManagerId">The unique VeterinaryCampaign identifier</param>
/// <param name="FirstName">The first name of the manager</param>
/// <param name="LastName">The last name of the manager</param>
/// <param name="Status">The current status of the manager</param>
/// <param name="AssignedSalesAgentId">The assigned sales agent identifier</param>
/// <param name="ContactedAt">The date when the manager was contacted</param>
/// <param name="ApprovedAt">The date when the manager was approved</param>
/// <param name="ReportedAt">The date when the manager was reported</param>
public record ManagerResource(
    Guid VeterinaryCampaignManagerId,
    string FirstName,
    string LastName,
    EManagerStatus Status,
    int? AssignedSalesAgentId,
    DateTime? ContactedAt,
    DateTime? ApprovedAt,
    DateTime? ReportedAt
);