using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class OrderDetail
    {
        public int OrderId {get; set;}
        public int ProductId { get; set;}   
        public Double UnitPrice { get; set;}
        public int Quantity { get; set;}
        public Order Order { get; set;}
        public Product Product { get; set;}

    }
}
