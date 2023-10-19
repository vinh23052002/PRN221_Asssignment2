using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _28_NguyenQuangVinh_ShopPizza.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShippedDate { get; set; }
        public Decimal Freight { get; set; }
        public string ShipAddress { get; set; }
        [BindNever]
        public Customer Customer { get; set; }
        [ValidateNever]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
