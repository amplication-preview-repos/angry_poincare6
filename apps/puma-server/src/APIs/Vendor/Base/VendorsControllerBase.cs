using Microsoft.AspNetCore.Mvc;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;

namespace Puma.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VendorsControllerBase : ControllerBase
{
    protected readonly IVendorsService _service;

    public VendorsControllerBase(IVendorsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Vendor
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Vendor>> CreateVendor(VendorCreateInput input)
    {
        var vendor = await _service.CreateVendor(input);

        return CreatedAtAction(nameof(Vendor), new { id = vendor.Id }, vendor);
    }

    /// <summary>
    /// Delete one Vendor
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVendor([FromRoute()] VendorWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVendor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Vendors
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Vendor>>> Vendors([FromQuery()] VendorFindManyArgs filter)
    {
        return Ok(await _service.Vendors(filter));
    }

    /// <summary>
    /// Meta data about Vendor records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VendorsMeta(
        [FromQuery()] VendorFindManyArgs filter
    )
    {
        return Ok(await _service.VendorsMeta(filter));
    }

    /// <summary>
    /// Get one Vendor
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Vendor>> Vendor([FromRoute()] VendorWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Vendor(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Vendor
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVendor(
        [FromRoute()] VendorWhereUniqueInput uniqueId,
        [FromQuery()] VendorUpdateInput vendorUpdateDto
    )
    {
        try
        {
            await _service.UpdateVendor(uniqueId, vendorUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
