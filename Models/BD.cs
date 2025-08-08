using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=A-PHZ2-CEO-12; DataBase=Recordatorios; Integrated Security=True; TrustServerCertificate=True;";
 
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
    public static List<Tarea> ObtenerTareasActivas()
{
    using (SqlConnection connection = ObtenerConexion())
    {
        var query = "SELECT * FROM Tareas WHERE Activa = 1";
        var tareas = connection.Query<Tarea>(query).ToList();
        return tareas;
    }
}

}