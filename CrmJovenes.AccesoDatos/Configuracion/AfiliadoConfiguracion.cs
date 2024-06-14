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
    public class AfiliadoConfiguracion : IEntityTypeConfiguration<Afiliado>
    {
        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombres).IsRequired();
            builder.Property(x => x.ApePat).IsRequired();
            builder.Property(x => x.ApeMat).IsRequired();
            builder.Property(x => x.Edad).IsRequired();
            builder.Property(x => x.Telefono).IsRequired();
            builder.Property(x => x.Calle).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Colonia).IsRequired();
            builder.Property(x => x.Municipio).IsRequired();
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.ZonaId).IsRequired();
            builder.Property(x => x.UsuarioAplicacionId).IsRequired();
            builder.Property(x => x.FechaRegistro).IsRequired();

            builder.HasOne(x => x.Zona).WithMany()
                .HasForeignKey(x => x.ZonaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UsuarioAplicacion).WithMany()
                .HasForeignKey(x => x.UsuarioAplicacionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
