using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=A-PHZ2-LUM-17; DataBase=BD_Integrantes; Integrated Security=True; TrustServerCertificate=True;";
    
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
}