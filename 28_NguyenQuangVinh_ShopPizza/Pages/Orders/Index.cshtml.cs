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
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Pages.Orders
{
    [Authorize(Roles = "1")]
    public class IndexModel : PageModel
    {
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;

        public IndexModel(_28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime TimeStart { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime TimeEnd { get; set; } = DateTime.Now.AddYears(1);


        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            }
        }

        public void OnPost()
        {
            if (_context.Order != null)
            {
                Order = _context.Order
                .Include(o => o.Customer)
                .Where(o => o.OrderDate >= TimeStart && o.OrderDate <= TimeEnd)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            }
        }
    }
}
