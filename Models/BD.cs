using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Recordatorios; Integrated Security=True; TrustServerCertificate=True;";

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
        return null;
    }
    public static Tarea InsertarTarea(string nombre, DateTime fecha, string categoria)
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            var IDCategoria = "SELECT IDCategoria from Tareas INNER JOIN Categoria ON Tareas.IDCategoria = Categoria.ID WHERE Categoria.Nombre = @nombre";
            var query = "INSERT INTO Tareas (Nombre, Fecha, IDCategoria) VALUES (@nombre, @fecha, @IDCategoria)";
            var tarea = connection.QueryFirstOrDefault<Tarea>(query);
            return tarea;
        }
        return null;
    }
}