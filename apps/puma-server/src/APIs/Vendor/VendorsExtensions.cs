using Puma.APIs.Dtos;
using Puma.Infrastructure.Models;

namespace Puma.APIs.Extensions;

public static class VendorsExtensions
{
    public static Vendor ToDto(this VendorDbModel model)
    {
        return new Vendor
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VendorDbModel ToModel(
        this VendorUpdateInput updateDto,
        VendorWhereUniqueInput uniqueId
    )
    {
        var vendor = new VendorDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            vendor.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            vendor.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return vendor;
    }
}
