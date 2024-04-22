using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.DAL;
using RecursosHumanos.Models;

namespace RecursosHumanos.Pages.CRoles
{
    public class DetailsModel : PageModel
    {
        private readonly RecursosHumanos.DAL.Db _context;

        public DetailsModel(RecursosHumanos.DAL.Db context)
        {
            _context = context;
        }

        public Roles Roles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }
            else
            {
                Roles = roles;
            }
            return Page();
        }
    }
}
