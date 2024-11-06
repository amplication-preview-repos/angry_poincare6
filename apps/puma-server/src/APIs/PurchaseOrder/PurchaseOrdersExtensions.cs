using Puma.APIs.Dtos;
using Puma.Infrastructure.Models;

namespace Puma.APIs.Extensions;

public static class PurchaseOrdersExtensions
{
    public static PurchaseOrder ToDto(this PurchaseOrderDbModel model)
    {
        return new PurchaseOrder
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PurchaseOrderDbModel ToModel(
        this PurchaseOrderUpdateInput updateDto,
        PurchaseOrderWhereUniqueInput uniqueId
    )
    {
        var purchaseOrder = new PurchaseOrderDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            purchaseOrder.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            purchaseOrder.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return purchaseOrder;
    }
}
