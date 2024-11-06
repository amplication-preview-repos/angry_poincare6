using Microsoft.EntityFrameworkCore;
using Puma.APIs;
using Puma.APIs.Common;
using Puma.APIs.Dtos;
using Puma.APIs.Errors;
using Puma.APIs.Extensions;
using Puma.Infrastructure;
using Puma.Infrastructure.Models;

namespace Puma.APIs;

public abstract class TendersServiceBase : ITendersService
{
    protected readonly PumaDbContext _context;

    public TendersServiceBase(PumaDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Tender
    /// </summary>
    public async Task<Tender> CreateTender(TenderCreateInput createDto)
    {
        var tender = new TenderDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            tender.Id = createDto.Id;
        }

        _context.Tenders.Add(tender);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TenderDbModel>(tender.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Tender
    /// </summary>
    public async Task DeleteTender(TenderWhereUniqueInput uniqueId)
    {
        var tender = await _context.Tenders.FindAsync(uniqueId.Id);
        if (tender == null)
        {
            throw new NotFoundException();
        }

        _context.Tenders.Remove(tender);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Tenders
    /// </summary>
    public async Task<List<Tender>> Tenders(TenderFindManyArgs findManyArgs)
    {
        var tenders = await _context
            .Tenders.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return tenders.ConvertAll(tender => tender.ToDto());
    }

    /// <summary>
    /// Meta data about Tender records
    /// </summary>
    public async Task<MetadataDto> TendersMeta(TenderFindManyArgs findManyArgs)
    {
        var count = await _context.Tenders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Tender
    /// </summary>
    public async Task<Tender> Tender(TenderWhereUniqueInput uniqueId)
    {
        var tenders = await this.Tenders(
            new TenderFindManyArgs { Where = new TenderWhereInput { Id = uniqueId.Id } }
        );
        var tender = tenders.FirstOrDefault();
        if (tender == null)
        {
            throw new NotFoundException();
        }

        return tender;
    }

    /// <summary>
    /// Update one Tender
    /// </summary>
    public async Task UpdateTender(TenderWhereUniqueInput uniqueId, TenderUpdateInput updateDto)
    {
        var tender = updateDto.ToModel(uniqueId);

        _context.Entry(tender).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tenders.Any(e => e.Id == tender.Id))
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
