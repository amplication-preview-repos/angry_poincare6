using Microsoft.AspNetCore.Mvc;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;

namespace Puma.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TendersControllerBase : ControllerBase
{
    protected readonly ITendersService _service;

    public TendersControllerBase(ITendersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Tender
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Tender>> CreateTender(TenderCreateInput input)
    {
        var tender = await _service.CreateTender(input);

        return CreatedAtAction(nameof(Tender), new { id = tender.Id }, tender);
    }

    /// <summary>
    /// Delete one Tender
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTender([FromRoute()] TenderWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTender(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Tenders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Tender>>> Tenders([FromQuery()] TenderFindManyArgs filter)
    {
        return Ok(await _service.Tenders(filter));
    }

    /// <summary>
    /// Meta data about Tender records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TendersMeta(
        [FromQuery()] TenderFindManyArgs filter
    )
    {
        return Ok(await _service.TendersMeta(filter));
    }

    /// <summary>
    /// Get one Tender
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Tender>> Tender([FromRoute()] TenderWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Tender(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Tender
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTender(
        [FromRoute()] TenderWhereUniqueInput uniqueId,
        [FromQuery()] TenderUpdateInput tenderUpdateDto
    )
    {
        try
        {
            await _service.UpdateTender(uniqueId, tenderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
