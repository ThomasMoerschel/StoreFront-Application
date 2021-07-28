using System;

namespace StoreAppModels
{
    public class LineItems
    {
        public int Id { get; set; }
        public int storeId {get; set;}
        public string Product {get; set; }
        public int Quantity {get; set; }
        public int ProductsId { get; set; }        
        public override string ToString()
        {
        return $"Inventory Id: {Id}\nProduct: {Product}\nQuantity: {Quantity}";
        }
    }
}