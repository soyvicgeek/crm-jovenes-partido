using crmjovenes.AccesoDatos.Data;
using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos;
using CrmJovenes.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio
{
    public class BrigadaRepositorio : Repositorio<Brigada>, IBrigadaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BrigadaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Brigada brigada)
        {
            var brigadaDB = _db.Brigadas.FirstOrDefault(b => b.Id == brigada.Id);
            if (brigadaDB != null)
            {
                brigadaDB.Descripcion = brigada.Descripcion;
                brigadaDB.NumeroPersonas = brigada.NumeroPersonas;
                brigadaDB.Localidad = brigada.Localidad;
                brigadaDB.Municipio = brigada.Municipio;
                brigadaDB.Fecha = brigada.Fecha;
                brigadaDB.Estado = brigada.Estado;
                brigadaDB.ZonaId = brigada.ZonaId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if (obj == "Zona")
            {
                return _db.Zonas.Where(b => b.Estado == true).Select(b => new SelectListItem
                {
                    Text = b.Nombre,
                    Value = b.Id.ToString()
                });
            }
            return null;
        }
    }
}
