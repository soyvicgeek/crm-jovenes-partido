using CrmJovenes.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAfiliadoRepositorio : IRepositorio<Afiliado>
    {
        void Actualizar(Afiliado afiliado);
        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
