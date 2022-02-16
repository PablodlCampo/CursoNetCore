using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class PaginaCLS
    {
        public int IdPagina { get; set; }
        [Display(Name = "Nombre de la Acción")]
        [Required(ErrorMessage = "Ingrese el nombre de la Acción")]
        public string Accion { get; set; }

        [Required(ErrorMessage = "Ingrese el mensaje")]
        public string Mensaje { get; set; }
        [Display(Name = "Nombre del Controlador")]
        [Required(ErrorMessage = "Ingrese el nombre del Controlador")]
        [MinLength(3, ErrorMessage ="La longitud minima es 3")]
        [MaxLength(100, ErrorMessage ="La longitud máxima es 100")]
        public string Controlador { get; set; }
    }
}
