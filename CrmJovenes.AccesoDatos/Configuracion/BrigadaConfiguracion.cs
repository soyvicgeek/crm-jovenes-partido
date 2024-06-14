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
    public class BrigadaConfiguracion : IEntityTypeConfiguration<Brigada>
    {
        public void Configure(EntityTypeBuilder<Brigada> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripcion).IsRequired();
            builder.Property(x => x.NumeroPersonas).IsRequired();
            builder.Property(x => x.Localidad).IsRequired();
            builder.Property(x => x.Municipio).IsRequired();
            builder.Property(x => x.ZonaId).IsRequired();
            builder.Property(x => x.Fecha).IsRequired();
            builder.Property(x => x.Estado).IsRequired();

            builder.HasOne(x => x.Zona).WithMany()
                .HasForeignKey(x => x.ZonaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
