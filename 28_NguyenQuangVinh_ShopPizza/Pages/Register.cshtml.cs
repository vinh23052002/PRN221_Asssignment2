using _28_NguyenQuangVinh_ShopPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Pages
{

    public class RegisterModel : PageModel
    {
        private readonly _28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh _context;
        public RegisterModel(_28_NguyenQuangVinh_ShopPizza.Data.DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }
        [BindProperty]
        public Customer customer { get; set; } = default!;

        [Required(ErrorMessage = "Password Confirm is required")]
        [BindProperty]
        public String passwordConfirm { get; set; } = default!;
        public String SuccessTxt { get; set; } = default!;
        String UserNameInDB = "";
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                    UserNameInDB = _context.Customer.SingleOrDefault(u => u.Username.Trim().Equals(customer.Username.Trim()))?.Username.Trim();
                if (customer.Password.Trim() != passwordConfirm.Trim())
                {
                    ModelState.AddModelError("", "Password Confirm is not match");
                    return Page();
                }
                else 

                if (customer.Username.Trim().Equals(UserNameInDB))
                {
                    ModelState.AddModelError("", "Username is already exist");
                    return Page();
                }
                else
                {
                    _context.Customer.Add(customer);
                    _context.SaveChanges();
                    SuccessTxt = "Register Success!!!";
                }
            }
            
            return Page();
        }
    }
}
