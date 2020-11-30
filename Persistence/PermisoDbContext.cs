using Microsoft.EntityFrameworkCore;
using Model;
using SolicitudPermisos.Persistence.Config;

namespace Persistence
{
    public class PermisoDbContext : DbContext
    {
        public PermisoDbContext(DbContextOptions<PermisoDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ConfigTipoPermiso(modelBuilder.Entity<TipoPermiso>());
            new ConfigPermiso(modelBuilder.Entity<Permiso>());


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }
    }
}
