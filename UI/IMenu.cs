namespace StoreAppUI
{
  public enum MenuType
    {
        MainMenu,
        CustomerMenu,
        ShowCustomerMenu,
        AddCustomerMenu,
        SearchCustomerMenu,
        StoreOrderHistory,
        StoreFrontMenu,
        ManagementFindStoreFrontMenu,
        StoreFrontInventoryMenu,
        AddInventory,
        ViewInventory,
        CustomerOrderHistory,
        CustomerFindStoreFrontMenu,
        MakeAnOrder,
        CustomerValidation,
        CustomerCheckout,
        PurchaseConfirmation,
        SearchCustomerOrderHistory,
        ManagerValidation,
        AdministratorMenu,
        Exit
    }
    public interface IMenu
    {
        void Menu();
        MenuType UserInput();
    }
}