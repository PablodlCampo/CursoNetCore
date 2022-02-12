using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CursoNetCore.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index(PaginaCLS paginaFilter)
        {
            List<PaginaCLS> paginas = new List<PaginaCLS>();

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                paginas = (from pagina in bd.Pagina
                          where pagina.Bhabilitado == 1 && 
                              (string.IsNullOrEmpty(paginaFilter.Mensaje) ||
                              pagina.Mensaje.Contains(paginaFilter.Mensaje))
                           select new PaginaCLS()
                          {
                              IdPagina = pagina.Iidpagina,
                              Accion = pagina.Accion,
                              Mensaje = pagina.Mensaje,
                              Controlador = pagina.Controlador
                          }).ToList();
            }

            ViewBag.MensajeBuscar = paginaFilter.Mensaje;

            return View(paginas);
        }
        public IActionResult Agregar() 
        {

            return View();
        }
    }
}
