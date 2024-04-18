using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RecursosHumanos.Models;

namespace RecursosHumanos.DAL
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        public DbSet<RecursosHumanos.Models.Usuario> Usuario { get; set; } = default!;
        

    }
}
