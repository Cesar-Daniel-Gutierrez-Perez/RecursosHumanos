using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecursosHumanos.Pages
{
    public class LoginModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public LoginModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Login Login { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = _context.Usuario.FirstOrDefault(u => u.Nombre == Login.Nombre && u.Contraseña == Login.Contraseña);
            if (usuario == null)
            {
                ViewData["Mensaje"] = "Nombre de usuario o contraseña incorrectos.";
                return Page();
            }

            return RedirectToPage("/Home");
        }
    }
}
