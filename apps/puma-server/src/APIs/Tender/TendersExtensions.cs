using Puma.APIs.Dtos;
using Puma.Infrastructure.Models;

namespace Puma.APIs.Extensions;

public static class TendersExtensions
{
    public static Tender ToDto(this TenderDbModel model)
    {
        return new Tender
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TenderDbModel ToModel(
        this TenderUpdateInput updateDto,
        TenderWhereUniqueInput uniqueId
    )
    {
        var tender = new TenderDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            tender.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            tender.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return tender;
    }
}
