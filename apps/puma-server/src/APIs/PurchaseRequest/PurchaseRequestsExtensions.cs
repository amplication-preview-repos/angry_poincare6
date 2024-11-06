using Puma.APIs.Dtos;
using Puma.Infrastructure.Models;

namespace Puma.APIs.Extensions;

public static class PurchaseRequestsExtensions
{
    public static PurchaseRequest ToDto(this PurchaseRequestDbModel model)
    {
        return new PurchaseRequest
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PurchaseRequestDbModel ToModel(
        this PurchaseRequestUpdateInput updateDto,
        PurchaseRequestWhereUniqueInput uniqueId
    )
    {
        var purchaseRequest = new PurchaseRequestDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            purchaseRequest.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            purchaseRequest.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return purchaseRequest;
    }
}
