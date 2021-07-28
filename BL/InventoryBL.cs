using System;
using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class InventoryBL : IInventoryBL
    {   
        private IRepository _repo;
        public InventoryBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public LineItems AddInventory(LineItems p_lineItems, int quantity)
        {
            return _repo.AddInventory(p_lineItems, quantity);
        }

        public List<LineItems> GetInventory(int p_id)
        {
            return _repo.GetInventory(p_id);
        }
    }
}