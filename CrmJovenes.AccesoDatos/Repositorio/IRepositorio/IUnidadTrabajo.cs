using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IZonaRepositorio Zona { get; }
        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }
        IAfiliadoRepositorio Afiliado { get; }
        Task Guardar();
    }
}
