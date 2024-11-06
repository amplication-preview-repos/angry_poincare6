using Puma.APIs.Common;
using Puma.APIs.Dtos;

namespace Puma.APIs;

public interface IPurchaseOrdersService
{
    /// <summary>
    /// Create one PurchaseOrder
    /// </summary>
    public Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrderCreateInput purchaseorder);

    /// <summary>
    /// Delete one PurchaseOrder
    /// </summary>
    public Task DeletePurchaseOrder(PurchaseOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PurchaseOrders
    /// </summary>
    public Task<List<PurchaseOrder>> PurchaseOrders(PurchaseOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PurchaseOrder records
    /// </summary>
    public Task<MetadataDto> PurchaseOrdersMeta(PurchaseOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PurchaseOrder
    /// </summary>
    public Task<PurchaseOrder> PurchaseOrder(PurchaseOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PurchaseOrder
    /// </summary>
    public Task UpdatePurchaseOrder(
        PurchaseOrderWhereUniqueInput uniqueId,
        PurchaseOrderUpdateInput updateDto
    );
}
