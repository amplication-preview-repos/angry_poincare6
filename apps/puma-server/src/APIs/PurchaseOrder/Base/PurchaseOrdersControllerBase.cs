using Microsoft.AspNetCore.Mvc;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;

namespace Puma.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PurchaseOrdersControllerBase : ControllerBase
{
    protected readonly IPurchaseOrdersService _service;

    public PurchaseOrdersControllerBase(IPurchaseOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PurchaseOrder
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PurchaseOrder>> CreatePurchaseOrder(
        PurchaseOrderCreateInput input
    )
    {
        var purchaseOrder = await _service.CreatePurchaseOrder(input);

        return CreatedAtAction(nameof(PurchaseOrder), new { id = purchaseOrder.Id }, purchaseOrder);
    }

    /// <summary>
    /// Delete one PurchaseOrder
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePurchaseOrder(
        [FromRoute()] PurchaseOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePurchaseOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PurchaseOrders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PurchaseOrder>>> PurchaseOrders(
        [FromQuery()] PurchaseOrderFindManyArgs filter
    )
    {
        return Ok(await _service.PurchaseOrders(filter));
    }

    /// <summary>
    /// Meta data about PurchaseOrder records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PurchaseOrdersMeta(
        [FromQuery()] PurchaseOrderFindManyArgs filter
    )
    {
        return Ok(await _service.PurchaseOrdersMeta(filter));
    }

    /// <summary>
    /// Get one PurchaseOrder
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PurchaseOrder>> PurchaseOrder(
        [FromRoute()] PurchaseOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PurchaseOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PurchaseOrder
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePurchaseOrder(
        [FromRoute()] PurchaseOrderWhereUniqueInput uniqueId,
        [FromQuery()] PurchaseOrderUpdateInput purchaseOrderUpdateDto
    )
    {
        try
        {
            await _service.UpdatePurchaseOrder(uniqueId, purchaseOrderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
