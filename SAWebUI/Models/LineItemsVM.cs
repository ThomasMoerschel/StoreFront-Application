using StoreAppModels;

namespace SAWebUI.Models
{
    public class LineItemsVM
    {
        public LineItemsVM()
        { }
        public LineItemsVM(LineItems p_item)
        {
            Id = p_item.Id;
            Product = p_item.Product;
            Quantity = p_item.Quantity;
            storeID = p_item.storeId;
            ProductsId = p_item.ProductsId;
        }
        public int Id { get; set; }
        public int storeID {get; set;}
        public string Product {get; set; }
        public int ProductsId { get; set; }
        public int Quantity {get; set; }
    }
}