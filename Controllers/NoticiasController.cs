using prueba2.Models;
namespace prueba2.Controllers;

public class NoticiasController{
    private static List<Noticias> noticias_list = new List<Noticias> (){
      new Noticias(1,"noticia--1","futbol",new List<String>()),
      new Noticias(2,"noticia--2","nose",new List<String>()),
      new Noticias(3,"noticia--3","mario classic",new List<String>()),
      new Noticias(4,"noticia--4","gta",new List<String>())
    };

    public Noticias getNoticiasId(int id){
        return noticias_list.Find(list=>list.id==id);
    }
    public Noticias crearNoticia(Noticias noticia){
        if(noticia ==null){
            return new Noticias ();
        }
        noticias_list.Add(noticia);
        return noticia;        
    }

    public Boolean anadirComentario(int id,string comentario){
        if(id<0 || comentario == string.Empty){
            return false;
        }
        Noticias noticia = getNoticiasId(id);
        if(noticia == null){return false;}
        noticia.addComentarios(comentario);
        return true;
    }

    public List<Noticias> mostrarNoticias(){
        return noticias_list;
    }

    //si se ponen numeros en url
    public List<Noticias> mostrar3Noticias(int menor, int mayor){
        List<Noticias> temp = new List<Noticias> ();
        if(mayor-menor!=3){return temp;}
        temp.Add(noticias_list[menor-1]);
        temp.Add(noticias_list[mayor-2]);
        temp.Add(noticias_list[mayor-1]);
        return temp;
    }

    //si son todos pero de 3 en 3
    public List<List<Noticias>> mostrar3Noticias1(){
        List<List<Noticias>> temp = new List<List<Noticias>> ();
        int i=0,j=0;
        foreach (var item in noticias_list){
            temp[j].Add(item);
            i++;
            if(i==3){
                i=0;
                j++;
            }
        }
        return temp;
    }


}

