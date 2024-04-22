using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CAsistencia
{
    public class DetailsModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public DetailsModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public Asistencia Asistencia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia.FirstOrDefaultAsync(m => m.Id == id);
            if (asistencia == null)
            {
                return NotFound();
            }
            else
            {
                Asistencia = asistencia;
            }
            return Page();
        }
    }
}
