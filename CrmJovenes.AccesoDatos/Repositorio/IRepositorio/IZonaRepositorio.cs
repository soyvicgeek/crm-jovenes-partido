using CrmJovenes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio.IRepositorio
{
    public interface IZonaRepositorio : IRepositorio<Zona>
    {
        void Actualizar(Zona zona);
    }
}
