using Microsoft.EntityFrameworkCore;
using Puma.Infrastructure.Models;

namespace Puma.Infrastructure;

public class PumaDbContext : DbContext
{
    public PumaDbContext(DbContextOptions<PumaDbContext> options)
        : base(options) { }

    public DbSet<VendorDbModel> Vendors { get; set; }

    public DbSet<TenderDbModel> Tenders { get; set; }

    public DbSet<PurchaseRequestDbModel> PurchaseRequests { get; set; }

    public DbSet<PurchaseOrderDbModel> PurchaseOrders { get; set; }
}
