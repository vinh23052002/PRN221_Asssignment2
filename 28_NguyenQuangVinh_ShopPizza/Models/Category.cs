using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set;}
        public string Description { get; set; } 
        public ICollection<Product> Products { get; set; }  
    }
}
