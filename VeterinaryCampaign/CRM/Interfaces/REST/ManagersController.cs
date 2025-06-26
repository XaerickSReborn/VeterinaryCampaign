using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VeterinaryCampaign.CRM.Domain.Services;
using VeterinaryCampaign.CRM.Interfaces.REST.Resources;
using VeterinaryCampaign.CRM.Interfaces.REST.Transform;

namespace VeterinaryCampaign.CRM.Interfaces.REST;

/// <summary>
/// REST API controller for managing manager operations.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Manager Endpoints.")]
public class ManagersController(IManagerCommandService managerCommandService) : ControllerBase
{
    /// <summary>
    /// Creates a new manager.
    /// </summary>
    /// <param name="resource">The manager creation data</param>
    /// <returns>The created manager resource</returns>
    /// <response code="201">Manager created successfully</response>
    /// <response code="400">Invalid request data or business rule violation</response>
    /// <response code="409">Manager with the same name combination already exists</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new manager",
        Description = "Creates a new manager with the provided information. The VeterinaryCampaignManagerId is auto-generated.",
        OperationId = "CreateManager"
    )]
    [SwaggerResponse(201, "Manager created successfully", typeof(ManagerResource))]
    [SwaggerResponse(400, "Invalid request data or business rule violation")]
    [SwaggerResponse(409, "Manager with the same name combination already exists")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<ActionResult<ManagerResource>> CreateManager([FromBody] CreateManagerResource resource)
    {
        var createManagerCommand = CreateManagerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var manager = await managerCommandService.Handle(createManagerCommand);
        if (manager == null) return BadRequest();
        var managerResource = ManagerResourceFromEntityAssembler.ToResourceFromEntity(manager);

        return StatusCode(201, managerResource);
    }
}