using System.Diagnostics.CodeAnalysis;
using VeterinaryCampaign.CRM.Domain.Model.ValueObjects;
using VeterinaryCampaign.CRM.Domain.Model.Commands;

namespace VeterinaryCampaign.CRM.Domain.Model.Aggregates;

public partial class Manager
{
    /// <summary>
    /// Gets the unique identifier for the manager.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Gets the unique VeterinaryCampaign identifier for the manager.
    /// </summary>
    public Guid VeterinaryCampaignManagerId { get; private set; }
    
    /// <summary>
    /// Gets the first name of the manager.
    /// </summary>
    public string FirstName { get; private set; } = string.Empty;
    
    /// <summary>
    /// Gets the last name of the manager.
    /// </summary>
    public string LastName { get; private set; } = string.Empty;
    
    /// <summary>
    /// Gets the current status of the manager.
    /// </summary>
    public EManagerStatus Status { get; private set; }
    
    /// <summary>
    /// Gets the assigned sales agent identifier.
    /// </summary>
    public int? AssignedSalesAgentId { get; private set; }
    
    /// <summary>
    /// Gets the date when the manager was contacted.
    /// </summary>
    public DateTime? ContactedAt { get; private set; }
    
    /// <summary>
    /// Gets the date when the manager was approved.
    /// </summary>
    public DateTime? ApprovedAt { get; private set; }
    
    /// <summary>
    /// Gets the date when the manager was reported.
    /// </summary>
    public DateTime? ReportedAt { get; private set; }

    // Constructor for EF Core
    protected Manager() { }
    
    /// <summary>
    /// Initializes a new instance of the Manager class with the specified creation command.
    /// </summary>
    /// <param name="command">The command containing the manager's initial data.</param>
    [SetsRequiredMembers]
    public Manager(CreateManagerCommand command)
    {
        ValidateNameField(command.FirstName, nameof(command.FirstName));
        ValidateNameField(command.LastName, nameof(command.LastName));

        ValidateStatusRules(command.Status, command.AssignedSalesAgentId, command.ContactedAt, command.ApprovedAt, command.ReportedAt);

        VeterinaryCampaignManagerId = Guid.NewGuid();
        
        FirstName = command.FirstName;
        LastName = command.LastName;
        Status = command.Status;
        AssignedSalesAgentId = command.AssignedSalesAgentId;
        ContactedAt = command.ContactedAt;
        ApprovedAt = command.ApprovedAt;
        ReportedAt = command.ReportedAt;
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
    
    /// <summary>
    /// Validates business rules related to status and dependent fields.
    /// </summary>
    /// <param name="status">The status to validate</param>
    /// <param name="assignedSalesAgentId">The assigned sales agent ID</param>
    /// <param name="contactedAt">The contacted date</param>
    /// <param name="approvedAt">The approved date</param>
    /// <param name="reportedAt">The reported date</param>
    /// <exception cref="ArgumentException">Thrown when business rules are violated</exception>
    private static void ValidateStatusRules(
        EManagerStatus status,
        int? assignedSalesAgentId,
        DateTime? contactedAt,
        DateTime? approvedAt,
        DateTime? reportedAt)
    {
        var statusesRequiringContact = new[]
        {
            EManagerStatus.Contacted,
            EManagerStatus.MeetingSet,
            EManagerStatus.Qualified,
            EManagerStatus.Customer,
            EManagerStatus.OpportunityLost,
            EManagerStatus.Unqualified,
            EManagerStatus.InVeterinaryCustomer
        };
        
        if (statusesRequiringContact.Contains(status))
        {
            if (!assignedSalesAgentId.HasValue)
                throw new ArgumentException("AssignedSalesAgentId is required for the specified status.");
                
            if (!contactedAt.HasValue)
                throw new ArgumentException("ContactedAt is required for the specified status.");
        }
        
        var statusesRequiringApproval = new[]
        {
            EManagerStatus.Qualified,
            EManagerStatus.Customer,
            EManagerStatus.OpportunityLost,
            EManagerStatus.Unqualified,
            EManagerStatus.InVeterinaryCustomer
        };
        
        if (statusesRequiringApproval.Contains(status) && !approvedAt.HasValue)
        {
            throw new ArgumentException("ApprovedAt is required for the specified status.");
        }
        
        if (status == EManagerStatus.Unqualified && !reportedAt.HasValue)
        {
            throw new ArgumentException("ReportedAt is required for Unqualified status.");
        }
    }
    
}