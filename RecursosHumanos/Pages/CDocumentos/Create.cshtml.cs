using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using RecursosHumanos.Controllers;

namespace RecursosHumanos.Pages.CDocumentos
{
    public class CreateModel : PageModel
    {
        FirebaseC fb = new FirebaseC("recursoshumanos-7b147.appspot.com");

        public string Rol { get; set; }
        public string Cedula { get; set; }
        

        private readonly RecursosHumanos.DAL.Db _context;

        public CreateModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Rol = HttpContext.Session.GetString("Rol");
            Cedula = HttpContext.Session.GetString("Cedula");
            return Page();
        }
       
        [BindProperty]
        public Documentos Documentos { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile cedula, IFormFile certificado, IFormFile otro)
        {
            Documentos.Cedula_img = await fb.Subir(cedula, "Cedula" + (Documentos.Id + 1), "Cedulas");
            Documentos.Contrato = await fb.Subir(certificado, "Contrato" + (Documentos.Id + 1), "Contratos");
            if (otro != null)
            {
                Documentos.Otro = await fb.Subir(otro, "Otro" + (Documentos.Id + 1), "Otros");
            }            
            try
            {
                _context.Documentos.Add(Documentos);
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
