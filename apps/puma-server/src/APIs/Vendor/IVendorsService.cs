using Puma.APIs.Common;
using Puma.APIs.Dtos;

namespace Puma.APIs;

public interface IVendorsService
{
    /// <summary>
    /// Create one Vendor
    /// </summary>
    public Task<Vendor> CreateVendor(VendorCreateInput vendor);

    /// <summary>
    /// Delete one Vendor
    /// </summary>
    public Task DeleteVendor(VendorWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Vendors
    /// </summary>
    public Task<List<Vendor>> Vendors(VendorFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Vendor records
    /// </summary>
    public Task<MetadataDto> VendorsMeta(VendorFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Vendor
    /// </summary>
    public Task<Vendor> Vendor(VendorWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Vendor
    /// </summary>
    public Task UpdateVendor(VendorWhereUniqueInput uniqueId, VendorUpdateInput updateDto);
}
