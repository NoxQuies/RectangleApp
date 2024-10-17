using Microsoft.AspNetCore.Mvc;
using RectangleDrawer.Models;

namespace RectangleDrawer.Controllers
{
    public class RectangleController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RectangleModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Draw", model);
            }
            return View(model);
        }
    }
}