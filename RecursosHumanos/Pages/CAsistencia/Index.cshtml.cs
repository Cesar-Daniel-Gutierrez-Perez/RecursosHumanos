using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecursosHumanos.Pages.CAsistencia
{
    public class IndexModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        
        public IList<Asistencia> Asistencia { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (Fecha != default)
            {
                Asistencia = await _context.Asistencia.Where(u => u.Fecha.Date == Fecha.Date).ToListAsync();
            }
            else
            {
                Asistencia = await _context.Asistencia.ToListAsync();
            }
        }
    }
}
