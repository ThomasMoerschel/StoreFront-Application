using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IInventoryBL
    {
         List<LineItems> GetInventory(int p_id);
         LineItems AddInventory(LineItems p_lineItems, int quantity);
    }
}