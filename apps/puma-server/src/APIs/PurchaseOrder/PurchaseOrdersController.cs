using Microsoft.AspNetCore.Mvc;

namespace Puma.APIs;

[ApiController()]
public class PurchaseOrdersController : PurchaseOrdersControllerBase
{
    public PurchaseOrdersController(IPurchaseOrdersService service)
        : base(service) { }
}
