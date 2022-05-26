namespace prueba2.Models;

public class Usuario{
    public int id {set;get;}
    public string user {set;get;} = String.Empty;
    public string pass {set;get;} = String.Empty;

    public Usuario(){
    }
    public Usuario(int id, string user, string pass){
        this.id= id;
        this.pass= pass;
        this.user= user;   
    }
}