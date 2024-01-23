using Microsoft.AspNetCore.Mvc;
using WEBAPP.Services;

namespace WEBAPP.Controllers
{
    public class AspiranteController : Controller
    {
        private readonly ServicioAspirante _servicioAspirantes;

        public AspiranteController(ServicioAspirante servicioAspirantes)
        {
            _servicioAspirantes = servicioAspirantes;
        }

        public async Task<IActionResult> Index()
        {
            var aspirantes = await _servicioAspirantes.ObtenerAspirantesAsync();
            return View(aspirantes);
        }
    }
}
