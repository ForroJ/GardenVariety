using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenVariety.Data;
using GardenVariety.Models;

namespace GardenVariety.Pages.Harvests
{
    public class DeleteModel : PageModel
    {
        private readonly GardenVariety.Data.GardenVarietyContext _context;

        public DeleteModel(GardenVariety.Data.GardenVarietyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Harvester Harvester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvester = await _context.Harvests
    .Include(h => h.Garden)
    .FirstOrDefaultAsync(m => m.Id == id);
            if (harvester is not null)
            {
                Harvester = harvester;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvester = await _context.Harvests.FindAsync(id);
            if (harvester != null)
            {
                Harvester = harvester;
                _context.Harvests.Remove(Harvester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
