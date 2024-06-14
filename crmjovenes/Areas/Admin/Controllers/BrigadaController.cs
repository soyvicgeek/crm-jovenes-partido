using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos.ViewModels;
using CrmJovenes.Modelos;
using CrmJovenes.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace crmjovenes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrigadaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public BrigadaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BrigadaVM brigadaVM = new BrigadaVM()
            {
                Brigada = new Brigada(),
                ZonaLista = _unidadTrabajo.Brigada.ObtenerTodosDropDownList("Zona")
            }; 
            if (id == null)
            {
                return View(brigadaVM);
            }

            brigadaVM.Brigada = await _unidadTrabajo.Brigada.Obtener(id.GetValueOrDefault());
            if (brigadaVM.Brigada == null)
            {
                return NotFound();
            }
            return View(brigadaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BrigadaVM brigadaVM)
        {
            if (ModelState.IsValid)
            {
                if (brigadaVM.Brigada.Id == 0)
                {
                    await _unidadTrabajo.Brigada.Agregar(brigadaVM.Brigada);
                    TempData[DS.Exitosa] = "Brigada Registrada!";

                }
                else
                {
                    _unidadTrabajo.Brigada.Actualizar(brigadaVM.Brigada);
                    TempData[DS.Exitosa] = "Brigada Actualizada!";
                }
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            TempData[DS.Error] = "Error al Grabar la Brigada!";
            brigadaVM.ZonaLista = _unidadTrabajo.Brigada.ObtenerTodosDropDownList("Zona");
            return View(brigadaVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var brigadaDB = await _unidadTrabajo.Brigada.Obtener(id);
            if (brigadaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Brigada.Remover(brigadaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Brigada eliminada con exito" });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Brigada.ObtenerTodos(incluirPropiedades: "Zona");
            return Json(new { data = todos });
        }
    }
}
