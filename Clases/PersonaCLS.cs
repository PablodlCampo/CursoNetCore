using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class PersonaCLS
    {
        [Display(Name = "Id Especialidad")]
        public int IdPersona { get; set; }
        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Mail")]
        public string Mail { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
    }
}
