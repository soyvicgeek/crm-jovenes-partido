﻿using crmjovenes.AccesoDatos.Data;
using CrmJovenes.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IZonaRepositorio Zona { get; set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Zona = new ZonaRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
