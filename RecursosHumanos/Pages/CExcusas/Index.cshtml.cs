﻿using System;
using System.Collections.Generic;
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

        public IList<Excusas> Excusas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Excusas = await _context.Excusas.ToListAsync();
        }
    }
}
