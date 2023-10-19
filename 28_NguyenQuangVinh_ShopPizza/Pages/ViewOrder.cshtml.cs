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

namespace _28_NguyenQuangVinh_ShopPizza.Pages
{
    [Authorize(Roles = "0")]
    public class ViewOrderModel : PageModel
    {
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;

        public ViewOrderModel(_28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == id) 
                .ToListAsync();
            }
        }
    }
}
