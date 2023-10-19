using _28_NguyenQuangVinh_ShopPizza.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _28_NguyenQuangVinh_ShopPizza.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;
        public IndexModel(ILogger<IndexModel> logger, Data.DBContext_28_NguyenQuangVinh context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string Filter { get; set; } = "";
        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Product != null)
            {
                Product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
            }

        }
        public void OnPost()
        {
            if (Filter == null)
            {
                Product = _context.Product
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .ToList();
            }
            else
            {
                Product = _context.Product
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .Where(p => p.ProductName.Contains(Filter))
                    .ToList();
            }
            
        }
    }
}