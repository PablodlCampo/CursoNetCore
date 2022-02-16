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


        [Display(Name = "Ingrese Nombre")]
        [Required(ErrorMessage = "Debe ingresar el Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Ingrese Apellido Paterno")]
        public string Apaterno { get; set; }

        [Display(Name = "Ingrese Apellido Materno")]

        public string Amaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar el número telefónico")]
        [MinLength(8, ErrorMessage = "Minimo 8 caracteres")]
        [Display(Name = "Ingrese el Telefono Fijo")]
        public string TelefonoFijo { get; set; }


        [Display(Name = "Ingrese el Telefono Celular")]
        public string TelefonoCelular { get; set; }

        [Required(ErrorMessage = "Seleccione un sexo")]
        [Display(Name = "Seleccione una opcion")]
        public int IdSexo { get; set; }


        [DataType(DataType.Date, ErrorMessage = "El formato de fecha no es correcto")]
        [Display(Name = "Ingrese la Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCompleto { get; set; }


        [Display(Name = "Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El correo debe ser válido")]
        public string Mail { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
    }
}
