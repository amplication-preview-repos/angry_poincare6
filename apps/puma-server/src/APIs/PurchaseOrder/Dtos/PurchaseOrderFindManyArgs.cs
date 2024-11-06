using Microsoft.AspNetCore.Mvc;
using Puma.APIs.Common;
using Puma.Infrastructure.Models;

namespace Puma.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PurchaseOrderFindManyArgs : FindManyInput<PurchaseOrder, PurchaseOrderWhereInput> { }
