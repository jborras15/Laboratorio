using Laboratorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using DateTime = System.DateTime;

namespace Laboratorio.Controllers;

public class ReporteController:Controller
{
    private readonly IReporteRepository _reporteRepository;

    public ReporteController(IReporteRepository reporteRepository)
    {
        _reporteRepository = reporteRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var usuarioId = 1;
        var reporte = await _reporteRepository.Obtener(usuarioId);
        return View(reporte);
    }
    
    // public IActionResult Crear()
    // {
    //     return View();
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> Crear(Reporte reporte)
    // {
    //
    //     if (!ModelState.IsValid)
    //     {
    //         return View(reporte);
    //     }
    //
    //     var nume = 1;
    //
    //     reporte.UsuarioId = nume;
    //     DateTime fech = DateTime.Now;
    //     var hora = fech.Hour;
    //    reporte.TurnoId = hora < 6 && hora > 17 ? 2 : 1;
    //    reporte.Fecha = fech;
    //     await _reporteRepository.Crear(reporte);
    //     return RedirectToAction("Index");
    // }
} 