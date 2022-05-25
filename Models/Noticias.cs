namespace prueba2.Models;
public class Noticias{
    public int id {set;get;}
    public string titulo {set;get;} = String.Empty;
    public string descripcion {set;get;} = String.Empty;
    public List<string> comentario {set;get;}
}