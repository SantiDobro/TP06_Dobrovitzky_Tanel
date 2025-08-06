using Microsoft.Data.SqlClient;
using Dapper;

public class Perfil
{
    public string Usuario { get; set; }
    public string Contraseña { get; set; }
    public DateTime Nacimiento { get; set; }

    public Perfil() { }

    public static int AgregarPerfil(string NuevoUsuario, string NuevaContraseña, DateTime NuevoNacimiento)
    {
        string query = "Insert Into Perfil(Usuario, Contraseña, Nacimiento) Values (@NuevoUsuario, @NuevaContraseña, @NuevoNacimiento)";
        int registrosafectados = 0;
        using (SqlConnection connection = BD.ObtenerConexion())
        {
          registrosafectados = connection.Execute(query, new { NuevoUsuario = NuevoUsuario, NuevaContraseña = NuevaContraseña, NuevoNacimiento = NuevoNacimiento });
        }
        return registrosafectados;
    }
    public static Perfil LevantarPerfil(string Usuario, string Contraseña)
    {
        using (SqlConnection connection = BD.ObtenerConexion())
        {
            string query = "SELECT * FROM Perfil WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
            return connection.QueryFirstOrDefault<Perfil>(query, new { Usuario, Contraseña });
        }
    }
    public static Perfil BuscarPorUsuario(string Usuario)
    {
        using (SqlConnection connection = BD.ObtenerConexion())
        {
            string query = "SELECT * FROM Perfil WHERE Usuario = @Usuario";
            return connection.QueryFirstOrDefault<Perfil>(query, new { Usuario });
        }
    }
}