namespace prueba2.Controllers;
using System.Security.Cryptography;
using System.Text;
public class Seguridad
{
    public dynamic encriptar(string token){
        byte[] data = Encoding.UTF8.GetBytes(token);
        using var sha256 = SHA256.Create();
        return Convert.ToBase64String(sha256.ComputeHash(data));
    }
    public dynamic VerifyHash(string token_original, string token_hash){
        byte[] originalBytes = Encoding.UTF8.GetBytes(token_original);
        byte[] hash  = Convert.FromBase64String(token_hash);
        using var sha256 = SHA256.Create();
        var newHash = sha256.ComputeHash(originalBytes);
        return newHash.SequenceEqual(hash);
    }
      public dynamic generarToken(){
        byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        byte[] key = Guid.NewGuid().ToByteArray();
        string token = Convert.ToBase64String(time.Concat(key).ToArray());
        return token;
    }
}