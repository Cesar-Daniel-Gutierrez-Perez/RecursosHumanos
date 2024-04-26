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
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Cedula { get; set; }
        public IList<Documentos> Documentos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Cedula))
            {
                Documentos = await _context.Documentos.Where(u => u.Cedula_E.ToString().Contains(Cedula)).ToListAsync();
            }
            else
            {
                Documentos = await _context.Documentos.ToListAsync();
            }
        }
    }
}
