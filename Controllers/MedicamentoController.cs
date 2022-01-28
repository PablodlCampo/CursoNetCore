using CursoNetCore.Clases;
using CursoNetCore.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
