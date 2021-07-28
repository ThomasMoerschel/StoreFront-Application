using System;
using System.Collections.Generic;

namespace StoreAppModels
{
    public class Products
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name {get; set; }
        public double Price {get; set; }
        public string Category {get; set; }
        public List <LineItems> LineItems { get; set; }

        public override string ToString()
        {
            return $"Product ID: {Id}\nProduct: {Name}\nCategory: {Category}";
        }
    }
}