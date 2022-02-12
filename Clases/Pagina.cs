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
        public string Accion { get; set; }
        public string Mensaje { get; set; }
        [Display(Name = "Nombre del Controlador")]
        public string Controlador { get; set; }
    }
}
