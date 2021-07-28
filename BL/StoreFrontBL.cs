using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IRepository _repo;
        public StoreFrontBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

     
    }
}