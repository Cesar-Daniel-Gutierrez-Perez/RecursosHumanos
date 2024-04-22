using System.Security.Cryptography;
using System.Text;

namespace RecursosHumanos.Controllers
{
    public class Encriptar
    {
        public static string encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el array de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool desencriptar(string clave, string ClaveG)
        {
            // Encriptar la contraseña ingresada utilizando el mismo método de encriptación
            string claveEn = encriptar(clave);

            // Comparar la contraseña encriptada ingresada con la contraseña almacenada
            return clave == ClaveG;
        }
    }
}
