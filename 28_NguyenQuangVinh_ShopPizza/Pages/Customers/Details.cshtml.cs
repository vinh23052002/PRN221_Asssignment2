using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _28_NguyenQuangVinh_ShopPizza.Data;
using _28_NguyenQuangVinh_ShopPizza.Models;
using Microsoft.AspNetCore.Authorization;

namespace _28_NguyenQuangVinh_ShopPizza.Pages.Customers
{
    [Authorize(Roles = "1")]
    public class DetailsModel : PageModel
    {
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;

        public DetailsModel(_28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }

      public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
