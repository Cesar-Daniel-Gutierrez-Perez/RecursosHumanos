using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CExcusas
{
    public class IndexModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public IndexModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public IList<Excusas> Excusas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (FechaInicio != default && FechaFin != default && FechaInicio <= FechaFin)
            {
                Excusas = await _context.Excusas.Where(u => u.Inicio >= FechaInicio && u.Finalizacion <= FechaFin).ToListAsync();
            }
            else
            {
                Excusas = await _context.Excusas.ToListAsync();
            }
        }
    }
}
