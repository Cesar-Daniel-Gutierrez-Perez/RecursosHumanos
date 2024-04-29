using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecursosHumanos.Controllers;
using RecursosHumanos.Models;
using RecursosHumanos.Controllers;

namespace RecursosHumanos.Pages
{
    public class CertificadoModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public CertificadoModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public string Id { get; set; }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Id = HttpContext.Session.GetString("Id");
            var Empleado = _context.Empleado.FirstOrDefault(u => u.id_usuario.ToString() == Id );
            String contenido = "La empresa certifica que el Empleado " + Empleado.Nombre + " de cedula " + Empleado.Cedula + " trabaja desde " + Empleado.Fecha_Contratacion;
            Byte[] pdf = Pdf.GenerarPDF(contenido);

            
            await _context.SaveChangesAsync();

            return File(pdf, "application/pdf", "documento.pdf");
        }
    }
}
