using Puma.APIs.Common;
using Puma.APIs.Dtos;

namespace Puma.APIs;

public interface ITendersService
{
    /// <summary>
    /// Create one Tender
    /// </summary>
    public Task<Tender> CreateTender(TenderCreateInput tender);

    /// <summary>
    /// Delete one Tender
    /// </summary>
    public Task DeleteTender(TenderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Tenders
    /// </summary>
    public Task<List<Tender>> Tenders(TenderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Tender records
    /// </summary>
    public Task<MetadataDto> TendersMeta(TenderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Tender
    /// </summary>
    public Task<Tender> Tender(TenderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Tender
    /// </summary>
    public Task UpdateTender(TenderWhereUniqueInput uniqueId, TenderUpdateInput updateDto);
}
