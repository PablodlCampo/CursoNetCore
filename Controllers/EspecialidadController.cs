using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<EspecialidadCLS> especialidades = GetEspecialidades();


            return View(especialidades);
        }

        public List<Especialidad> Prueba()
        {
            List<Especialidad> especialidads = null;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                especialidads = bd.Especialidad.ToList();
            }

            return especialidads;
        }

        public List<EspecialidadCLS> GetEspecialidades()
        {
            List<EspecialidadCLS> especialidads = null;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                especialidads = (from especialidad in bd.Especialidad
                                 where especialidad.Bhabilitado == 1
                                 select new EspecialidadCLS
                                 {
                                     IdEspecialidad = especialidad.Iidespecialidad,
                                     Nombre = especialidad.Nombre,
                                     Descripcion = especialidad.Descripcion
                                 }).ToList();
            }

            return especialidads;
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(EspecialidadCLS especialidad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(especialidad);
                }
                else
                {
                    using (BDHospitalContext bd = new BDHospitalContext())
                    {
                        Especialidad especialidadInsert = new Especialidad();
                        especialidadInsert.Nombre = especialidad.Nombre;
                        especialidadInsert.Descripcion = especialidad.Descripcion;
                        especialidadInsert.Bhabilitado = 1;

                        bd.Add<Especialidad>(especialidadInsert);
                        bd.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
            return RedirectToAction("Index");
        }
    }
}
