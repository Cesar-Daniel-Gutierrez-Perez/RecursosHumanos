using Firebase.Storage;

namespace RecursosHumanos.Controllers
{
    public class FirebaseC
    {
        private readonly string _fb;

        public FirebaseC(string firebaseStorageBucket)
        {
            _fb = firebaseStorageBucket;
        }

        public async Task<string> Subir(IFormFile archivo, string nombreArchivoFirebase, string directorioEnFirebase)
        {
            try
            {
                using (var stream = archivo.OpenReadStream())
                {
                    var downloadUrl = await new FirebaseStorage(_fb)
                        .Child(directorioEnFirebase)
                        .Child(nombreArchivoFirebase)
                        .PutAsync(stream);

                    return downloadUrl;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al subir el archivo: " + ex.Message);
                return null;
            }
        }
    }
}
