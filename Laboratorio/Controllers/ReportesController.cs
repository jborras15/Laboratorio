using Laboratorio.Models;
using Laboratorio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers;

public class ReportesController:Controller
{
    private readonly IReporteRepository _reporteRepository;

    public ReportesController(IReporteRepository reporteRepository)
    {
        _reporteRepository = reporteRepository;
    }
    
    
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Reportes reportes)
    {

        if (!ModelState.IsValid)
        {
            return View(reportes);
        }

        var nume = 1;

        reportes.UsuarioId = nume;
        DateTime fech = DateTime.Now;
        var hora = fech.Hour;
        reportes.TurnoId = hora < 6 && hora > 17 ? 2 : 1;
        reportes.Fecha = fech;
        await _reporteRepository.Crear(reportes);
        return RedirectToAction("Index", "Reporte");
    }
}

