using Microsoft.AspNetCore.Mvc;

namespace Puma.APIs;

[ApiController()]
public class TendersController : TendersControllerBase
{
    public TendersController(ITendersService service)
        : base(service) { }
}
