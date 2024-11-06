using Microsoft.EntityFrameworkCore;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;
using Puma.APIs.Extensions;
using Puma.Infrastructure;
using Puma.Infrastructure.Models;

namespace Puma.APIs;

public abstract class VendorsServiceBase : IVendorsService
{
    protected readonly PumaDbContext _context;

    public VendorsServiceBase(PumaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Vendor
    /// </summary>
    public async Task<Vendor> CreateVendor(VendorCreateInput createDto)
    {
        var vendor = new VendorDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            vendor.Id = createDto.Id;
        }

        _context.Vendors.Add(vendor);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VendorDbModel>(vendor.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Vendor
    /// </summary>
    public async Task DeleteVendor(VendorWhereUniqueInput uniqueId)
    {
        var vendor = await _context.Vendors.FindAsync(uniqueId.Id);
        if (vendor == null)
        {
            throw new NotFoundException();
        }

        _context.Vendors.Remove(vendor);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Vendors
    /// </summary>
    public async Task<List<Vendor>> Vendors(VendorFindManyArgs findManyArgs)
    {
        var vendors = await _context
            .Vendors.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return vendors.ConvertAll(vendor => vendor.ToDto());
    }

    /// <summary>
    /// Meta data about Vendor records
    /// </summary>
    public async Task<MetadataDto> VendorsMeta(VendorFindManyArgs findManyArgs)
    {
        var count = await _context.Vendors.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Vendor
    /// </summary>
    public async Task<Vendor> Vendor(VendorWhereUniqueInput uniqueId)
    {
        var vendors = await this.Vendors(
            new VendorFindManyArgs { Where = new VendorWhereInput { Id = uniqueId.Id } }
        );
        var vendor = vendors.FirstOrDefault();
        if (vendor == null)
        {
            throw new NotFoundException();
        }

        return vendor;
    }

    /// <summary>
    /// Update one Vendor
    /// </summary>
    public async Task UpdateVendor(VendorWhereUniqueInput uniqueId, VendorUpdateInput updateDto)
    {
        var vendor = updateDto.ToModel(uniqueId);

        _context.Entry(vendor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Vendors.Any(e => e.Id == vendor.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
