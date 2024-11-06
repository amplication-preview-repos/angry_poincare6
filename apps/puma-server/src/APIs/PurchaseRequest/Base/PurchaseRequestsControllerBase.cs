using Microsoft.AspNetCore.Mvc;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;

namespace Puma.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PurchaseRequestsControllerBase : ControllerBase
{
    protected readonly IPurchaseRequestsService _service;

    public PurchaseRequestsControllerBase(IPurchaseRequestsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PurchaseRequest
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PurchaseRequest>> CreatePurchaseRequest(
        PurchaseRequestCreateInput input
    )
    {
        var purchaseRequest = await _service.CreatePurchaseRequest(input);

        return CreatedAtAction(
            nameof(PurchaseRequest),
            new { id = purchaseRequest.Id },
            purchaseRequest
        );
    }

    /// <summary>
    /// Delete one PurchaseRequest
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePurchaseRequest(
        [FromRoute()] PurchaseRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePurchaseRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PurchaseRequests
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PurchaseRequest>>> PurchaseRequests(
        [FromQuery()] PurchaseRequestFindManyArgs filter
    )
    {
        return Ok(await _service.PurchaseRequests(filter));
    }

    /// <summary>
    /// Meta data about PurchaseRequest records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PurchaseRequestsMeta(
        [FromQuery()] PurchaseRequestFindManyArgs filter
    )
    {
        return Ok(await _service.PurchaseRequestsMeta(filter));
    }

    /// <summary>
    /// Get one PurchaseRequest
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PurchaseRequest>> PurchaseRequest(
        [FromRoute()] PurchaseRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PurchaseRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PurchaseRequest
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePurchaseRequest(
        [FromRoute()] PurchaseRequestWhereUniqueInput uniqueId,
        [FromQuery()] PurchaseRequestUpdateInput purchaseRequestUpdateDto
    )
    {
        try
        {
            await _service.UpdatePurchaseRequest(uniqueId, purchaseRequestUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
