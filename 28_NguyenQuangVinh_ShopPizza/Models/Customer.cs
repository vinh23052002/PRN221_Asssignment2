using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Username is required")]   
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Fullname is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage ="Phone is not correct format")]
        public string Phone { get; set; }
        public int Type { get; set; }
        [ValidateNever]
        public ICollection<Order> Orders { get; set; }
    }
}
