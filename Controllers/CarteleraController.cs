using pruebas_segundo_parcial.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pruebas_segundo_parcial.Controllers
{
    public class CarteleraController : Controller
    {
        private readonly CarteleraService _carteleraService;

        public CarteleraController(CarteleraService carteleraService)
        {
            _carteleraService = carteleraService;
        }

        public async Task<IActionResult> Index(string title = "", string ubication = "")
        {
            var items = await _carteleraService.GetItemsAsync(title, ubication);
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EstructuraItem item)
        {
            await _carteleraService.PostItemAsync(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EstructuraItem item)
        {
            await _carteleraService.PutItemAsync(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string imdbID)
        {
            await _carteleraService.DeleteItemAsync(imdbID);
            return RedirectToAction("Index");
        }
    }
}

