namespace prueba2.Models;

public class Token{
    public string token { get; set; }= string.Empty;
    public  Boolean estado { get; set; }
    public int userId { get; set; }
    public Token(){    
    }
    public Token(string token, Boolean estado,int userId){
        this.estado= estado;
        this.token= token;
        this.userId= userId;
    }

}