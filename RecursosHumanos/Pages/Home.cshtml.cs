using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecursosHumanos.Pages
{
    public class HomeModel : PageModel
    {
        public string Rol { get; set; }

        public void OnGet()
        {
            Rol = HttpContext.Session.GetString("Rol");
        }
    }
}
