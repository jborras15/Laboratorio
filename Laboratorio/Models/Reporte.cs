using Laboratorio.Models;

namespace Laboratorio.Controllers;

public class Reporte
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int UsuarioId { get; set; }
    public int TurnoId { get; set; }
    public string Descripcion { get; set; }
    public string Usuario { get; set; }
    public string Turnos { get; set; }
}
    
