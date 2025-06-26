namespace VeterinaryCampaign.CRM.Domain.Model.ValueObjects;

/// <summary>
/// Enumeration representing the possible status values for a Manager in VeterinaryCampaign.
/// </summary>
public enum EManagerStatus
{
    /// <summary>
    /// Manager is open and available for contact.
    /// </summary>
    Open = 1,
    
    /// <summary>
    /// Manager has been contacted.
    /// </summary>
    Contacted = 2,
    
    /// <summary>
    /// Meeting has been set with the manager.
    /// </summary>
    MeetingSet = 3,
    
    /// <summary>
    /// Manager has been qualified as a prospect.
    /// </summary>
    Qualified = 4,
    
    /// <summary>
    /// Manager has become a customer.
    /// </summary>
    Customer = 5,
    
    /// <summary>
    /// Opportunity with manager has been lost.
    /// </summary>
    OpportunityLost = 6,
    
    /// <summary>
    /// Manager has been unqualified.
    /// </summary>
    Unqualified = 7,
    
    /// <summary>
    /// Manager is already a veterinary customer.
    /// </summary>
    InVeterinaryCustomer = 8
}