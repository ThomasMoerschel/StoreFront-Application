using StoreAppModels;

namespace SAWebUI.Models
{
    public class ProductsVM
    {
        public ProductsVM()
        { }
        public ProductsVM(Products p_product)
        {
            Id = p_product.Id;
            StoreId = p_product.StoreId;
            Name = p_product.Name;
            Price = p_product.Price;
            Category = p_product.Category;
        }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name {get; set; }
        public double Price {get; set; }
        public string Category {get; set; }
    }
}