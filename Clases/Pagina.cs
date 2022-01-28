using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Clases
{
    public class PaginaCLS
    {
        public int IdPagina { get; set; }

        public string Accion { get; set; }
        public string Mensaje { get; set; }

        public string Controlador { get; set; }
    }
}
