using System;
using System.Collections.Generic;

namespace StoreAppModels
{
    public class StoreFront
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Address {get; set; }
        public List<Orders> Orders { get; set; }
        public List<LineItems> LineItems { get; set; }
        
        public override string ToString()
        {
            return $"Name: {Name},\n Address: {Address}";
        }
    }

}