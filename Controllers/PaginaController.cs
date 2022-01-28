using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index()
        {
            List<PaginaCLS> paginas = new List<PaginaCLS>();

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                paginas = (from pagina in bd.Pagina
                          where pagina.Bhabilitado == 1
                          select new PaginaCLS()
                          {
                              IdPagina = pagina.Iidpagina,
                              Accion = pagina.Accion,
                              Mensaje = pagina.Mensaje,
                              Controlador = pagina.Controlador
                          }).ToList();
            }

            return View(paginas);
        }
    }
}
