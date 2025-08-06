using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-13; DataBase=Recordatorios; Integrated Security=True; TrustServerCertificate=True;";
    
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
}