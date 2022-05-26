using prueba2.Models;
namespace prueba2.Controllers;
public class JuegoController{
    private static List<Juegos> juegos_list = new List<Juegos> (){
      new Juegos(1,"fifa","futbol",2020),
      new Juegos(2,"pruebasa","nose",1998),
      new Juegos(3,"Super mario Bros","mario classic",1980),
      new Juegos(4,"gta v","gta",2014)};

    public Juegos crearJuego(Juegos juego){
        if(juego ==null){
            return new Juegos ();
        }
        juegos_list.Add(juego);
        return juego;        
    }

    public Juegos? getGameId(int id){
        return juegos_list.Find(list=>list.id==id);
    }

    public List<Juegos> getAllGames(){
        return juegos_list;
    }

    public Boolean eliminarGameId(int id){
        if(id<=0){
            return false;
        }
        juegos_list.RemoveAll(e=>e.id==id);
        return true;
    }

    public Juegos editarGame(Juegos juego){
        if(juego==null){
            return new Juegos ();
        }
        Juegos? juego_a_editar = getGameId(juego.id);
        if(juego_a_editar==null){
            return new Juegos ();
        }
        juego_a_editar.nombre=juego.nombre;
        juego_a_editar.descripcion=juego.descripcion;
        juego_a_editar.yearPublicacion=juego.yearPublicacion;
        return juego_a_editar;
    }

    public List<Juegos> mostrarPorLetra(char character){
        
        return juegos_list.FindAll(e=>e.nombre.ToUpper().Contains(Char.ToUpper(character)));
        /*List<Juegos> new_list = new List<Juegos> ();
        foreach (var juego in juegos_list){
            if(juego.nombre.ToUpper().Contains(Char.ToUpper(character))){
                new_list.Add(juego);
            }
        }
        return new_list;*/
    }

    public List<Juegos> anio1999to2020(){
        return juegos_list.FindAll(e=>e.yearPublicacion>1999&&e.yearPublicacion<=2020);
    }

}