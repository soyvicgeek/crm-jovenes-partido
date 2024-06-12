using Microsoft.AspNetCore.Mvc;
using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos;
using CrmJovenes.Utilidades;

namespace crmjovenes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ZonaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ZonaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Método Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            Zona zona = new Zona();
            if (id == null)
            {
                //creamos un nuevo registro
                zona.Estado = true;
                return View(zona);
            }

            zona = await _unidadTrabajo.Zona.Obtener(id.GetValueOrDefault());
            if (zona == null)
            {
                return NotFound();
            }
            return View(zona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Zona zona)
        {
            if (ModelState.IsValid)
            {
                if (zona.Id == 0)
                {
                    await _unidadTrabajo.Zona.Agregar(zona);
                    TempData[DS.Exitosa] = "La Zona se creo con Éxito!";
                }
                else
                {
                    _unidadTrabajo.Zona.Actualizar(zona);
                    TempData[DS.Exitosa] = "La Zona se actualizó con Éxito!";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al Grabar la Zona";
            return View(zona);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var zonaDB = await _unidadTrabajo.Zona.Obtener(id);
            if (zonaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Zona.Remover(zonaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Zona eliminada con exito" });
        }

        // Región API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Zona.ObtenerTodos();
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Zona.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                                    == nombre.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }
        // End Región
    }
}
