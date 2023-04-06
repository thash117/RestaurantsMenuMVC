using Menu_System.Interface;
using Menu_System.Models;

namespace Menu_System.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly MenuDbContext _dbContext;

        public MenuItemRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _dbContext.MenuItems.ToList();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _dbContext.MenuItems.Find(id);
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItems.Add(menuItem);
            _dbContext.SaveChanges();
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItems.Update(menuItem);
            _dbContext.SaveChanges();
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItems.Remove(menuItem);
            _dbContext.SaveChanges();
        }
    }
}
