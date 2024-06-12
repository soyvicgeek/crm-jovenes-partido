using crmjovenes.AccesoDatos.Data;
using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio
{
    public class ZonaRepositorio : Repositorio<Zona>, IZonaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ZonaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Zona zona)
        {
            var zonaDB = _db.Zonas.FirstOrDefault(b => b.Id == zona.Id);
            if (zonaDB != null)
            {
                zonaDB.Nombre = zona.Nombre;
                zonaDB.Descripcion = zona.Descripcion;
                zonaDB.Estado = zona.Estado;

                _db.SaveChanges();
            }
        }
    }
}
