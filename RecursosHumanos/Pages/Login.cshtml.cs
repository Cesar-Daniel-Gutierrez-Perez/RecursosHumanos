using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using RecursosHumanos.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

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
            ClaimsPrincipal claimsUser = HttpContext.User;

            if (claimsUser.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Home");
            }
            return Page();
        }

        [BindProperty]
        public Login Login { get; set; } = default!;

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = _context.Usuario.FirstOrDefault(u => u.Nombre == Login.Nombre && u.Clave == Encriptar.encriptar(Login.Clave));
            var empleado = _context.Empleado.FirstOrDefault(e => e.id_usuario == usuario.Id);
            var rol = empleado.id_rol;
            if (usuario == null)
            {
                ViewData["Mensaje"] = "Nombre de usuario o contraseña incorrectos.";
                return Page();
            }
            HttpContext.Session.SetString("Rol", rol.ToString());
            return RedirectToPage("/Home");
        }
    }
}
