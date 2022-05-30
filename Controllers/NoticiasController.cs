using prueba2.Models;
namespace prueba2.Controllers;

public class NoticiasController{
    private static List<Noticias> noticias_list = new List<Noticias> (){
      new Noticias(1,"Perdio colo-colo","futbol",new List<String>()),
      new Noticias(2,"noticia--2","nose",new List<String>()),
      new Noticias(3,"noticia--3","mario classic",new List<String>()),
      new Noticias(4,"noticia--4","gta",new List<String>())
    };

    public Noticias? getNoticiasId(int id){
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
        Noticias? noticia = getNoticiasId(id);
        if(noticia == null){return false;}
        noticia.addComentarios(comentario);
        return true;
    }

    public List<Noticias> mostrarNoticias(){
        return noticias_list;
    }

    //si se ponen numeros en url
    public List<Noticias> mostrarNoticiasRango(int menor, int mayor){
        List<Noticias> temp = new List<Noticias> ();
        if(mayor<menor || menor <=0){return temp;}
        for(int i = menor-1; i < noticias_list.Count && i<mayor ; i++){
            temp.Add(noticias_list[i]);
            //Console.WriteLine(noticias_list[i]+" - "+i+" - "+mayor+" - "+noticias_list.Count);
        }
        return temp;
    }

    //si son todos pero de 3 en 3
    /*public List<List<Noticias>> mostrar3Noticias1(){
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
    }*/


}

