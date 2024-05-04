using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.Controllers;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CDocumentos
{
    public class EditModel : PageModel
    {
        FirebaseC fb = new FirebaseC("recursoshumanos-7b147.appspot.com");
        private readonly RecursosHumanos.DAL.Db _context;

        public EditModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        [BindProperty]
        public Documentos Documentos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos =  await _context.Documentos.FirstOrDefaultAsync(m => m.Id == id);
            if (documentos == null)
            {
                return NotFound();
            }
            Documentos = documentos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile cedula, IFormFile certificado, IFormFile otro)
        {
            Documentos.Cedula_img = await fb.Subir(cedula, "Cedula" + Documentos.Id , "Cedulas");
            Documentos.Contrato = await fb.Subir(certificado, "Contrato" + Documentos.Id, "Contratos");
            if (otro != null)
            {
                Documentos.Otro = await fb.Subir(otro, "Otro" + Documentos.Id, "Otros");
            }

            _context.Attach(Documentos).State = EntityState.Modified;

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
                if (!DocumentosExists(Documentos.Id))
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

        private bool DocumentosExists(long id)
        {
            return _context.Documentos.Any(e => e.Id == id);
        }
    }
}
