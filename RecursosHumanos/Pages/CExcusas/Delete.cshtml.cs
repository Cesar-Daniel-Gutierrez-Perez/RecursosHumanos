using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CExcusas
{
    public class DeleteModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public DeleteModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        [BindProperty]
        public Excusas Excusas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusas = await _context.Excusas.FirstOrDefaultAsync(m => m.Id == id);

            if (excusas == null)
            {
                return NotFound();
            }
            else
            {
                Excusas = excusas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusas = await _context.Excusas.FindAsync(id);
            if (excusas != null)
            {
                Excusas = excusas;
                _context.Excusas.Remove(Excusas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
