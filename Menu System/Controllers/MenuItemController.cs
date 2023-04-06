using Menu_System.Interface;
using Menu_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu_System.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuItem menuItem, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                menuItem.ImageMimeType = image.ContentType;

                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    menuItem.ImageData = memoryStream.ToArray();
                }
            }

            _menuItemRepository.AddMenuItem(menuItem);
            return RedirectToAction("Index");
        }

        
    }
}
