using System;
using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class ProductsBL : IProductsBL
    {
        private IRepository _repo;
        public ProductsBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<Products> GetProducts(int storeID)
        {
            return _repo.GetProducts(storeID);
        }
    }
}