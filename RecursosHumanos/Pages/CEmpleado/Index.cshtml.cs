using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecursosHumanos.Pages.CEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Cedula { get; set; }
        public IList<Empleado> Empleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Cedula))
            {
                Empleado = await _context.Empleado.Where(u => u.Cedula.ToString().Contains(Cedula)).ToListAsync();
            }
            else
            {
                Empleado = await _context.Empleado.ToListAsync();
            }
        }
    }
}
