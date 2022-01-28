using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class MedicamentoCLS
    {
        public int IdMedicamento { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string NombreFarmaceutica { get; set; }
    }
}
