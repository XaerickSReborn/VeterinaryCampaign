using VeterinaryCampaign.CRM.Domain.Model.ValueObjects;

namespace VeterinaryCampaign.CRM.Domain.Model.Commands;

/// <summary>
/// Command for creating a new Manager.
/// </summary>
/// <param name="FirstName">The first name of the manager</param>
/// <param name="LastName">The last name of the manager</param>
/// <param name="Status">The initial status of the manager (defaults to Open)</param>
/// <param name="AssignedSalesAgentId">The assigned sales agent identifier</param>
/// <param name="ContactedAt">The date when the manager was contacted</param>
/// <param name="ApprovedAt">The date when the manager was approved</param>
/// <param name="ReportedAt">The date when the manager was reported</param>
public record CreateManagerCommand(
    string FirstName,
    string LastName,
    EManagerStatus Status = EManagerStatus.Open,
    int? AssignedSalesAgentId = null,
    DateTime? ContactedAt = null,
    DateTime? ApprovedAt = null,
    DateTime? ReportedAt = null
);