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

namespace _28_NguyenQuangVinh_ShopPizza.Pages.Orders
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
        ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
