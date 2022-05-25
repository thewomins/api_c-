namespace prueba2.Models;
public class Noticias{
    public int id {set;get;}
    public string titulo {set;get;} = String.Empty;
    public string descripcion {set;get;} = String.Empty;
    public List<string> comentarios {set;get;} = null;

    public Noticias(){
    }
    public Noticias(int id, string titulo, string descripcion, List<string> comentarios){
        this.comentarios=comentarios;
        this.id=id;
        this.titulo=titulo;
        this.descripcion=descripcion;
    }
}