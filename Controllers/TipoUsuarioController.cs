using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoNetCore.Controllers
{
    public class TipoUsuarioController : Controller
    {
        public IActionResult Index()
        {
            List<TipoUsuarioCLS> usuarios = new List<TipoUsuarioCLS>();
            using (BDHospitalContext bd = new BDHospitalContext())
            {
                usuarios = (from TipoUsuario in bd.TipoUsuario
                            where TipoUsuario.Bhabilitado == 1
                            select new TipoUsuarioCLS()
                            {
                                Iidtipousuario = TipoUsuario.Iidtipousuario,
                                Descripcion = TipoUsuario.Descripcion,
                                Nombre = TipoUsuario.Nombre,
                            }).ToList();
            }

            return View(usuarios);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(TipoUsuarioCLS tipoUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    View(tipoUsuario);
                }

                using (BDHospitalContext bd = new BDHospitalContext())
                {
                    TipoUsuario tUsuario = new TipoUsuario();
                    tUsuario.Nombre = tipoUsuario.Nombre;
                    tUsuario.Descripcion = tipoUsuario.Descripcion;
                    tUsuario.Bhabilitado = 1;

                    bd.TipoUsuario.Add(tUsuario);
                    bd.SaveChanges();
                }
            }
            catch (Exception)
            {

                View(tipoUsuario);
            }

            return RedirectToAction("Index");
        }
    }
}
