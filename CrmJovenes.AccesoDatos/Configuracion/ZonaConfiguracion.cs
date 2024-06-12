using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CrmJovenes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrmJovenes.AccesoDatos.Configuracion
{
    public class ZonaConfiguracion : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
