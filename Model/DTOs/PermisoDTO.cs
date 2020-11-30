using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudPermisos.Model.DTOs
{
    public class PermisoDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,
        ErrorMessage = "Nombre no debe tener mas de 50 caracteres.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50,
        ErrorMessage = "Apellido no debe tener mas de 50 caracteres.")]
        public string LastName { get; set; }
        [Required]
        public DateTime Date { get; set; }

        // Foreign key 
        [Display(Name = "TipoPermiso")]
        public int TipoPermisoId { get; set; }

    }
}
