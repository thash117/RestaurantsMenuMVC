using Menu_System.Interface;
using Menu_System.Models;
using Menu_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Menu_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMenuItemRepository _menuItemRepository;

        public HomeController(ILogger<HomeController> logger, IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var menuItems = _menuItemRepository.GetAllMenuItems();
            return View(menuItems);
        }

        public IActionResult Edit(int id)
        {
            var menuItem = _menuItemRepository.GetMenuItemById(id);
            return View(menuItem);
        }

        [HttpPost]
        public IActionResult Edit(MenuItem menuItem, IFormFile image)
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

            _menuItemRepository.UpdateMenuItem(menuItem);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var menuItem = _menuItemRepository.GetMenuItemById(id);
            return View(menuItem);
        }

        [HttpPost]
        public IActionResult Delete(MenuItem menuItem)
        {
            _menuItemRepository.DeleteMenuItem(menuItem);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}