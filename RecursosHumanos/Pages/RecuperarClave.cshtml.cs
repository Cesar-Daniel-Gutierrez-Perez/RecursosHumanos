using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecursosHumanos.Pages
{
    public class RecuperarClaveModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public RecuperarClaveModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        
        public void OnGet()
        {
        }
        [BindProperty]
        public string Nombre { get; set; }
        [BindProperty]
        public string Correo { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = _context.Usuario.FirstOrDefault(u => u.Nombre == Nombre);
            var correo = _context.Empleado.FirstOrDefault(e => e.id_usuario == usuario.Id && e.Correo == Correo);
            if (usuario != null || correo != null)
            {
                var empleado = _context.Empleado.FirstOrDefault(e => e.id_usuario == usuario.Id);                
                var id = usuario.Id;
                var rol = empleado.id_rol;

                HttpContext.Session.SetString("Rol", rol.ToString());
                HttpContext.Session.SetString("Id", id.ToString());
            }
            if (usuario == null || correo == null)
            {
                TempData["Mensaje"] = "Nombre de usuario o correo incorrectos.";
                return Page();
            }
            return RedirectToPage("/Home");
        }
    }
}
