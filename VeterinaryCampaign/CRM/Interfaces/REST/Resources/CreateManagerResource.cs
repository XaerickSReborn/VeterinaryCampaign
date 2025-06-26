using VeterinaryCampaign.CRM.Domain.Model.ValueObjects;

namespace VeterinaryCampaign.CRM.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a new manager via REST API.
/// </summary>
/// <param name="FirstName">The first name of the manager</param>
/// <param name="LastName">The last name of the manager</param>
/// <param name="Status">The initial status of the manager (optional, defaults to Open)</param>
/// <param name="AssignedSalesAgentId">The assigned sales agent identifier (optional)</param>
/// <param name="ContactedAt">The date when the manager was contacted (optional)</param>
/// <param name="ApprovedAt">The date when the manager was approved (optional)</param>
/// <param name="ReportedAt">The date when the manager was reported (optional)</param>
public record CreateManagerResource(
    string FirstName,
    string LastName,
    EManagerStatus? Status = null,
    int? AssignedSalesAgentId = null,
    DateTime? ContactedAt = null,
    DateTime? ApprovedAt = null,
    DateTime? ReportedAt = null
);