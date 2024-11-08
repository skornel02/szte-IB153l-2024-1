using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.DigitalSalesPage;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales)]
public class IndexModel : BasePageModel
{
    private readonly BellaDbContext _context;
    public List<OrderEntity> Orders { get; set; } = null!;


    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Orders = await _context.Orders
            .Where(_ => _.Status == Enums.OrderStatus.OrderPlaced)
            .Include(_ => _.OrderItems)
                .ThenInclude(_ => _.Product)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostAcceptAsync(Guid? id)
    {
        var orderEntity = await _context.Orders
            .Where(_ => _.Status == Enums.OrderStatus.OrderPlaced)
            .Include(_ => _.OrderItems)
                .ThenInclude(_ => _.Product)
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (orderEntity is null)
        {
            return RedirectToPage("./Index", new { ErrorMessage = "Order not found!" });
        }

        var notEnoughProducts = new List<string>();

        foreach (var item in orderEntity.OrderItems)
        {
            if (item.Product.Stock - item.Product.Reserved < item.Quantity)
            {
                notEnoughProducts.Add(item.Product.Name);
            }
            item.Product.Reserved += item.Quantity;
        }

        if (notEnoughProducts.Count != 0)
        {
            return RedirectToPage("./Index", new { ErrorMessage = $"Not enough from {string.Join(", ", notEnoughProducts)}" });
        }

        orderEntity.Status = Enums.OrderStatus.OrderApproved;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index", new { SuccessMessage = "Order accepted successfully!" });
    }

    public async Task<IActionResult> OnPostRejectAsync(Guid? id)
    {
        var orderEntity = await _context.Orders
            .Where(_ => _.Status == Enums.OrderStatus.OrderPlaced)
            .Include(_ => _.OrderItems)
                .ThenInclude(_ => _.Product)
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (orderEntity is null)
        {
            return RedirectToPage("./Index", new { ErrorMessage = "Order not found!" });
        }

        orderEntity.Status = Enums.OrderStatus.OrderRejected;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index", new { SuccessMessage = "Order rejected successfully!" });
    }
}
