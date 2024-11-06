using Microsoft.EntityFrameworkCore;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;
using Puma.APIs.Extensions;
using Puma.Infrastructure;
using Puma.Infrastructure.Models;

namespace Puma.APIs;

public abstract class PurchaseRequestsServiceBase : IPurchaseRequestsService
{
    protected readonly PumaDbContext _context;

    public PurchaseRequestsServiceBase(PumaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PurchaseRequest
    /// </summary>
    public async Task<PurchaseRequest> CreatePurchaseRequest(PurchaseRequestCreateInput createDto)
    {
        var purchaseRequest = new PurchaseRequestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            purchaseRequest.Id = createDto.Id;
        }

        _context.PurchaseRequests.Add(purchaseRequest);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PurchaseRequestDbModel>(purchaseRequest.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PurchaseRequest
    /// </summary>
    public async Task DeletePurchaseRequest(PurchaseRequestWhereUniqueInput uniqueId)
    {
        var purchaseRequest = await _context.PurchaseRequests.FindAsync(uniqueId.Id);
        if (purchaseRequest == null)
        {
            throw new NotFoundException();
        }

        _context.PurchaseRequests.Remove(purchaseRequest);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PurchaseRequests
    /// </summary>
    public async Task<List<PurchaseRequest>> PurchaseRequests(
        PurchaseRequestFindManyArgs findManyArgs
    )
    {
        var purchaseRequests = await _context
            .PurchaseRequests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return purchaseRequests.ConvertAll(purchaseRequest => purchaseRequest.ToDto());
    }

    /// <summary>
    /// Meta data about PurchaseRequest records
    /// </summary>
    public async Task<MetadataDto> PurchaseRequestsMeta(PurchaseRequestFindManyArgs findManyArgs)
    {
        var count = await _context.PurchaseRequests.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PurchaseRequest
    /// </summary>
    public async Task<PurchaseRequest> PurchaseRequest(PurchaseRequestWhereUniqueInput uniqueId)
    {
        var purchaseRequests = await this.PurchaseRequests(
            new PurchaseRequestFindManyArgs
            {
                Where = new PurchaseRequestWhereInput { Id = uniqueId.Id }
            }
        );
        var purchaseRequest = purchaseRequests.FirstOrDefault();
        if (purchaseRequest == null)
        {
            throw new NotFoundException();
        }

        return purchaseRequest;
    }

    /// <summary>
    /// Update one PurchaseRequest
    /// </summary>
    public async Task UpdatePurchaseRequest(
        PurchaseRequestWhereUniqueInput uniqueId,
        PurchaseRequestUpdateInput updateDto
    )
    {
        var purchaseRequest = updateDto.ToModel(uniqueId);

        _context.Entry(purchaseRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PurchaseRequests.Any(e => e.Id == purchaseRequest.Id))
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
