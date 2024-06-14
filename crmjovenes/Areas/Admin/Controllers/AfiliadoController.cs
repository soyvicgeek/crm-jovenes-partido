using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos;
using CrmJovenes.Modelos.ViewModels;
using CrmJovenes.Utilidades;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace crmjovenes.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AfiliadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public AfiliadoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            AfiliadoVM afiliadoVM = new AfiliadoVM()
            {
                Afiliado = new Afiliado(),
                ZonaLista = _unidadTrabajo.Afiliado.ObtenerTodosDropDownList("Zona")
            };
            if (id == null)
            {
                return View(afiliadoVM);
            }

            afiliadoVM.Afiliado = await _unidadTrabajo.Afiliado.Obtener(id.GetValueOrDefault());
            if (afiliadoVM.Afiliado == null)
            {
                return NotFound();
            }
            return View(afiliadoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AfiliadoVM afiliadoVM)
        {
            if (ModelState.IsValid)
            {
                if (afiliadoVM.Afiliado.Id == 0)
                {
                    afiliadoVM.Afiliado.FechaRegistro = DateTime.Now;
                    await _unidadTrabajo.Afiliado.Agregar(afiliadoVM.Afiliado);
                    TempData[DS.Exitosa] = "Afiliado Registrado!";

                }
                else
                {
                    _unidadTrabajo.Afiliado.Actualizar(afiliadoVM.Afiliado);
                    TempData[DS.Exitosa] = "Afiliado Actualizado!";
                }
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            TempData[DS.Error] = "Error al Grabar el Afiliado";
            afiliadoVM.ZonaLista = _unidadTrabajo.Afiliado.ObtenerTodosDropDownList("Zona");
            return View(afiliadoVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var afiliadoDB = await _unidadTrabajo.Afiliado.Obtener(id);
            if (afiliadoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            _unidadTrabajo.Afiliado.Remover(afiliadoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Afiliado eliminada con exito" });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Afiliado.ObtenerTodos(incluirPropiedades: "Zona");
            return Json(new { data = todos });
        }
    }
}
