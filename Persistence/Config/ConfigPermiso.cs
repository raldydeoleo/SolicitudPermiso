using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudPermisos.Persistence.Config
{
    public class ConfigPermiso
    {
        public ConfigPermiso(EntityTypeBuilder<Permiso> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Date).IsRequired();
        }
    }
}
