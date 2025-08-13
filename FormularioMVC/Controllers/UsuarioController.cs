using Microsoft.AspNetCore.Mvc;
using FormularioMVC.Models;

namespace FormularioMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes guardar en una base de datos o procesar la información
                ViewBag.Mensaje = "Usuario registrado correctamente.";
                return View("Resultado", usuario);
            }
            return View(usuario);
        }
    }
}
