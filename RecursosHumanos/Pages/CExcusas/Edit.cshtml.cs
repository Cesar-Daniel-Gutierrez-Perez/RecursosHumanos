using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CExcusas
{
    public class EditModel : PageModel
    {
        public string Rol { get; set; }
        private readonly RecursosHumanos.DAL.Db _context;

        public EditModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        [BindProperty]
        public Excusas Excusas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            Rol = HttpContext.Session.GetString("Rol");
            if (id == null)
            {
                return NotFound();
            }

            var excusas =  await _context.Excusas.FirstOrDefaultAsync(m => m.Id == id);
            if (excusas == null)
            {
                return NotFound();
            }
            Excusas = excusas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Excusas).State = EntityState.Modified;

            try
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("FOREIGN KEY"))
                    {
                        TempData["Mensaje"] = "No existe Empleado con la cedula ingresada";
                        return Page();
                    }
                    else
                    {
                        TempData["Mensaje"] = ex;
                        return Page();
                    }
                }                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcusasExists(Excusas.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExcusasExists(long id)
        {
            return _context.Excusas.Any(e => e.Id == id);
        }
    }
}
