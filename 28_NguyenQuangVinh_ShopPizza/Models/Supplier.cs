using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string CompanyName { get; set;}
        public string Address { get; set; } 
        public string Phone { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
