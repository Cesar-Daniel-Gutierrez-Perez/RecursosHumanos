using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CEmpleado
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
        public Empleado Empleado { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.Empleado.Add(Empleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The database operation was expected to "))
                {
                    TempData["Mensaje"] = "No se puede cambiar la Cedula de este usuario al tener relacion con otras tablas";
                    return Page();
                }
                if (ex.ToString().Contains("FK__empleado__id_dep"))
                {
                    TempData["Mensaje"] = "No existe Departamento con el Id ingresado";
                    return Page();
                }
                if (ex.ToString().Contains("FK__empleado__id_rol"))
                {
                    TempData["Mensaje"] = "No existe Rol con el Id ingresado";
                    return Page();
                }
                if (ex.ToString().Contains("FK__empleado__id_usu"))
                {
                    TempData["Mensaje"] = "No existe Usuario con el Id ingresado";
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
