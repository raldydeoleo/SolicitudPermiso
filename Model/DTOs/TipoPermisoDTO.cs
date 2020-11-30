using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudPermisos.Model.DTOs
{
    public class TipoPermisoDTO
    {
        [Required]
        public int TipoPermisoId { get; set; }

        [Required]
        [StringLength(30,
        ErrorMessage = "Descripcion no debe tener mas de 30 caracteres.")]
        public string Descripcion { get; set; }
    }
}
