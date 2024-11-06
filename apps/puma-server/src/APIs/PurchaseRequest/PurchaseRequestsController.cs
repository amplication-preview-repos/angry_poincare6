using Microsoft.AspNetCore.Mvc;

namespace Puma.APIs;

[ApiController()]
public class PurchaseRequestsController : PurchaseRequestsControllerBase
{
    public PurchaseRequestsController(IPurchaseRequestsService service)
        : base(service) { }
}
