using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class MedicamentoCLS
    {
        [Display(Name = "Id medicamento")]
        public int IdMedicamento { get; set; }

        [Display(Name = "Seleccione forma famaceútica")]
        [Required(ErrorMessage = "Seleccione forma famaceútica")]
        public int IdFormaFarmaceutica{get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Ingrese el precio del medicamento")]
        [Required(ErrorMessage = "Ingrese el precio del medicamento")]
        public decimal Precio { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Nombre Farmacéutica")]
        public string NombreFarmaceutica { get; set; }
        
        //Informacion adicional
        [Display(Name = "Concentracion")]
        public string Concentracion { get; set; }

        //Informacion adicional
        [Display(Name = "Presentacion")]
        public string Presentacion { get; set; }
    }
}
