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
        public IActionResult Index(EspecialidadCLS especialidad)
        {
            IEnumerable<EspecialidadCLS> especialidades = GetEspecialidades(especialidad);

            ViewBag.NombreEspecialidad = especialidad.Nombre;

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

        public List<EspecialidadCLS> GetEspecialidades(EspecialidadCLS especialidadFilter)
        {
            List<EspecialidadCLS> especialidadList = null;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                especialidadList = (from especialidad in bd.Especialidad
                                    where especialidad.Bhabilitado == 1 && (especialidad.Nombre.Contains(especialidadFilter.Nombre) ||
                                                                                 string.IsNullOrEmpty(especialidadFilter.Nombre))
                                    select new EspecialidadCLS
                                    {
                                        IdEspecialidad = especialidad.Iidespecialidad,
                                        Nombre = especialidad.Nombre,
                                        Descripcion = especialidad.Descripcion
                                    }).ToList();
            }

            return especialidadList;
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EspecialidadCLS especialidad)
        {
            string nombreVista = especialidad.IdEspecialidad == 0 ? "Agregar" : "Editar";

            try
            {
                if (!ModelState.IsValid)
                { 
                    return View(nombreVista, especialidad);
                }
                else
                {
                    using (BDHospitalContext bd = new BDHospitalContext())
                    {
                        if (especialidad.IdEspecialidad == 0)
                        {
                            Especialidad especialidadInsert = new Especialidad();
                            especialidadInsert.Nombre = especialidad.Nombre;
                            especialidadInsert.Descripcion = especialidad.Descripcion;
                            especialidadInsert.Bhabilitado = 1;

                            bd.Add<Especialidad>(especialidadInsert);
                        }
                        else
                        {
                            Especialidad especialidadEdit = bd.Especialidad.FirstOrDefault(e => e.Iidespecialidad == especialidad.IdEspecialidad);
                            especialidadEdit.Nombre = especialidad.Nombre;
                            especialidadEdit.Descripcion = especialidad.Descripcion;
                            especialidadEdit.Bhabilitado = 1;
                        }
                        
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

        [HttpPost]
        public IActionResult Eliminar(int idEspecialidad)
        {
            string error;

            try
            {
                using (BDHospitalContext bd = new BDHospitalContext())
                {
                    Especialidad esp = new Especialidad();
                    esp = bd.Especialidad.FirstOrDefault(e => e.Iidespecialidad == idEspecialidad);

                    if (esp == null)
                    {
                        return View();
                    }
                    else
                    {
                        esp.Bhabilitado = 0;
                        bd.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            EspecialidadCLS especialidadEdit = null;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                especialidadEdit = (from especialidad in bd.Especialidad
                                    where especialidad.Iidespecialidad == id
                                    select new EspecialidadCLS
                                    {
                                        IdEspecialidad = especialidad.Iidespecialidad,
                                        Nombre = especialidad.Nombre,
                                        Descripcion = especialidad.Descripcion
                                    }).FirstOrDefault();
            }

            ViewBag.Id = id;

            return View(especialidadEdit);
        }
    }
}
