public class Tarea
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int IDCategoria { get; set; }
    public DateTime Fecha { get; set; }
    public bool Finalizada { get; set; } = false;
    public bool Activa { get; set; } = true;
}
