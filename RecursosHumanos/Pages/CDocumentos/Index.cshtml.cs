using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CDocumentos
{
    public class IndexModel : PageModel
    {
        public string Rol { get; set; }
        public string Cedula { get; set; }
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public IList<Documentos> Documentos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Rol = HttpContext.Session.GetString("Rol");
            Cedula = HttpContext.Session.GetString("Cedula");
            Documentos = await _context.Documentos.ToListAsync();
        }
    }
}
