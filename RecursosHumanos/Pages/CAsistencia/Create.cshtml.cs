using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CAsistencia
{
    public class CreateModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public CreateModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Asistencia Asistencia { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.Asistencia.Add(Asistencia);
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
            

            return RedirectToPage("./Index");
        }
    }
}
