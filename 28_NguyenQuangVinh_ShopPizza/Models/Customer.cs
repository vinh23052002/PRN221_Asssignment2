using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Username { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
