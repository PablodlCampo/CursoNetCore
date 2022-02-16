using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class TipoUsuarioCLS
    {
        [Display(Name = "Id tipo de usuario")]
        public int Iidtipousuario { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar la descripción")]
        public string Descripcion { get; set; }
    }
}
