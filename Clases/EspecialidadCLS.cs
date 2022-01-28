using System.ComponentModel.DataAnnotations;

namespace CursoNetCore.Clases
{
    public class EspecialidadCLS
    {
        [Display(Name = "Id Especialidad")]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la especialidad")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la descripción de la especialidad")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
