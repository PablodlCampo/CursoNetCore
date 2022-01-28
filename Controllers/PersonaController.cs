using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
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


            return View(personas);
        }
    }
}
