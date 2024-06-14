using CrmJovenes.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace crmjovenes.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; }
        public DbSet<Afiliado> Afiliados { get; set; }
        public DbSet<Brigada> Brigadas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}