using System;
using System.Collections.Generic;

namespace StoreAppModels
{
    public class Orders
    {
        public int Id { get; set; }
        public int StoreId {get; set; }
        public int CustomerId { get; set; }
        public double Price {get; set; }
        public List <LineItems> LineItems { get; set; }

        public override string ToString()
        {
            return $"Store ID: {StoreId} Customer ID: {CustomerId} Order Price: ${Price}";
        }
    }

}