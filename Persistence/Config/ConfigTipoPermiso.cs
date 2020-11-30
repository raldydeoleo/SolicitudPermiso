using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudPermisos.Persistence.Config
{
    public class ConfigTipoPermiso
    { 
        public ConfigTipoPermiso(EntityTypeBuilder<TipoPermiso> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);

            var tp1 = new TipoPermiso()
            { Id = 1, Descripcion = "Enfermedad" };
            entityBuilder.HasData(tp1);

            var tp2 = new TipoPermiso()
            { Id = 2, Descripcion = "Diligencia" };
            entityBuilder.HasData(tp2);

            var tp3 = new TipoPermiso()
            { Id = 3, Descripcion = "Otro" };
            entityBuilder.HasData(tp3);
        }
    }
}
