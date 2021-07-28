using StoreAppModels;

namespace SAWebUI.Models
{
    public class StoreFrontVM
    {
        public StoreFrontVM()
        { }
        public StoreFrontVM(StoreFront p_storeFront)
        {
            Id = p_storeFront.Id;
            Name = p_storeFront.Name;
            Address = p_storeFront.Address;
        }
        public int Id { get; set; }
        public string Name {get; set; }
        public string Address {get; set; }

    }
}