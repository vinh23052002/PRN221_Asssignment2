using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using _28_NguyenQuangVinh_ShopPizza.Data;
using _28_NguyenQuangVinh_ShopPizza.Models;

namespace _28_NguyenQuangVinh_ShopPizza.Pages
{
    public class Users
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = default!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
    }
    public class LoginModel : PageModel
    {
        private readonly DBContext_28_NguyenQuangVinh _context;

        public LoginModel(DBContext_28_NguyenQuangVinh context)
        {
            _context = context;
        }
        

        [BindProperty]
        public Users user { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Customer customer = await _context.Customer.FirstOrDefaultAsync
                    (m => m.Username == user.Username && m.Password == user.Password);

                if (customer == null)
                {
                    ModelState.AddModelError(string.Empty, "User or Password not Correct!!");
                    return Page();
                }
                else
                {
                    var claims = new List<Claim>
                {
                    new Claim("UserName", customer.Username),
                    new Claim("UserId",customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Role, customer.Type.ToString()),
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToPage("./Index");
                }

            }
            return Page();
        }
    }
}
