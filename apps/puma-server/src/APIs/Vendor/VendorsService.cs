using Puma.Infrastructure;

namespace Puma.APIs;

public class VendorsService : VendorsServiceBase
{
    public VendorsService(PumaDbContext context)
        : base(context) { }
}
