using  prueba2.Models;
namespace prueba2.Controllers;

public class TokenController: Seguridad{
    private static List<Token> tokens = new List<Token> ();
    public TokenController(){
        tokens.Add(new Token(base.generarToken(),true,1));
    }
    public string asignarToken(int userId){
        //int? a=null;
        try{
            Token?  token = new Token ();
            token = tokens.Find(t=>t.userId == userId && t.estado == true); 
            return (token ==null)? string.Empty:base.encriptar(token.token);
        }
        catch (System.Exception ex){
            System.Console.WriteLine("error controlado: "+ex.ToString());
            return string.Empty;
        } 
    }
    public Boolean verficarToken(string token_enviado_user){
         try{
             Boolean verificar= false;
             foreach (var obToken in tokens){
                if(obToken.estado == true && base.VerifyHash(obToken.token,token_enviado_user)){
                    verificar=true;
                    break;
                 }
             }
            return verificar;
         }
         catch (System.Exception ex){
             System.Console.WriteLine("error controlado: "+ex.ToString());
              return false;
         }
    }

    public Boolean verificaHeaders(HttpRequest request){
        try{
            string auth="api-key";
            Boolean resp=false;
           foreach (var item in request.Headers){
               System.Console.WriteLine(item.Key);
               if(item.Key.Equals(auth)){
                   string token_enviado_user=item.Value;
                   if(verficarToken(token_enviado_user)){
                       resp=true; break;
                   }
               }
           }
            return resp;
        }
        catch (System.Exception ex){
             System.Console.WriteLine("error controlado: "+ex.ToString());
             return false;
        }
    }
}