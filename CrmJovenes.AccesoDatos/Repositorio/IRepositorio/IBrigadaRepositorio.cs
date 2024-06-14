using CrmJovenes.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio.IRepositorio
{
    public interface IBrigadaRepositorio : IRepositorio<Brigada>
    {
        void Actualizar(Brigada brigada);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
