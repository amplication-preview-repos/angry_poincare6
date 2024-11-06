using Puma.APIs.Common;
using Puma.APIs.Dtos;

namespace Puma.APIs;

public interface IPurchaseRequestsService
{
    /// <summary>
    /// Create one PurchaseRequest
    /// </summary>
    public Task<PurchaseRequest> CreatePurchaseRequest(PurchaseRequestCreateInput purchaserequest);

    /// <summary>
    /// Delete one PurchaseRequest
    /// </summary>
    public Task DeletePurchaseRequest(PurchaseRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PurchaseRequests
    /// </summary>
    public Task<List<PurchaseRequest>> PurchaseRequests(PurchaseRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PurchaseRequest records
    /// </summary>
    public Task<MetadataDto> PurchaseRequestsMeta(PurchaseRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PurchaseRequest
    /// </summary>
    public Task<PurchaseRequest> PurchaseRequest(PurchaseRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PurchaseRequest
    /// </summary>
    public Task UpdatePurchaseRequest(
        PurchaseRequestWhereUniqueInput uniqueId,
        PurchaseRequestUpdateInput updateDto
    );
}
