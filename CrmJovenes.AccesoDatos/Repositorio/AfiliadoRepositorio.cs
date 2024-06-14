using crmjovenes.AccesoDatos.Data;
using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using CrmJovenes.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio
{
    public class AfiliadoRepositorio : Repositorio<Afiliado>, IAfiliadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public AfiliadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Afiliado afiliado)
        {
            var afiliadoDB = _db.Afiliados.FirstOrDefault(b => b.Id == afiliado.Id);
            if (afiliadoDB != null)
            {
                afiliadoDB.Nombres = afiliado.Nombres;
                afiliadoDB.ApePat = afiliado.ApePat;
                afiliadoDB.ApeMat = afiliado.ApeMat;
                afiliadoDB.Edad = afiliado.Edad;
                afiliadoDB.Telefono = afiliado.Telefono;
                afiliadoDB.Calle = afiliado.Calle;
                afiliadoDB.Numero = afiliado.Numero;
                afiliadoDB.Colonia = afiliado.Colonia;
                afiliadoDB.Municipio = afiliado.Municipio;
                afiliadoDB.Estado = afiliado.Estado;
                afiliadoDB.ZonaId = afiliado.ZonaId;

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
