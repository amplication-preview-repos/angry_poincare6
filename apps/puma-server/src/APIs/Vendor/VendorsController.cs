using Microsoft.AspNetCore.Mvc;

namespace Puma.APIs;

[ApiController()]
public class VendorsController : VendorsControllerBase
{
    public VendorsController(IVendorsService service)
        : base(service) { }
}
