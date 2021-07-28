
using StoreAppModels;
using System.ComponentModel.DataAnnotations;

namespace SAWebUI.Models
{
    public class OrdersVM
    {
        public OrdersVM()
        { }
        public OrdersVM(Orders p_order)
        {
            Id = p_order.Id;
            StoreId = p_order.StoreId;
            CustomerId = p_order.CustomerId;
            Price = p_order.Price;
        }
        public int Id { get; set; }
        public int StoreId {get; set; }
        public int CustomerId { get; set; }
        public double Price {get; set; }

    }
}