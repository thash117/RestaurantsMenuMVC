using Menu_System.Models;

namespace Menu_System.Interface
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int id);
        void AddMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(MenuItem menuItem);
    }
}
