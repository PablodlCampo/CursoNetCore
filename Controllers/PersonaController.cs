using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoNetCore.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            List<PersonaCLS> personas = new List<PersonaCLS>();
            using (BDHospitalContext bd = new BDHospitalContext())
            {
                personas = (from persona in bd.Persona
                            join sexo in bd.Sexo
                            on persona.Iidsexo equals sexo.Iidsexo
                            where persona.Bhabilitado == 1
                            select new PersonaCLS()
                            {
                                IdPersona = persona.Iidpersona,
                                Mail = persona.Email,
                                NombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                Sexo = sexo.Nombre
                            }).ToList();
            }

            ViewBag.Llenarsexo = LlenarSexo();

            return View(personas);
        }


        public List<SelectListItem> LlenarSexo()
        {
            List<SelectListItem> llenarSexo;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                llenarSexo = (from Sexo in bd.Sexo
                                     where Sexo.Bhabilitado == 1
                                     select new SelectListItem
                                     {
                                         Text = Sexo.Nombre,
                                         Value = Sexo.Iidsexo.ToString()
                                     }).ToList();
            }

            return llenarSexo;
        }

        public IActionResult Agregar()
        {
            ViewBag.Llenarsexo = LlenarSexo();

            return View();
        }

        [HttpPost]
        public IActionResult Agregar(PersonaCLS personaCLS)
        {
            ViewBag.Llenarsexo = LlenarSexo();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(personaCLS);
                }
                using (BDHospitalContext bd = new BDHospitalContext())
                {
                    Persona persona = new Persona();
                    persona.Nombre = personaCLS.Nombre;
                    persona.Apmaterno = personaCLS.Amaterno;
                    persona.Appaterno = personaCLS.Apaterno;
                    persona.Telefonofijo = personaCLS.TelefonoFijo;
                    persona.Telefonocelular = personaCLS.TelefonoCelular;
                    persona.Fechanacimiento = personaCLS.FechaNacimiento;
                    persona.Email = personaCLS.Mail;
                    persona.Iidsexo = personaCLS.IdSexo;
                    persona.Bhabilitado = 1;

                    bd.Persona.Add(persona);
                    bd.SaveChanges();
                }
            }
            catch (Exception)
            {
                return View(personaCLS);
            }

            return RedirectToAction("Index");
        }
    }
}
