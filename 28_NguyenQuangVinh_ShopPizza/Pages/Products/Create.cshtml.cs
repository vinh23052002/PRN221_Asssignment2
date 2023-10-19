using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _28_NguyenQuangVinh_ShopPizza.Data;
using _28_NguyenQuangVinh_ShopPizza.Models;
using Microsoft.AspNetCore.Authorization;

namespace _28_NguyenQuangVinh_ShopPizza.Pages.Products
{
    [Authorize(Roles = "1")]
    public class CreateModel : PageModel
    {
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;

        public CreateModel(_28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId");
        ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Product == null || Product == null)
          //  {
          //      return Page();
          //  }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
