using StoreAppModels;
using System.ComponentModel.DataAnnotations;

namespace SAWebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        { }
        public CustomerVM(Customer p_cust)
        {
            Id = p_cust.Id;
            Name = p_cust.Name;
            Address = p_cust.Address;
            PhoneNumber = p_cust.PhoneNumber;
            Email = p_cust.Email; 
            Manager = p_cust.Manager;       
        }
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Password {get; set; }
        public int Manager { get; set; }
       

    }
}