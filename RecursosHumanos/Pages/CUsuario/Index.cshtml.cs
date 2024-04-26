using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecursosHumanos.Pages.CUsuario
{
    public class IndexModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Nombre { get; set; }

        public IList<Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                Usuario = await _context.Usuario.Where(u => u.Nombre.Contains(Nombre)).ToListAsync();
            }
            else
            {
                Usuario = await _context.Usuario.ToListAsync();
            }
        }
    }
}
