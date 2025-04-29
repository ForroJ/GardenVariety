using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenVariety.Data;
using GardenVariety.Models;

namespace GardenVariety.Pages.Gardens
{
    public class IndexModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public IndexModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        public IList<Garden> Garden { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Garden = await _context.Gardens.ToListAsync();
        }
    }
}
