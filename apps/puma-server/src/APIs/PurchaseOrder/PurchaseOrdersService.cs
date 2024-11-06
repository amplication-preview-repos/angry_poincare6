using Puma.Infrastructure;

namespace Puma.APIs;

public class PurchaseOrdersService : PurchaseOrdersServiceBase
{
    public PurchaseOrdersService(PumaDbContext context)
        : base(context) { }
}
