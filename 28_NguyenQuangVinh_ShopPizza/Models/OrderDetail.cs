using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class OrderDetail
    {
        public int OrderId {get; set;}
        public int ProductId { get; set;}   
        public Double UnitPrice { get; set;}
        public int Quantity { get; set; }
        [BindNever]
        public Order Order { get; set; }
        [ValidateNever]
        public Product Product { get; set;}

    }
}
