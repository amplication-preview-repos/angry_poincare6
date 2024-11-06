using Puma.Infrastructure;

namespace Puma.APIs;

public class TendersService : TendersServiceBase
{
    public TendersService(PumaDbContext context)
        : base(context) { }
}
