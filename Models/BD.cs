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
            int idCategoria = connection.QueryFirstOrDefault<int>(
                "SELECT ID FROM Categoria WHERE Nombre = @categoria",
                new { categoria }
            );

            if (idCategoria == 0)
            {
                idCategoria = connection.QuerySingle<int>(
                    "INSERT INTO Categoria (Nombre) VALUES (@categoria); SELECT CAST(SCOPE_IDENTITY() AS int);",
                    new { categoria }
                );
            }

            connection.Execute(
                "INSERT INTO Tareas (Nombre, Fecha, IDCategoria, Activa) VALUES (@nombre, @fecha, @idCategoria, 1)",
                new { nombre, fecha, idCategoria }
            );

            Tarea tarea = new Tarea
            {
                Nombre = nombre,
                Fecha = fecha,
                IDCategoria = idCategoria,
                Activa = true
            };

            return tarea;
        }
    }
    public static List<string> DevolverCategorias()
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Nombre FROM Categoria";
            var categorias = connection.Query<string>(query).ToList();
            return categorias;
        }
        return null;
    }
    public static void InsertarCategoria(string nombre)
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "INSERT INTO Categoria (Nombre) VALUES (@nombre)";
            connection.Execute(query, new { nombre });
        }
    }

}