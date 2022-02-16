using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoNetCore.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            List<MedicamentoCLS> medicamentos = new List<MedicamentoCLS>();

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                medicamentos = (from medicamento in bd.Medicamento
                                join ffarmaceutica in bd.FormaFarmaceutica
                                on medicamento.Iidformafarmaceutica equals ffarmaceutica.Iidformafarmaceutica
                                where medicamento.Bhabilitado == 1
                                select new MedicamentoCLS
                                {
                                    IdMedicamento = medicamento.Iidmedicamento,
                                    Nombre = medicamento.Nombre,
                                    NombreFarmaceutica = ffarmaceutica.Nombre,
                                    Precio = (decimal)medicamento.Precio,
                                    Stock = (int)medicamento.Stock

                                }).ToList();
            }

            return View(medicamentos);
        }

        public List<SelectListItem> ListaFormaFarmaceutica(int selectedId = 1)
        {
            List<SelectListItem> formaFarmaceutica = new List<SelectListItem>();

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                formaFarmaceutica = (from FormaFarmaceutica in bd.FormaFarmaceutica
                                where FormaFarmaceutica.Bhabilitado == 1
                                     select new SelectListItem
                                     {
                                        Text = FormaFarmaceutica.Nombre,
                                        Value = FormaFarmaceutica.Iidformafarmaceutica.ToString(),
                                        Selected = FormaFarmaceutica.Iidformafarmaceutica == selectedId,
                                     }).ToList();
            }

            return formaFarmaceutica;
        }

        public IActionResult Agregar()
        {
            ViewBag.listaFarmaceutica = ListaFormaFarmaceutica();

            return View();
        }

        public IActionResult Editar(int id)
        {
            MedicamentoCLS medicamentoInsert;

            using (BDHospitalContext bd = new BDHospitalContext())
            {
                medicamentoInsert = (from Medicamento in bd.Medicamento
                                     join ffarmaceutica in bd.FormaFarmaceutica
                                     on Medicamento.Iidformafarmaceutica equals ffarmaceutica.Iidformafarmaceutica
                                     where Medicamento.Iidmedicamento == id
                                     select new MedicamentoCLS
                                     {
                                         IdMedicamento = Medicamento.Iidmedicamento,
                                         Nombre = Medicamento.Nombre,
                                         NombreFarmaceutica = ffarmaceutica.Nombre,
                                         Precio = (decimal)Medicamento.Precio,
                                         Stock = (int)Medicamento.Stock,
                                         IdFormaFarmaceutica = (int)Medicamento.Iidformafarmaceutica,
                                     }).FirstOrDefault();
            }

            ViewBag.listaFarmaceutica = ListaFormaFarmaceutica(medicamentoInsert.IdFormaFarmaceutica);

            return View(medicamentoInsert);
        }

        [HttpPost]
        public IActionResult Guardar(MedicamentoCLS medicamento)
        {
            string nombreVista = medicamento.IdMedicamento == 0 ? "Agregar" : "Editar";

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nombreVista, medicamento);
                }
                else
                {
                    using (BDHospitalContext bd = new BDHospitalContext())
                    {

                        if (medicamento.IdMedicamento == 0)
                        {
                            Medicamento medicamentoInsert = new Medicamento();
                            medicamentoInsert.Nombre = medicamento.Nombre;
                            medicamentoInsert.Precio = medicamento.Precio;
                            medicamentoInsert.Stock = medicamento.Stock;
                            medicamentoInsert.Presentacion = medicamento.Presentacion;
                            medicamentoInsert.Concentracion = medicamento.Concentracion;
                            medicamentoInsert.Iidformafarmaceutica = medicamento.IdFormaFarmaceutica;
                            medicamentoInsert.Bhabilitado = 1;

                            bd.Add<Medicamento>(medicamentoInsert);
                        }
                        else
                        {
                            Medicamento medicamentoInsert = bd.Medicamento.FirstOrDefault(e => e.Iidmedicamento == medicamento.IdMedicamento);
                            medicamentoInsert.Nombre = medicamento.Nombre;
                            medicamentoInsert.Precio = medicamento.Precio;
                            medicamentoInsert.Stock = medicamento.Stock;
                            medicamentoInsert.Presentacion = medicamento.Presentacion;
                            medicamentoInsert.Concentracion = medicamento.Concentracion;
                            medicamentoInsert.Iidformafarmaceutica = medicamento.IdFormaFarmaceutica;
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
    }
}
