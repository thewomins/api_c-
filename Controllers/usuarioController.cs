using prueba2.Models;
namespace prueba2.Controllers;
public class UsuarioController{
    private static List<Usuario>usuarios = new List<Usuario> (){
        new Usuario(1,"pepe","pepe")
    };

    public string login(Usuario usuario){
        try{
            TokenController tkc = new TokenController ();
            Usuario? obUser= new Usuario ();
            obUser = usuarios.Find(
                u=>u.user.Equals(usuario.user)
                &&
                u.pass.Equals(usuario.pass)
            );
            return (obUser==null)? string.Empty:tkc.asignarToken(obUser.id);
        }
        catch (System.Exception ex){
            System.Console.WriteLine("Error controlado: "+ex.ToString());
            return string.Empty;
        }
    }
}