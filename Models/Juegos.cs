namespace prueba2.Models;

public class Juegos{
    public int id {set;get;}
    public string nombre {set;get;} = String.Empty;
    public string descripcion {set;get;} = String.Empty;
    public int yearPublicacion {set;get;}

    public Juegos(){
    }
    public Juegos(int id, string nombre, string descripcion, int yearPublicacion){
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.yearPublicacion = yearPublicacion;
    }
}