using Microsoft.Data.SqlClient;
using Dapper;
public class TareaPerfil
{
    public int ID { get; set; }
    public string Usuario { get; set; }
    public int IDTarea { get; set; }
}