using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set;}
        public int SupplierId { get; set; } 
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public Double UnitPrice { get; set; }
        public string ProductImage { get; set; }
        [ValidateNever]
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [ValidateNever]
        public Supplier Supplier { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

    }
}
