using System.Data.SqlClient;
using Dapper;
using Laboratorio.Controllers;
using Laboratorio.Models;

namespace Laboratorio.Repositorios;

public interface IReporteRepository
{
    Task<IEnumerable<Reporte>> Obtener(int usuarioId);

    Task Crear(Reportes reportes);
}
public class ReporteRepository:IReporteRepository
{
    public readonly string connectionString;
    private readonly IConfiguration _configuration;

    public ReporteRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    //lista
    public async Task<IEnumerable<Reporte>> Obtener(int UsuarioId)
    {
        
        using var connection = new SqlConnection(connectionString);

        return await connection.QueryAsync<Reporte>(@"
                                select r.Fecha, u.Nombre as Usuario , t.Nombre as Turnos , r.Descripcion from ReporteDiario.Reporte r  inner join ReporteDiario.Turnos t on r.TurnoId = t.Id
inner join ReporteDiario.Usuario u on r.UsuarioId = u.Id where r.UsuarioId=@UsuarioId;", new { UsuarioId });
    }
        
    

    
    public async Task Crear(Reportes reportes)
    {
        using var connection = new SqlConnection(connectionString);
        //QuerySingle sirve para establecer un query que va a traer un solo elemento
        var  id = await connection.QuerySingleAsync<int>($@"Insert into ReporteDiario.Reporte(Fecha, UsuarioId, TurnoId,Descripcion)
                                                        values(@Fecha, @UsuarioId, @TurnoId , @Descripcion);
                                                        SELECT SCOPE_IDENTITY();", reportes);;
        // SCOPE_IDENTITY() es para regresar el id 
        reportes.Id = id;
    }

}