using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public IActionResult Agregar(PaginaCLS pagina)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pagina);
                }
                else
                {
                    using (BDHospitalContext bd = new BDHospitalContext())
                    {
                        Pagina paginaInsert = new Pagina();
                        paginaInsert.Mensaje = pagina.Mensaje;
                        paginaInsert.Controlador = pagina.Controlador;
                        paginaInsert.Accion = pagina.Accion;
                        paginaInsert.Bhabilitado = 1;

                        bd.Add<Pagina>(paginaInsert);
                        bd.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return View(pagina);
            }


            return RedirectToAction("Index");
        }
    }
}
