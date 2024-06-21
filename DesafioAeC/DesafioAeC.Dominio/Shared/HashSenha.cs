using System.Security.Cryptography;
using System.Text;

namespace DesafioAeC.Dominio.Shared
{
    public class HashSenha
    {
        public static string HashPassword(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static bool VerificarSenha(string senhaPreenchida, string senhaArmazenada, bool isToHash)
        {
            if (isToHash)
                senhaPreenchida = HashPassword(senhaPreenchida);

            return senhaPreenchida == senhaArmazenada;
        }
    }
}
