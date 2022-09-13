namespace Laboratorio.Models;

public class Reportes
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int UsuarioId { get; set; }
    public int TurnoId { get; set; }
    public string Descripcion { get; set; }

}