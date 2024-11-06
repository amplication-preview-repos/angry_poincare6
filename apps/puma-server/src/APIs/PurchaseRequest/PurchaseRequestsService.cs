using Puma.Infrastructure;

namespace Puma.APIs;

public class PurchaseRequestsService : PurchaseRequestsServiceBase
{
    public PurchaseRequestsService(PumaDbContext context)
        : base(context) { }
}
