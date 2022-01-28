using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Controllers
{
    public class SedeController : Controller
    {
        public IActionResult Index()
        {
            List<SedeCLS> sedes = new List<SedeCLS>();


            using (BDHospitalContext bd = new BDHospitalContext())
            {
                sedes = (from sede in bd.Sede
                         where sede.Bhabilitado == 1
                         select new SedeCLS
                         {
                             idSede = sede.Iidsede,
                             nombre = sede.Nombre,
                             direccion = sede.Direccion

                         }).ToList();
            }

            return View(sedes);
        }
    }
}
