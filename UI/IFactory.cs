namespace StoreAppUI
{
    public interface IFactory
    {
         IMenu GetMenu(MenuType p_Menu);
    }
}